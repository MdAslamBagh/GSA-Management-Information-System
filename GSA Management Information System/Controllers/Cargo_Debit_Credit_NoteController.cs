using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_Management_Information_System.Models;

namespace GSA_Management_Information_System.Controllers
{
    public class Cargo_Debit_Credit_NoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cargo_Debit_Credit_Note
        public ActionResult Index()
        {
            return View(db.Cargo_Debit_Credit_Note.ToList());
        }

        // GET: Cargo_Debit_Credit_Note/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Debit_Credit_Note cargo_Debit_Credit_Note = db.Cargo_Debit_Credit_Note.Find(id);
            if (cargo_Debit_Credit_Note == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Debit_Credit_Note);
        }

        // GET: Cargo_Debit_Credit_Note/Create
        public ActionResult Add()
        {
            var list = new List<string>() { "Debit", "Credit" };
            ViewBag.list = list;
            return View();
        }

        // POST: Cargo_Debit_Credit_Note/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Trans_Date,Type,Customer_Name,Reference_No,Currency,Exchange_Rate,Amount_USD,Amount_BDT,Remarks,Entry_Date")] Cargo_Debit_Credit_Note cargo_Debit_Credit_Note)
        {
            if (ModelState.IsValid)
            {
                db.Cargo_Debit_Credit_Note.Add(cargo_Debit_Credit_Note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo_Debit_Credit_Note);
        }

        // GET: Cargo_Debit_Credit_Note/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Debit_Credit_Note cargo_Debit_Credit_Note = db.Cargo_Debit_Credit_Note.Find(id);
            if (cargo_Debit_Credit_Note == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Debit_Credit_Note);
        }

        // POST: Cargo_Debit_Credit_Note/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Trans_Date,Type,Customer_Name,Reference_No,Currency,Exchange_Rate,Amount_USD,Amount_BDT,Remarks,Entry_Date")] Cargo_Debit_Credit_Note cargo_Debit_Credit_Note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Debit_Credit_Note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo_Debit_Credit_Note);
        }

        // GET: Cargo_Debit_Credit_Note/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Debit_Credit_Note cargo_Debit_Credit_Note = db.Cargo_Debit_Credit_Note.Find(id);
            if (cargo_Debit_Credit_Note == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Debit_Credit_Note);
        }

        // POST: Cargo_Debit_Credit_Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo_Debit_Credit_Note cargo_Debit_Credit_Note = db.Cargo_Debit_Credit_Note.Find(id);
            db.Cargo_Debit_Credit_Note.Remove(cargo_Debit_Credit_Note);
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
