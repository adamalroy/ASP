using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETFINAL.Models
{
    [Table("Game")]
    public class Game
    {
        
        public int GameId { get; set; }

        [Required]
        [MaxLength(255)]
        public string GameName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Condition { get; set; }

        [Required]
        [Range(0.0,300.00)]
        public Decimal Price { get; set; }

        [Required]
        public string SellerId { get; set; }
        
        [Required]
        public int ImgId { get; set; }
    }
}