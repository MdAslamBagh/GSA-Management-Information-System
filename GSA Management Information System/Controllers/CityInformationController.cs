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
    public class CityInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CityInformation
        public ActionResult Index()
        {
            return View(db.CityInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<CityInformation> Informations = db.CityInformations.ToList<CityInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: CityInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityInformation cityInformation = db.CityInformations.Find(id);
            if (cityInformation == null)
            {
                return HttpNotFound();
            }
            return View(cityInformation);
        }

        // GET: CityInformation/Create
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View();
        }

        // POST: CityInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "CityId,City_Code,Long_Desc,Country_Code,Status,Default_Code,Entry_Date")] CityInformation cityInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {


                //var defaulltcode = db.CityInformations.Where(a => a.Default_Code).ToList();
                //foreach(var item in defaulltcode)
                //{
                //    item.Default_Code = false;
                //}

                db.CityInformations.Add(cityInformation);
                if (cityInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var cityList = db.CityInformations.Where(a => a.City_Code != cityInformation.City_Code).ToList();

                    foreach (var item in cityList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityInformation);
        }

        // GET: CityInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityInformation cityInformation = db.CityInformations.Find(id);
            if (cityInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            return View(cityInformation);
        }

        // POST: CityInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,City_Code,Long_Desc,Country_Code,Status,Default_Code,Entry_Date")] CityInformation cityInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityInformation).State = EntityState.Modified;

                var list = db.CityInformations.Where(a => a.City_Code != cityInformation.City_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityInformation);
        }

        // GET: CityInformation/Delete/5


        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CityInformation Informations = db.CityInformations.Where(x => x.CityId == id).FirstOrDefault<CityInformation>();
                db.CityInformations.Remove(Informations);
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
