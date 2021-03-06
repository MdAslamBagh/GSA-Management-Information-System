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
    public class DestinationInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DestinationInformation
        public ActionResult Index()
        {
            return View(db.DestinationInformations.ToList());
        }
        public ActionResult GetData()
        {
            var Informations = from destination in db.DestinationInformations join region in db.ContinentInformations on destination.Continent_Code equals region.Continent_Code join country in db.CountryInformations on
                               destination.Country_Code equals country.Country_Code select new {
                                   destination.DestinationId,
                                   Region=region.Long_Desc,
                                   Country=country.Long_Desc, destination.Dest_Code, destination.Long_Desc, destination.Status, destination.Default_Code};
            //var s = submenulist.ToList();
            // List<SubMenuInformation> sebmenu = db.SubMenuInformations.ToList<SubMenuInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);
            //List<DestinationInformation> Informations = db.DestinationInformations.ToList<DestinationInformation>();
            //return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: DestinationInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationInformation destinationInformation = db.DestinationInformations.Find(id);
            if (destinationInformation == null)
            {
                return HttpNotFound();
            }
            return View(destinationInformation);
        }

        // GET: DestinationInformation/Create
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
          //  ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            //ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            ViewBag.ContinentList = (db.ContinentInformations.Where(a => a.Continent_Code ==a.Continent_Code).ToList());
            //ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View();
        }

        // POST: DestinationInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DestinationInformation destinationInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            var LogedInUser = User.Identity.Name;
            destinationInformation.Entry_By = LogedInUser;
            destinationInformation.Entry_Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.DestinationInformations.Add(destinationInformation);
                if (destinationInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var destinationList = db.DestinationInformations.Where(a => a.Dest_Code != destinationInformation.Dest_Code).ToList();

                    foreach (var item in destinationList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinationInformation);
        }

        public JsonResult Get_Country(int region)
        {

            //Report Name Must be Database Name
            var country = (from c in db.CountryInformations.Where(a => a.Continent_Code == region)
                           select new
                           {
                               c.Country_Code,
                               CountryName=c.Long_Desc,
                           }).ToList();
            return Json(country, JsonRequestBehavior.AllowGet);
            //var country = db.CountryInformations.Where(a => a.Continent_Code == region).ToList(); //Report Name Must be Database Name
            ////return Json(Informations, JsonRequestBehavior.AllowGet);
            //return Json(country, JsonRequestBehavior.AllowGet);
          

        }

        // GET: DestinationInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationInformation destinationInformation = db.DestinationInformations.Find(id);
            if (destinationInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.ContinentList = (db.ContinentInformations.Where(a => a.Continent_Code == a.Continent_Code).ToList());

            //ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View(destinationInformation);
        }

        // POST: DestinationInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DestinationInformation destinationInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                destinationInformation.Entry_By = LogedInUser;
                destinationInformation.Entry_Date = DateTime.Now;

                db.Entry(destinationInformation).State = EntityState.Modified;
                var list = db.DestinationInformations.Where(a => a.Dest_Code != destinationInformation.Dest_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinationInformation);
        }

        // GET: DestinationInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                DestinationInformation Informations = db.DestinationInformations.Where(x => x.DestinationId == id).FirstOrDefault<DestinationInformation>();
                db.DestinationInformations.Remove(Informations);
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
