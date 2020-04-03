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
    public class PaymentModeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentModeInformation
        public ActionResult Index()
        {
            return View(db.PaymentModeInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<PaymentModeInformation> PaymentModeInformations = db.PaymentModeInformations.ToList<PaymentModeInformation>();
            return Json(new { data = PaymentModeInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            ////String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            List<PaymentModeInformation> Informations = db.PaymentModeInformations.OrderByDescending(a => a.PaymentModeId).ToList<PaymentModeInformation>();

      
                PaymentModeInformation information = new PaymentModeInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    PaymentModeInformation objpayment = new PaymentModeInformation();
                    int s = objpayment.Payment_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Payment_Code = s.ToString();
                }
                else
                {
                    int code = information.Payment_Code + 1;
                    ViewBag.Payment_Code = code.ToString();//.PadLeft(4, '0');
                }
         

            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentModeInformation PaymentModeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                PaymentModeInformation.Entry_By = LogedInUser;
                PaymentModeInformation.Entry_Date = DateTime.Now;
                db.PaymentModeInformations.Add(PaymentModeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(PaymentModeInformation);

        }

        // GET: PaymentModeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModeInformation paymentModeInformation = db.PaymentModeInformations.Find(id);
            if (paymentModeInformation == null)
            {
                return HttpNotFound();
            }
            return View(paymentModeInformation);
        }

        // GET: PaymentModeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModeInformation paymentModeInformation = db.PaymentModeInformations.Find(id);
            if (paymentModeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(paymentModeInformation);
        }

        // POST: PaymentModeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentModeInformation paymentModeInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                paymentModeInformation.Entry_By = LogedInUser;
                paymentModeInformation.Entry_Date = DateTime.Now;
                db.Entry(paymentModeInformation).State = EntityState.Modified;
                var list = db.PaymentModeInformations.Where(a => a.Payment_Code != paymentModeInformation.Payment_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentModeInformation);
        }

        // GET: PaymentModeInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                PaymentModeInformation PaymentModeInformations = db.PaymentModeInformations.Where(x => x.PaymentModeId == id).FirstOrDefault<PaymentModeInformation>();
                db.PaymentModeInformations.Remove(PaymentModeInformations);
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
