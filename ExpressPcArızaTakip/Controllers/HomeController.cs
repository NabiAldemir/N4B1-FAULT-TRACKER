using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpressPcArızaTakip.Controllers



{
    public class HomeController : Controller
    {
        public string publicUserName = "gora";
        public string publicPassword = "1234";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

           

        }
        
    }
