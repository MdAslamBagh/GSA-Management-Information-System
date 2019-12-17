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
    public class MenuItemInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenuItemInformation
        public ActionResult Index()
        {
            return View(db.MenuInformations.ToList());
        }
        public JsonResult GetData()
        {
            List<MenuItemInformation> Informations = db.MenuInformations.ToList<MenuItemInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: MenuItemInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItemInformation menuItemInformation = db.MenuInformations.Find(id);
            if (menuItemInformation == null)
            {
                return HttpNotFound();
            }
            return View(menuItemInformation);
        }

        // GET: MenuItemInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuItemInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuItemId,Menu_Name,ModuleIcon")] MenuItemInformation menuItemInformation)
        {
            if (ModelState.IsValid)
            {
                db.MenuInformations.Add(menuItemInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuItemInformation);
        }

        // GET: MenuItemInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItemInformation menuItemInformation = db.MenuInformations.Find(id);
            if (menuItemInformation == null)
            {
                return HttpNotFound();
            }
            return View(menuItemInformation);
        }

        // POST: MenuItemInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuItemId,Menu_Name,ModuleIcon")] MenuItemInformation menuItemInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuItemInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuItemInformation);
        }

        // GET: MenuItemInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItemInformation menuItemInformation = db.MenuInformations.Find(id);
            if (menuItemInformation == null)
            {
                return HttpNotFound();
            }
            return View(menuItemInformation);
        }

        // POST: MenuItemInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItemInformation menuItemInformation = db.MenuInformations.Find(id);
            db.MenuInformations.Remove(menuItemInformation);
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
