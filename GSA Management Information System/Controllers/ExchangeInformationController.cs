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
    public class ExchangeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExchangeInformation
        public ActionResult Index()
        {
            return View(db.ExchangeInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<ExchangeInformation> Informations = db.ExchangeInformations.ToList<ExchangeInformation>();
            return Json(new { data =Informations }, JsonRequestBehavior.AllowGet);

        }


        // GET: ExchangeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeInformation exchangeInformation = db.ExchangeInformations.Find(id);
            if (exchangeInformation == null)
            {
                return HttpNotFound();
            }
            return View(exchangeInformation);
        }

        // GET: ExchangeInformation/Create
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Currency_Code = new SelectList(db.CurrencyInformations, "Currency_Code", "Long_Desc");
            return View();
        }

        // POST: ExchangeInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ExchangeId,Currency_Code,Long_Desc,Exchange_Rate,Status,Default_Code,Entry_Date")] ExchangeInformation exchangeInformation)
        {
            
            //objconsignee = Informations.FirstOrDefault();
            //ViewBag.ConsignorCode = information.Consignor_Code + 1;
            //int code = objconsignee.Consignee_Code + 1;
           // exchangeInformation.Exchange_Code = ViewBag.Currency_Code;//.PadLeft(4,

            if (ModelState.IsValid)
            {
                db.ExchangeInformations.Add(exchangeInformation);
                var exchangeList = db.ExchangeInformations.Where(a => a.ExchangeId != exchangeInformation.ExchangeId).ToList();

                foreach (var item in exchangeList)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exchangeInformation);
        }

        // GET: ExchangeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeInformation exchangeInformation = db.ExchangeInformations.Find(id);
            if (exchangeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Currency_Code = new SelectList(db.CurrencyInformations, "Currency_Code", "Long_Desc");
            return View(exchangeInformation);
        }

        // POST: ExchangeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExchangeId,Currency_Code,Long_Desc,Exchange_Rate,Status,Default_Code,Entry_Date")] ExchangeInformation exchangeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangeInformation).State = EntityState.Modified;
                var list = db.ExchangeInformations.Where(a => a.ExchangeId != exchangeInformation.ExchangeId).ToList();
                foreach (var item in list)
                {
                    item.Default_Code = false;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exchangeInformation);
        }

        // GET: ExchangeInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ExchangeInformation Informations = db.ExchangeInformations.Where(x => x.ExchangeId == id).FirstOrDefault<ExchangeInformation>();
                db.ExchangeInformations.Remove(Informations);
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
