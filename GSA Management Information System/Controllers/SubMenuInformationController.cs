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
    public class SubMenuInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubMenuInformation
        public ActionResult Index()
        {
            return View(db.SubMenuInformations.ToList());
        }

        // GET: SubMenuInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenuInformation subMenuInformation = db.SubMenuInformations.Find(id);
            if (subMenuInformation == null)
            {
                return HttpNotFound();
            }
            return View(subMenuInformation);
        }

        // GET: SubMenuInformation/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuInformations, "MenuItemId", "Menu_Name");
            return View();
        }

        // POST: SubMenuInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubMenuId,Access_Name,MenuItemId,Controller_Name,Action_Name,IsVisible")] SubMenuInformation subMenuInformation)
        {
            if (ModelState.IsValid)
            {
                db.SubMenuInformations.Add(subMenuInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subMenuInformation);
        }

        // GET: SubMenuInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenuInformation subMenuInformation = db.SubMenuInformations.Find(id);
            if (subMenuInformation == null)
            {
                return HttpNotFound();
            }
            return View(subMenuInformation);
        }

        // POST: SubMenuInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubMenuId,Access_Name,MenuItemId,Controller_Name,Action_Name,IsVisible")] SubMenuInformation subMenuInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subMenuInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subMenuInformation);
        }

        // GET: SubMenuInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenuInformation subMenuInformation = db.SubMenuInformations.Find(id);
            if (subMenuInformation == null)
            {
                return HttpNotFound();
            }
            return View(subMenuInformation);
        }

        // POST: SubMenuInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubMenuInformation subMenuInformation = db.SubMenuInformations.Find(id);
            db.SubMenuInformations.Remove(subMenuInformation);
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
