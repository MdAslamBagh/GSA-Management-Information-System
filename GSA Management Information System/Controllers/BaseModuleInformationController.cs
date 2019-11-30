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
    public class BaseModuleInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BaseModuleInformation
        public ActionResult Index()
        {
            return View(db.BaseModuleLists.ToList());
        }

        // GET: BaseModuleInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseModuleInformation baseModuleInformation = db.BaseModuleLists.Find(id);
            if (baseModuleInformation == null)
            {
                return HttpNotFound();
            }
            return View(baseModuleInformation);
        }

        // GET: BaseModuleInformation/Create
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            return View();
        }

        // POST: BaseModuleInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BaseModuleInformation baseModuleInformation)
        {
            if (ModelState.IsValid)
            {
                db.BaseModuleLists.Add(baseModuleInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baseModuleInformation);
        }

        // GET: BaseModuleInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseModuleInformation baseModuleInformation = db.BaseModuleLists.Find(id);
            if (baseModuleInformation == null)
            {
                return HttpNotFound();
            }
            return View(baseModuleInformation);
        }

        // POST: BaseModuleInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaseModuleId,BaseModule")] BaseModuleInformation baseModuleInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseModuleInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baseModuleInformation);
        }

        // GET: BaseModuleInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseModuleInformation baseModuleInformation = db.BaseModuleLists.Find(id);
            if (baseModuleInformation == null)
            {
                return HttpNotFound();
            }
            return View(baseModuleInformation);
        }

        // POST: BaseModuleInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseModuleInformation baseModuleInformation = db.BaseModuleLists.Find(id);
            db.BaseModuleLists.Remove(baseModuleInformation);
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
