﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETFINAL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SellGames()
        {
          

            return View();
        }

        public ActionResult BuyGames()
        {
           

            return View();
        }
    }
}