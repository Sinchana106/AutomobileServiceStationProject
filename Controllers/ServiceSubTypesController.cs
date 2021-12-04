using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutomobileServiceStation.Models;

namespace AutomobileServiceStation.Controllers
{
    public class ServiceSubTypesController : Controller
    {
        private ServiceContext db = new ServiceContext();

        // GET: ServiceSubTypes
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var serviceSubType = db.serviceSubType.Include(s => s.service);
            return View(serviceSubType.ToList());
        }

        // GET: ServiceSubTypes/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubType serviceSubType = db.serviceSubType.Find(id);
            if (serviceSubType == null)
            {
                return HttpNotFound();
            }
            return View(serviceSubType);
        }

        // GET: ServiceSubTypes/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.serviceID = new SelectList(db.services, "id", "name");
            return View();
        }

        // POST: ServiceSubTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "id,name,serviceID,cost")] ServiceSubType serviceSubType)
        {
            if (ModelState.IsValid)
            {
                db.serviceSubType.Add(serviceSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serviceID = new SelectList(db.services, "id", "name", serviceSubType.serviceID);
            return View(serviceSubType);
        }

        // GET: ServiceSubTypes/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubType serviceSubType = db.serviceSubType.Find(id);
            if (serviceSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.serviceID = new SelectList(db.services, "id", "name", serviceSubType.serviceID);
            return View(serviceSubType);
        }

        // POST: ServiceSubTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "id,name,serviceID,cost")] ServiceSubType serviceSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serviceID = new SelectList(db.services, "id", "name", serviceSubType.serviceID);
            return View(serviceSubType);
        }

        // GET: ServiceSubTypes/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubType serviceSubType = db.serviceSubType.Find(id);
            if (serviceSubType == null)
            {
                return HttpNotFound();
            }
            return View(serviceSubType);
        }

        // POST: ServiceSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSubType serviceSubType = db.serviceSubType.Find(id);
            db.serviceSubType.Remove(serviceSubType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ServiceList()
        {
            return View(db.services.ToList());
        }

        [HttpPost]
     
        public ActionResult ServiceList(List<Service> slist)
        {
            List<ServiceSubType> sst = new List<ServiceSubType>();
            foreach(Service s in slist)
            {
                
                if (s.check)
                {
                    List<ServiceSubType> slit = new List<ServiceSubType>();
                    int id = s.id;
                    try
                    {
                       slit  = db.serviceSubType.Where(x => x.serviceID == id).ToList();
                        foreach(ServiceSubType stype in slit)
                        {
                            sst.Add(stype);
                        }
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex);
                    }
 
                }
                Session["sst"] = sst;
            }
            return RedirectToAction("SubList");
        }
        [HttpGet]
       
        public ActionResult SubList()
        {
            List<ServiceSubType> sst = (List<ServiceSubType>)Session["sst"];
            return View(sst);
        }

        [HttpPost]
        public ActionResult SubList(List<ServiceSubType> sstList)
        {
            float? total = 0;
                foreach(ServiceSubType ssubType in sstList)
                {
                if (ssubType.check)
                {
                    total += ssubType.cost;
                }
                
                }
            ViewBag.tcost = total;
            Session["total"] = total;
            return View(sstList);
        }

        //public JsonResult GetSubServices(int id)
        //{
        //    List<ServiceSubType> result = db.serviceSubType.Where(x => x.serviceID == id).ToList();
        //    string val = "";

        //    foreach (ServiceSubType sst in result)
        //    {
        //        val += "<input type=checkbox name=chk value= '" + sst.id + "'" + ">" + sst.name + "</input> <br/>";
        //    }
        //    return Json(val, JsonRequestBehavior.AllowGet);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
