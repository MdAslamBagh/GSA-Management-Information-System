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
    public class StockTypeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockTypeInformation
        public ActionResult Index()
        {
            return View(db.StockTypeInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<StockTypeInformation> StockTypeInformations = db.StockTypeInformations.ToList<StockTypeInformation>();
            return Json(new { data = StockTypeInformations }, JsonRequestBehavior.AllowGet);

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
        public ActionResult Add(StockTypeInformation StockTypeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.StockTypeInformations.Add(StockTypeInformation);

                if (StockTypeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var stockTypeList = db.StockTypeInformations.Where(a => a.SType_Code != StockTypeInformation.SType_Code).ToList();

                    foreach (var item in stockTypeList)
                    {
                        item.Default_Code = false;

                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View(StockTypeInformation);

        }


        // GET: StockTypeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTypeInformation stockTypeInformation = db.StockTypeInformations.Find(id);
            if (stockTypeInformation == null)
            {
                return HttpNotFound();
            }
            return View(stockTypeInformation);
        }

        // GET: StockTypeInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockTypeInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STypeId,SType_Code,Long_Desc,Short_Desc,Status,Default_Code,Entry_Date")] StockTypeInformation stockTypeInformation)
        {
            if (ModelState.IsValid)
            {
                db.StockTypeInformations.Add(stockTypeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockTypeInformation);
        }

        // GET: StockTypeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockTypeInformation stockTypeInformation = db.StockTypeInformations.Find(id);
            if (stockTypeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(stockTypeInformation);
        }

        // POST: StockTypeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STypeId,SType_Code,Long_Desc,Short_Desc,Status,Default_Code,Entry_Date")] StockTypeInformation stockTypeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockTypeInformation).State = EntityState.Modified;
                var list = db.StockTypeInformations.Where(a => a.SType_Code != stockTypeInformation.SType_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockTypeInformation);
        }

        // GET: StockTypeInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                StockTypeInformation StockTypeInformations = db.StockTypeInformations.Where(x => x.STypeId == id).FirstOrDefault<StockTypeInformation>();
                db.StockTypeInformations.Remove(StockTypeInformations);
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
