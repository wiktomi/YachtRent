using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YachtRent.Models;

namespace YachtRent.Controllers
{
    public class YachtController : Controller
    {
        public YachtsEntities db = new YachtsEntities();

        // GET: Yacht
        public ActionResult Index()
        {
            return View(db.Yachts.ToList());
        }

        // GET: Yacht/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yachts yachts = db.Yachts.Find(id);
            if (yachts == null)
            {
                return HttpNotFound();
            }
            return View(yachts);
        }

        // GET: Yacht/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yacht/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YachtID,YachtName,Capacity,Cabins,Beds,Showers,ProductionDate,Length,Price,Avaliable")] Yachts yachts)
        {
            if (ModelState.IsValid)
            {
                db.Yachts.Add(yachts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yachts);
        }

        // GET: Yacht/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yachts yachts = db.Yachts.Find(id);
            if (yachts == null)
            {
                return HttpNotFound();
            }
            return View(yachts);
        }

        // POST: Yacht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YachtID,YachtName,Capacity,Cabins,Beds,Showers,ProductionDate,Length,Price,Avaliable")] Yachts yachts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yachts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yachts);
        }

        // GET: Yacht/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yachts yachts = db.Yachts.Find(id);
            if (yachts == null)
            {
                return HttpNotFound();
            }
            return View(yachts);
        }

        // POST: Yacht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yachts yachts = db.Yachts.Find(id);
            db.Yachts.Remove(yachts);
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
