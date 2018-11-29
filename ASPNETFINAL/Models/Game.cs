using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETFINAL.Models
{
    public class Game
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public double Price { get; set; }
    }
}