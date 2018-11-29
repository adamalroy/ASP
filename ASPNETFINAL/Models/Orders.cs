using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNETFINAL.Models
{
    [Table("Order")]
    public class Orders
    {

        public int OrdersId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public int CartID { get; set; }
    }
}