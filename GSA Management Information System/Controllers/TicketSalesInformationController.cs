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
    public class TicketSalesInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketSalesInformation
        public ActionResult Index()
        {
            return View(db.TicketSalesInformations.ToList());
        }

        // GET: TicketSalesInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSalesInformation ticketSalesInformation = db.TicketSalesInformations.Find(id);
            if (ticketSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(ticketSalesInformation);
        }

        // GET: TicketSalesInformation/Create
        public ActionResult Add()
        {
            
            List<ExchangeInformation> exchangeInformations = db.ExchangeInformations.Where(a => a.Default_Code == true).ToList<ExchangeInformation>();
            ExchangeInformation exchange = new ExchangeInformation();
            exchange = exchangeInformations.FirstOrDefault();
            string e_Rate = exchange.Exchange_Rate.ToString();
            ViewBag.Exchange_Rate = e_Rate;

            List<TicketSalesInformation> Informations = db.TicketSalesInformations.OrderByDescending(a => a.TicketSalesId).ToList<TicketSalesInformation>();

            try
            {
                TicketSalesInformation information = new TicketSalesInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    TicketSalesInformation objticket = new TicketSalesInformation();
                    int s = objticket.Sales_Slno + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Sales_Slno = s.ToString();
                }
                else
                {
                    int code = information.Sales_Slno + 1;
                    ViewBag.Sales_Slno = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        // POST: TicketSalesInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TicketSalesInformation ticketSalesInformation)
        {
            if (ModelState.IsValid)
            {
                db.TicketSalesInformations.Add(ticketSalesInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketSalesInformation);
        }
        public JsonResult Get_Airlines_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Airlines_Name = (from c in db.AirlinesInformations
                                  where c.Long_Desc.StartsWith(Prefix)
                                  select new { c.Long_Desc });
            return Json(Airlines_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetAirlinesCodeById(string airlinesname)
        {
            var airlines_code = db.AirlinesInformations.Where(m => m.Long_Desc == airlinesname).FirstOrDefault();
            return Json(airlines_code, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Customer_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Customer_Name = (from c in db.CustomerInformations
                                 where c.Customer_Name.StartsWith(Prefix)
                                 select new { c.Customer_Name });
            return Json(Customer_Name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerCodeById(string customername)
        {
            var customer_code = db.CustomerInformations.Where(m => m.Customer_Name == customername).FirstOrDefault();
            return Json(customer_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_payment_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var payment_Name = (from c in db.PaymentModeInformations
                                where c.Long_Desc.StartsWith(Prefix)
                                select new { c.Long_Desc });
            return Json(payment_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetpaymentCodeById(string paymentname)
        {
            var payment_code = db.PaymentModeInformations.Where(m => m.Long_Desc == paymentname).FirstOrDefault();
            return Json(payment_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Bank_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var bank_Name = (from c in db.BankInformations
                                where c.Long_Desc.StartsWith(Prefix)
                                select new { c.Long_Desc });
            return Json(bank_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetBankCodeById(string bankname)
        {
            var bank_code = db.BankInformations.Where(m => m.Long_Desc == bankname).FirstOrDefault();
            return Json(bank_code, JsonRequestBehavior.AllowGet);
        }

        // GET: TicketSalesInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSalesInformation ticketSalesInformation = db.TicketSalesInformations.Find(id);
            if (ticketSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(ticketSalesInformation);
        }

        // POST: TicketSalesInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketSalesId,Sales_Slno,Airlines_Code,Ticket_Date,Ticket_No,Customer_Code,Bank,Exchange_Rate,Sales_Value_USD,Sales_Value_BDT,Commison,Commison_Amount,Emb_Tax,Travel_Tax,Fuel_Charge,Hk_Tax,Xt_Charge,Other_Charge,Net_Receivable_Amount,Received_Amount,Amount_In_PPRS,Remarks")] TicketSalesInformation ticketSalesInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketSalesInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketSalesInformation);
        }

        // GET: TicketSalesInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSalesInformation ticketSalesInformation = db.TicketSalesInformations.Find(id);
            if (ticketSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(ticketSalesInformation);
        }

        // POST: TicketSalesInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketSalesInformation ticketSalesInformation = db.TicketSalesInformations.Find(id);
            db.TicketSalesInformations.Remove(ticketSalesInformation);
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
