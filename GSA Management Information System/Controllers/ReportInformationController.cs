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
    public class ReportInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReportInformation
        public ActionResult Index()
        {
            return View(db.Reports.ToList());
        }



        public ActionResult GetData()
        {

            //List<ReportInformation> Informations = db.Reports.ToList<ReportInformation>();
            var reportlist = from submenu in db.SubMenuInformations join report in db.Reports on submenu.SubMenuId equals report.SubMenuId select new {submenu.Access_Name, report.ReportName };
            return Json(new { data = reportlist }, JsonRequestBehavior.AllowGet);

        }

        // GET: ReportInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInformation reportInformation = db.Reports.Find(id);
            if (reportInformation == null)
            {
                return HttpNotFound();
            }
            return View(reportInformation);
        }




        // GET: ReportInformation/Create
        public ActionResult Create()
        {
            //var ReportName = db.SubMenuInformations.Where(a => a.MenuItemId == 6).Acce;
            //var ReportName = db.SubMenuInformations.Where(x => x.MenuItemId == 6).ToList()?.Access_Name;
            var menuId = db.MenuInformations.Where(a => a.Menu_Name == "Reports").FirstOrDefault().MenuItemId;
            ViewBag.SubMenuId = new SelectList(db.SubMenuInformations.Where(a=>a.MenuItemId== menuId), "SubMenuId", "Access_Name");
            //ViewBag.ReportList = ReportName;
            return View();
        }

        // POST: ReportInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportInformation reportInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                reportInformation.Entry_By = LogedInUser;
                //reportInformation.Entry_Date = DateTime.Now;
                db.Reports.Add(reportInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportInformation);
        }

        // GET: ReportInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInformation reportInformation = db.Reports.Find(id);
            if (reportInformation == null)
            {
                return HttpNotFound();
            }
            return View(reportInformation);
        }

        // POST: ReportInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,SubMenuId,ReportName,Entry_Date,Entry_By")] ReportInformation reportInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportInformation);
        }

        // GET: ReportInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInformation reportInformation = db.Reports.Find(id);
            if (reportInformation == null)
            {
                return HttpNotFound();
            }
            return View(reportInformation);
        }

        // POST: ReportInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportInformation reportInformation = db.Reports.Find(id);
            db.Reports.Remove(reportInformation);
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
