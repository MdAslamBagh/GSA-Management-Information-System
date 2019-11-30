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
    public class StockIssueDetailInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockIssueDetailInformation
        public ActionResult Index()
        {
            return View(db.StockIssueDetailInformations.ToList());
        }

        // GET: StockIssueDetailInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueDetailInformations stockIssueDetailInformations = db.StockIssueDetailInformations.Find(id);
            if (stockIssueDetailInformations == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueDetailInformations);
        }

        // GET: StockIssueDetailInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockIssueDetailInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SDetailsId,SIssued_Code,Ticket_No,Status")] StockIssueDetailInformations stockIssueDetailInformations)
        {
            if (ModelState.IsValid)
            {
                db.StockIssueDetailInformations.Add(stockIssueDetailInformations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockIssueDetailInformations);
        }

        // GET: StockIssueDetailInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueDetailInformations stockIssueDetailInformations = db.StockIssueDetailInformations.Find(id);
            if (stockIssueDetailInformations == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueDetailInformations);
        }

        // POST: StockIssueDetailInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SDetailsId,SIssued_Code,Ticket_No,Status")] StockIssueDetailInformations stockIssueDetailInformations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIssueDetailInformations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockIssueDetailInformations);
        }

        // GET: StockIssueDetailInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueDetailInformations stockIssueDetailInformations = db.StockIssueDetailInformations.Find(id);
            if (stockIssueDetailInformations == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueDetailInformations);
        }

        // POST: StockIssueDetailInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockIssueDetailInformations stockIssueDetailInformations = db.StockIssueDetailInformations.Find(id);
            db.StockIssueDetailInformations.Remove(stockIssueDetailInformations);
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
