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
        public ActionResult Index()
        {
            var serviceSubtype = db.serviceSubType.Include(s => s.service);
            return View(serviceSubtype.ToList());
        }

        // GET: ServiceSubTypes/Details/5
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
        public ActionResult Create([Bind(Include = "id,name,serviceID,desc")] ServiceSubType serviceSubType)
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
        public ActionResult Edit([Bind(Include = "id,name,serviceID,desc")] ServiceSubType serviceSubType)
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
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSubType serviceSubType = db.serviceSubType.Find(id);
            db.serviceSubType.Remove(serviceSubType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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