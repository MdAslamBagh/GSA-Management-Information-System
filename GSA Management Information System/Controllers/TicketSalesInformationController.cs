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

        public ActionResult GetData()
        {
            List<TicketSalesInformation> Informations = db.TicketSalesInformations.ToList<TicketSalesInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

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
        public ActionResult Create()
        {
            
            List<ExchangeInformation> exchangeInformations = db.ExchangeInformations.Where(a => a.Default_Code == true).ToList<ExchangeInformation>();
            ExchangeInformation exchange = new ExchangeInformation();
            exchange = exchangeInformations.FirstOrDefault();
            string e_Rate = exchange.Exchange_Rate.ToString();
            ViewBag.Exchange_Rate = e_Rate;
            String time = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.Ticket_Date = time;

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
        public ActionResult Create(TicketSalesInformation ticketSalesInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                ticketSalesInformation.Entry_By = LogedInUser;
                ticketSalesInformation.Entry_Date = DateTime.Now;
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
            ViewBag.Ticket_Date = ticketSalesInformation.Ticket_Date;
            if (ticketSalesInformation == null)
            {
                return HttpNotFound();
            }

            //var ticketdata = from cargosales in db.CargoSalesInformations join AirlinesInformation in db.AirlinesInformations on cargosales.air equals AirlinesInformation.Airlines_Code
            //                                                             join freighter in db.FreighterInformations on cargosales.Freighter_Code equals freighter.Freighter_Code
            //                                                         select new {
            //                                                          cargosales.MAWB,
            //                                                          cargosales.Airway_No,
            //                                                          origin.Long_Desc,
            //                                                          Frieghter_Name=freighter.Long_Desc};


            var ticketdata = (from ticketsales in db.TicketSalesInformations
                             join airlines in db.AirlinesInformations on ticketsales.Airlines_Code equals airlines.Airlines_Code
                             join bank in db.BankInformations on ticketsales.Bank_Code equals bank.Bank_Code
                             join customer in db.CustomerInformations on ticketsales.Customer_Code equals customer.Customer_Code
                             join payment in db.PaymentModeInformations on ticketsales.Payment_Mode equals payment.Payment_Mode
                             where ticketsales.TicketSalesId== ticketSalesInformation.TicketSalesId
                              select new 
                             {
                                 TicketSalesId=ticketSalesInformation.TicketSalesId,
                                 Airlines = airlines.Long_Desc,
                                 Bank = bank.Long_Desc,
                                 Customer = customer.Customer_Name,
                                 Payment = payment.Payment_Mode


                             }).FirstOrDefault();


            return View(new TicketSalesViewModel()
            {
                TicketSalesId = Convert.ToInt32(ticketdata.TicketSalesId),              
                Airlines_Name=ticketdata.Airlines,
                Bank_Name = ticketdata.Bank,
                Payment_Name = ticketdata.Customer,
                Customer_Name = ticketdata.Payment,
                Airlines_Code= ticketSalesInformation.Airlines_Code,
                Customer_Code= ticketSalesInformation.Customer_Code,
                Payment_Mode= ticketSalesInformation.Payment_Mode,
                Bank_Code= ticketSalesInformation.Bank_Code,
                Ticket_No= ticketSalesInformation.Ticket_No,
                //Ticket_Date= ticketSalesInformation.Ticket_Date,
                
                Exchange_Rate= ticketSalesInformation.Exchange_Rate,
                Sales_Value_USD= ticketSalesInformation.Sales_Value_USD,
                Sales_Value_BDT= ticketSalesInformation.Sales_Value_BDT,
                Commison=ticketSalesInformation.Commison,
                Commison_Amount= ticketSalesInformation.Commison_Amount,
                Emb_Tax= ticketSalesInformation.Emb_Tax,
                Travel_Tax= ticketSalesInformation.Travel_Tax,
                Fuel_Charge= ticketSalesInformation.Fuel_Charge,
                Hk_Tax= ticketSalesInformation.Hk_Tax,
                Xt_Charge=ticketSalesInformation.Xt_Charge,
                Other_Charge= ticketSalesInformation.Other_Charge,
                Discount= ticketSalesInformation.Discount,
                Net_Receivable_Amount= ticketSalesInformation.Net_Receivable_Amount,
                Received_Amount=ticketSalesInformation.Received_Amount,
                Amount_In_PPRS=ticketSalesInformation.Amount_In_PPRS,
                Remarks=ticketSalesInformation.Remarks
            });
        }

        // POST: TicketSalesInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketSalesInformation ticketSalesInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                ticketSalesInformation.Entry_By = LogedInUser;
                ticketSalesInformation.Entry_Date = DateTime.Now;
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
