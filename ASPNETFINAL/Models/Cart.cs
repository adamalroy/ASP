using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETFINAL.Models
{
    [Table("Cart")]
    public class Cart
    {

        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

    }
}