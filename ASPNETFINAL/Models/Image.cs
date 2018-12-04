using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETFINAL.Models
{
    public class Image
    {

        public int ImgID { get; set; }

        [Required]
        public string ImgURL { get; set; }
    }
}