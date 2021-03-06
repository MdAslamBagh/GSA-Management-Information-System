﻿//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Globalization;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
////using Microsoft.AspNet.Identity;
////using Microsoft.AspNet.Identity.Owin;
////using Microsoft.Owin.Security;

//namespace GSA_Management_Information_System.Models
//{
//    public class RegistrationInformationController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();
//        // GET: RegistrationInformation
//        public ActionResult Index()
//        {
//            return View(db.RegistrationInformations.ToList());
//        }

//        // GET: RegistrationInformation/Details/5
//        public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationInformation registrationInformation = db.RegistrationInformations.Find(id);
//            if (registrationInformation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationInformation);
//        }

//        // GET: RegistrationInformation/Create

//        [AllowAnonymous]
//        public ActionResult Create_Account()
//        {
//            //ViewBag.Name = new SelectList(db.RoleInformations.Where(u => !u.Name.Contains("Admin"))
//            //.ToList(), "Name", "Name");
//            //ViewBag.Name = new SelectList(db.RoleInformations.Select(u => u.Name).ToList());
//            return View();
//        }

//        // POST: RegistrationInformation/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create_Account([Bind(Include = "UserRoles,Email,UserName,Password,ConfirmPassword")] RegistrationInformation registrationInformation)
//        {
//            if (ModelState.IsValid)
//            {
//                db.RegistrationInformations.Add(registrationInformation);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(registrationInformation);
//        }



//        // GET: RegistrationInformation/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationInformation registrationInformation = db.RegistrationInformations.Find(id);
//            if (registrationInformation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationInformation);
//        }

//        // POST: RegistrationInformation/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "UserRoles,Email,UserName,Password,ConfirmPassword")] RegistrationInformation registrationInformation)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(registrationInformation).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(registrationInformation);
//        }

//        // GET: RegistrationInformation/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationInformation registrationInformation = db.RegistrationInformations.Find(id);
//            if (registrationInformation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationInformation);
//        }

//        // POST: RegistrationInformation/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            RegistrationInformation registrationInformation = db.RegistrationInformations.Find(id);
//            db.RegistrationInformations.Remove(registrationInformation);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
