using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETFINAL.Models
{
    public class ShoppingCart
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Game game)
        {
            var cartitem = db.Cart.SingleOrDefault(
                c => c.UserId == ShoppingCartId
                && c.GameId == game.GameId);

            if (cartitem == null)
            {
                // Create a new cart item if no cart item exists
                cartitem = new Cart
                {
                    GameId = game.GameId,
                    UserId = ShoppingCartId,
                    DateCreated = DateTime.Now,
                    Quantity = 1
                    
                };
                db.Cart.Add(cartitem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartitem.Quantity++;
            }
            // Save changes
            db.SaveChanges();
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.Cart.Single(
                cart => cart.UserId == ShoppingCartId
                && cart.GameId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    db.Cart.Remove(cartItem);
                }
                // Save changes
                db.SaveChanges();
            }
            return itemCount;
        }
        public List<Cart> GetCartItems()
        {
            return db.Cart.Where(
                cart => cart.UserId == ShoppingCartId).ToList();
        }
    }
 }
