using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationTask_Class3.Models;

namespace Class_Task_validation_.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Index(Person pritom)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Go");
            }
            return View(pritom);
        }

        public ActionResult Go()
        {
            return View();
        }


    }
}