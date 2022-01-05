using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YachtRent.Models;

namespace YachtRent.Controllers
{
    public class RentController : Controller
    {
        YachtsEntities db = new YachtsEntities();
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetYacht()
        {
            var Yacht = db.Yachts.ToList();

            return Json(Yacht, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetRentedYachts()
        {
            return View(db.Rents.ToList());
        }
        [HttpGet]
        public ActionResult GetCustomerName()
        {
            var Customers = db.Customers.ToList();

            return Json(Customers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetFee(string yachtName)
        {
            var Yacht = db.Yachts.ToList();
            return Json(Yacht.Where(x => x.YachtName == yachtName), JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public ActionResult Save(Rent rent)
        {
            if (ModelState.IsValid)
            {   
                
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rent);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Yacht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YachtName, CustomerName, Fee, StartDate,EndDate")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetRentedYachts");
            }
            return View(rent);
        }

        // GET: Yacht/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Yacht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = db.Rents.Find(id);
            db.Rents.Remove(rent);
            db.SaveChanges();
            return RedirectToAction("GetRentedYachts");
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