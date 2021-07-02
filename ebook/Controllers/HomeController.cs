using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ebook.Models;

namespace ebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.IsAdmin))
                return View("About");
            return View();
        }

        [Authorize(Roles = RoleName.IsAdmin)]
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