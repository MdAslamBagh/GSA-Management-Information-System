﻿using System;
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
    public class CountryInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CountryInformation
        public ActionResult Index()
        {
            return View(db.CountryInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<CountryInformation> Informations = db.CountryInformations.ToList<CountryInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: CountryInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryInformation countryInformation = db.CountryInformations.Find(id);
            if (countryInformation == null)
            {
                return HttpNotFound();
            }
            return View(countryInformation);
        }

        // GET: CountryInformation/Create
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            return View();
        }

        // POST: CountryInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "CountryId,Continent_Code,Country_Code,Long_Desc,Status,Default_Code,Entry_Date")] CountryInformation countryInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {


                db.CountryInformations.Add(countryInformation);
                if (countryInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var countrylist = db.CountryInformations.Where(a => a.Country_Code != countryInformation.Country_Code).ToList();

                    foreach (var item in countrylist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryInformation);
        }

        // GET: CountryInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryInformation countryInformation = db.CountryInformations.Find(id);
            if (countryInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            return View(countryInformation);
        }

        // POST: CountryInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,Continent_Code,Country_Code,Long_Desc,Status,Default_Code,Entry_Date")] CountryInformation countryInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryInformation).State = EntityState.Modified;
                var list = db.CountryInformations.Where(a => a.Country_Code != countryInformation.Country_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryInformation);
        }

        // GET: CountryInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CountryInformation Informations = db.CountryInformations.Where(x => x.CountryId == id).FirstOrDefault<CountryInformation>();
                db.CountryInformations.Remove(Informations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


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