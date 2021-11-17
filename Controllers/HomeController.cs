using AutomobileServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomobileServiceStation.Controllers
{
    public class HomeController : Controller

    {
        ServiceContext db = new ServiceContext();
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


        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }

        public JsonResult FetchServiceDetails(int id)
        {
            string txt = db.serviceSubType.Single(x => x.serviceID == id).name;
            return Json(txt, JsonRequestBehavior.AllowGet);
        }
    }
}