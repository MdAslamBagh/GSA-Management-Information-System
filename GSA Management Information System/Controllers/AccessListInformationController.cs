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
    public class AccessListInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessListInformation
        public ActionResult Index()
        {
            return View(db.AccessLists.ToList());
        }

        // GET: AccessListInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessListInformation accessListInformation = db.AccessLists.Find(id);
            if (accessListInformation == null)
            {
                return HttpNotFound();
            }
            return View(accessListInformation);
        }

        // GET: AccessListInformation/Create
        public ActionResult Add()
        {
            ViewBag.BaseModule = new SelectList(db.BaseModuleLists, "BaseModuleId", "BaseModule");
            return View();
        }

        // POST: AccessListInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "AccessId,AccessName,BaseModuleId,Controller,Action")] AccessListInformation accessListInformation)
        {
            if (ModelState.IsValid)
            {
                db.AccessLists.Add(accessListInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessListInformation);
        }

        // GET: AccessListInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessListInformation accessListInformation = db.AccessLists.Find(id);
            if (accessListInformation == null)
            {
                return HttpNotFound();
            }
            return View(accessListInformation);
        }

        // POST: AccessListInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessId,AccessName,BaseModule,Controller,Action")] AccessListInformation accessListInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessListInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessListInformation);
        }

        // GET: AccessListInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessListInformation accessListInformation = db.AccessLists.Find(id);
            if (accessListInformation == null)
            {
                return HttpNotFound();
            }
            return View(accessListInformation);
        }

        // POST: AccessListInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessListInformation accessListInformation = db.AccessLists.Find(id);
            db.AccessLists.Remove(accessListInformation);
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
