﻿using ASPNETFINAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ASPNETFINAL.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 

        // GET: Game
        //public ActionResult Index()
        //{
        //    return View(db.Games.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price"; 
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var games = from g in db.Games
                        select g; 
            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.GameName.Contains(searchString)); 
            }
            switch (sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(g => g.GameName);
                    break;
                case "Price":
                    games = games.OrderBy(g => g.Price);
                    break;
                case "price_desc":
                    games = games.OrderByDescending(g => g.Price);
                    break;
                default:
                    games = games.OrderBy(g => g.GameId);
                    break; 
            }
            return View(games.ToList()); 
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        [Authorize(Roles ="Seller")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "GameId, GameName, Genre, Condition, Price, ImgId" )] Game game)
        {
            try
            {
                game.SellerId = User.Identity.GetUserId();
                game.ImgId = 1;
                // TODO: Add insert logic here
                db.Games.Add(game);
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(game);
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id); 
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "GameId, GameName, Genre, Condition, Price, ImgId")] Game game)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(game);
            
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id); 
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            // TODO: Add delete logic here
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges(); 
            return RedirectToAction("Index");
            

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedGame = db.Games
                .Single(Game => Game.GameId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedGame);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
    }
}
