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
    public class CurrencyInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CurrencyInformation
        public ActionResult Index()
        {
            return View(db.CurrencyInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<CurrencyInformation> CurrencyInformations = db.CurrencyInformations.ToList<CurrencyInformation>();
            return Json(new { data = CurrencyInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Add(CurrencyInformation CurrencyInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.CurrencyInformations.Add(CurrencyInformation);
                db.SaveChanges();
                //ViewBag.Message = "Currency Saved Successfully.";
                return RedirectToAction("Index");
                
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CurrencyInformation);

        }


        // GET: CurrencyInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyInformation currencyInformation = db.CurrencyInformations.Find(id);
            if (currencyInformation == null)
            {
                return HttpNotFound();
            }
            return View(currencyInformation);
        }

        // GET: CurrencyInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrencyId,Currency_Code,Long_Desc,Short_Desc,Status,Default_Code,Entry_Date")] CurrencyInformation currencyInformation)
        {
            if (ModelState.IsValid)
            {
                db.CurrencyInformations.Add(currencyInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyInformation);
        }

        // GET: CurrencyInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyInformation currencyInformation = db.CurrencyInformations.Find(id);
            if (currencyInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(currencyInformation);
        }

        // POST: CurrencyInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrencyId,Currency_Code,Long_Desc,Short_Desc,Status,Default_Code,Entry_Date")] CurrencyInformation currencyInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currencyInformation).State = EntityState.Modified;
                var list = db.CurrencyInformations.Where(a => a.Currency_Code != currencyInformation.Currency_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyInformation);
        }

        // GET: CurrencyInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CurrencyInformation CurrencyInformations = db.CurrencyInformations.Where(x => x.CurrencyId == id).FirstOrDefault<CurrencyInformation>();
                db.CurrencyInformations.Remove(CurrencyInformations);
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
