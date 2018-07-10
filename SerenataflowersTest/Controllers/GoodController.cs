using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerenataflowersTest.Models;

namespace SerenataflowersTest.Controllers
{
    public class GoodController : Controller
    {
        // GET: Good
        public ActionResult GoodView(int? id = null)
        {
            ViewBag.id = id;
            return View();
        }
    }
}