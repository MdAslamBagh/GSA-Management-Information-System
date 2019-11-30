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
            List<DestinationInformation> Informations = db.DestinationInformations.ToList<DestinationInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

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
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View();
        }

        // POST: DestinationInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "DestinationId,Continent_Code,Country_Code,Dest_Code,Long_Desc,Status,Default_Code,Entry_Date")] DestinationInformation destinationInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
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
            ViewBag.Continent_Code = new SelectList(db.ContinentInformations, "Continent_Code", "Long_Desc");
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View(destinationInformation);
        }

        // POST: DestinationInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinationId,Continent_Code,Country_Code,Dest_Code,Long_Desc,Status,Default_Code,Entry_Date")] DestinationInformation destinationInformation)
        {
            if (ModelState.IsValid)
            {
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
