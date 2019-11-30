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
    public class CourierInboundSalesInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourierInboundSalesInformation
        public ActionResult Index()
        {
            return View(db.CourierInboundSalesInformations.ToList());
        }
        // GET: CourierInboundSalesInformation/Create
        public ActionResult Add()

        {

            //freighter
            List<FreighterInformation> freighterInformations = db.FreighterInformations.Where(a => a.Default_Code == true).ToList<FreighterInformation>();
            FreighterInformation informations = new FreighterInformation();
            informations = freighterInformations.FirstOrDefault();
            string f_Name = informations.Long_Desc;
            string f_Code = informations.Freighter_Code.ToString();
            ViewBag.Freighter_Name = f_Name;
            ViewBag.Freighter_Code = f_Code;

            //orgin
            List<OriginInformation> originInformations = db.OriginInformations.Where(a => a.Default_Code == true).ToList<OriginInformation>();
            OriginInformation orign = new OriginInformation();
            orign = originInformations.FirstOrDefault();
            string o_Name = orign.Long_Desc;
            string o_Code = orign.Origin_Code;
            ViewBag.Origin_Name = o_Name;
            ViewBag.Origin_Code = o_Code;

            //destination
            List<DestinationInformation> destinationInformations = db.DestinationInformations.Where(a => a.Default_Code == true).ToList<DestinationInformation>();
            DestinationInformation destination = new DestinationInformation();
            destination = destinationInformations.FirstOrDefault();
            string d_Name = destination.Long_Desc;
            string d_Code = destination.Dest_Code;
            ViewBag.Destination_Name = d_Name;
            ViewBag.Destination_Code = d_Code;

            //Continent
            List<ContinentInformation> continentInformations = db.ContinentInformations.Where(a => a.Default_Code == true).ToList<ContinentInformation>();
            ContinentInformation continent = new ContinentInformation();
            continent = continentInformations.FirstOrDefault();
            string ci_Name = continent.Long_Desc;
            string ci_Code = continent.Continent_Code.ToString();
            ViewBag.Continent_Name = ci_Name;
            ViewBag.Continent_Code = ci_Code;

            //Payment mode
            List<PaymentModeInformation> paymentmodeInformations = db.PaymentModeInformations.Where(a => a.Default_Code == true).ToList<PaymentModeInformation>();
            PaymentModeInformation paymentmode = new PaymentModeInformation();
            paymentmode = paymentmodeInformations.FirstOrDefault();
            string pm_Name = paymentmode.Long_Desc;
            string pm_Code = paymentmode.Payment_Code.ToString();
            ViewBag.Payment_Name = pm_Name;
            ViewBag.Payment_Code = pm_Code;

            //Cargo Freight paymode
            List<CargoFreightPaymodeInformation> cfInformations = db.CargoFreightPaymodeInformations.Where(a => a.Default_Code == true).ToList<CargoFreightPaymodeInformation>();
            CargoFreightPaymodeInformation cfpaymode = new CargoFreightPaymodeInformation();
            cfpaymode = cfInformations.FirstOrDefault();
            string cfp_Name = cfpaymode.Long_Desc;
            string cfp_Code = cfpaymode.CFPaymode_Code.ToString();
            ViewBag.Cargofreight_Name = cfp_Name;
            ViewBag.Cargofreight_Code = cfp_Code;

            //Sector
            List<RouteInformation> routeInformations = db.RouteInformations.Where(a => a.Default_Code == true).ToList<RouteInformation>();
            RouteInformation route = new RouteInformation();
            route = routeInformations.FirstOrDefault();
            string r_Name = route.Long_Desc;
            string r_Code = route.Route_Code;
            ViewBag.Route_Name = r_Name;
            ViewBag.Route_Code = r_Code;

            //customer
            List<CustomerInformation> customerInformations = db.CustomerInformations.Where(a => a.Default_Code == true).ToList<CustomerInformation>();
            CustomerInformation customer = new CustomerInformation();
            customer = customerInformations.FirstOrDefault();
            string c_Name = customer.Customer_Name;
            string c_Code = customer.Customer_Code;
            ViewBag.Customer_Name = c_Name;
            ViewBag.Customer_Code = c_Code;

            //cargotype
            List<CargoTypeInformation> cargotypeInformations = db.CargoTypeInformations.Where(a => a.Default_Code == true).ToList<CargoTypeInformation>();
            CargoTypeInformation cargotype = new CargoTypeInformation();
            cargotype = cargotypeInformations.FirstOrDefault();
            string ct_Name = cargotype.Long_Desc;
            string ct_Code = cargotype.Cargo_Code;
            ViewBag.Cargo_Name = ct_Name;
            ViewBag.Cargo_Code = ct_Code;

            //Consoignee

            List<ConsigneeInformation> consigneeInformations = db.ConsigneeInformations.Where(a => a.Default_Code == true).ToList<ConsigneeInformation>();
            ConsigneeInformation consignee = new ConsigneeInformation();
            consignee = consigneeInformations.FirstOrDefault();
            string cn_Name = consignee.Consignee_Name;
            string cn_Code = consignee.Consignee_Code;
            ViewBag.Consignee_Name = cn_Name;
            ViewBag.Consignee_Code = cn_Code;


            //Consignor
            List<ConsignorInformation> consignorInformations = db.ConsignorInformations.Where(a => a.Default_Code == true).ToList<ConsignorInformation>();
            ConsignorInformation consignor = new ConsignorInformation();
            consignor = consignorInformations.FirstOrDefault();
            string con_Name = consignor.Consignor_Name;
            string con_Code = consignor.Consignor_Code;
            ViewBag.Consignor_Name = con_Name;
            ViewBag.Consignor_Code = con_Code;

            List<UplimentTypeInformation> uplimentInformations = db.UplimentTypeInformations.Where(a => a.Default_Code == true).ToList<UplimentTypeInformation>();
            UplimentTypeInformation upliment = new UplimentTypeInformation();
            upliment = uplimentInformations.FirstOrDefault();
            string U_Name = upliment.Long_Desc;
            string U_Code = upliment.UType_Code.ToString();
            ViewBag.Upliment_Name = U_Name;
            ViewBag.Upliment_Code = U_Code;

            //  exchange rate
            List<ExchangeInformation> exchangeInformations = db.ExchangeInformations.Where(a => a.Default_Code == true).ToList<ExchangeInformation>();
            ExchangeInformation exchange = new ExchangeInformation();
            exchange = exchangeInformations.FirstOrDefault();
            string e_Rate = exchange.Exchange_Rate.ToString();
            ViewBag.Exchange_Rate = e_Rate;
            return View();


            return View();
        }

        // POST: CourierInboundSalesInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CourierInboundSalesInformation courierInboundSalesInformation)
        {
            if (ModelState.IsValid)
            {
                courierInboundSalesInformation.Airway_No = courierInboundSalesInformation.MAWB + courierInboundSalesInformation.Check_Digit;
                StockIssueDetailInformations stockIssueDetailInformations = new StockIssueDetailInformations();
                stockIssueDetailInformations = db.StockIssueDetailInformations.Where(a => a.Ticket_No.ToString() == courierInboundSalesInformation.MAWB).FirstOrDefault();
                db.CourierInboundSalesInformations.Attach(courierInboundSalesInformation);
                stockIssueDetailInformations.Status = "Sold";
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courierInboundSalesInformation);
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult Get_Consignor_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Consignor_Name = (from c in db.ConsignorInformations
                               where c.Consignor_Name.StartsWith(Prefix)
                               select new {c.Consignor_Name,c.Consignor_Code,c.Consignor_Address });
            return Json(Consignor_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetConsignorCodeById(string consignorname)
        {

            var consignor_code = db.ConsignorInformations.Where(m => m.Consignor_Name == consignorname).FirstOrDefault();
            return Json(consignor_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Consignee_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Consignee_Name = (from c in db.ConsigneeInformations
                                  where c.Consignee_Name.StartsWith(Prefix)
                                  select new { c.Consignee_Name});
            return Json(Consignee_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetConsigneeCodeById(string consigneename)
        {
            var consignee_code = db.ConsigneeInformations.Where(m => m.Consignee_Name == consigneename).FirstOrDefault();
            return Json(consignee_code, JsonRequestBehavior.AllowGet);
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


        public JsonResult Get_Origin_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Origin_Name = (from c in db.OriginInformations
                                 where c.Long_Desc.StartsWith(Prefix)
                                 select new { c.Long_Desc });
            return Json(Origin_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetOriginCodeById(string originname)
       {          
            var origin_code = db.OriginInformations.Where(m => m.Long_Desc == originname).FirstOrDefault();
            return Json(origin_code, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Destination_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Destination_Name = (from c in db.DestinationInformations
                               where c.Long_Desc.StartsWith(Prefix)
                               select new { c.Long_Desc });
            return Json(Destination_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetDestinationCodeById(string destinationname)
        {
            var destination_code = db.DestinationInformations.Where(m => m.Long_Desc == destinationname).FirstOrDefault();
            return Json(destination_code, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Continent_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Continent_Name = (from c in db.ContinentInformations
                                    where c.Long_Desc.StartsWith(Prefix)
                                    select new { c.Long_Desc });
            return Json(Continent_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetContinentCodeById(string continentname)
        {
            var continent_code = db.ContinentInformations.Where(m => m.Long_Desc == continentname).FirstOrDefault();
            return Json(continent_code, JsonRequestBehavior.AllowGet);
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
     
        public JsonResult Get_CargoType_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var CargoType_Name = (from c in db.CargoTypeInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(CargoType_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetcargotypeCodeById(string cargotype_Name)
        {
            var cargotypecode = db.CargoTypeInformations.Where(m => m.Long_Desc == cargotype_Name).FirstOrDefault();
            return Json(cargotypecode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_UplimentType_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var UplimentType_Name = (from c in db.UplimentTypeInformations
                                  where c.Long_Desc.StartsWith(Prefix)
                                  select new { c.Long_Desc });
            return Json(UplimentType_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetuplimenttypeCodeById(string uplimenttype_Name)
        {
            var uplimenttypecode = db.UplimentTypeInformations.Where(m => m.Long_Desc == uplimenttype_Name).FirstOrDefault();
            return Json(uplimenttypecode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Freighter_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Freighter_Name = (from c in db.FreighterInformations
                                     where c.Long_Desc.StartsWith(Prefix)
                                     select new { c.Long_Desc });
            return Json(Freighter_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetfreighterCodeById(string freightername)
        {
            var freightercode = db.FreighterInformations.Where(m => m.Long_Desc == freightername).FirstOrDefault();
            return Json(freightercode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Route_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Route_Name = (from c in db.RouteInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(Route_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetrouteCodeById(string sectorname)
        {
            var route_code = db.RouteInformations.Where(m => m.Long_Desc == sectorname).FirstOrDefault();
            return Json(route_code, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Get_CFpaymode_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var CFpaymode_Name = (from c in db.CargoFreightPaymodeInformations
                              where c.Long_Desc.StartsWith(Prefix)
                              select new { c.Long_Desc });
            return Json(CFpaymode_Name, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCFpaymodeById(string cfpaymodename)
        {
            var cf_code = db.CargoFreightPaymodeInformations.Where(m => m.Long_Desc == cfpaymodename).FirstOrDefault();
            return Json(cf_code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_MAWB(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var MAWB = (from c in db.StockIssueDetailInformations
                               where c.Ticket_No.ToString().StartsWith(Prefix)
                        select new { c.Ticket_No });
            return Json(MAWB, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetMAWBCodeById(int mawbcode)
        {
            //var mawb_code = (from o in db.StockIssueDetailInformations
              //            where o.Ticket_No == mawbcode
                                 
                //          select o.Ticket_No).FirstOrDefault();

            var mawb_code = (from StockIssueDetailInformation in db.StockIssueDetailInformations
                         join StockIssueInformation in db.StockIssueInformations on StockIssueDetailInformation.SIssued_Code equals StockIssueInformation.SIssued_Code
                             join AirlinesInformation in db.AirlinesInformations on StockIssueInformation.Airlines_Code equals AirlinesInformation.Airlines_Code
                         where StockIssueDetailInformation.Ticket_No==mawbcode select new
             {
                             Ticket_No = StockIssueDetailInformation.Ticket_No,
                             SIssued_Code = StockIssueDetailInformation.SIssued_Code,
                             Airlines_Code = StockIssueInformation.Airlines_Code,
                             Long_Desc = AirlinesInformation.Long_Desc

                         }).FirstOrDefault();


            //var mawb_code = db.StockIssueDetailInformations.Where(m => m.Ticket_No == mawbcode).FirstOrDefault();
            return Json(mawb_code, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetReceivedCodeById(string srecieved_Code)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();
            //StockRecieveInformation informationss = new StockRecieveInformation();
            //informationss.Ticket_Quantity = informationss.Ticket_Quantity.valu
            var receivedcode = db.StockRecieveInformations.Where(m => m.SRecieved_Code == srecieved_Code).FirstOrDefault();

            return Json(receivedcode, JsonRequestBehavior.AllowGet);

        }

        // GET: CourierInboundSalesInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourierInboundSalesInformation courierInboundSalesInformation = db.CourierInboundSalesInformations.Find(id);
            if (courierInboundSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(courierInboundSalesInformation);
        }

     

        // GET: CourierInboundSalesInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourierInboundSalesInformation courierInboundSalesInformation = db.CourierInboundSalesInformations.Find(id);
            if (courierInboundSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(courierInboundSalesInformation);
        }

        // POST: CourierInboundSalesInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Slno,Invoice_Type,MAWB,Check_Digit,Flight_Date,Airway_No,Freighter,Origin_Code,Dest_Code,Continent_Code,PaymentMode_Code,CFPaymode_Code,Route_Code,Customer_Code,Cargo_Code,UType_Code,HBL_Qty,AMS,Gross_Weight,Chargeable_Weight,Rate_Charge,B_Rate,Agent_Commission,AIT,THC,SSC,FSC_Charge,ISS_Charge,HDS,Others,Consignee_Code,Consignor_Code,Receivable_From_Agent,Remarks,Currency,Exchange_Rate,Receivable_Amount_BDT,Payable_Agent_CC,Remarks_B_Bank,Entry_Date")] CourierInboundSalesInformation courierInboundSalesInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courierInboundSalesInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courierInboundSalesInformation);
        }

        // GET: CourierInboundSalesInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourierInboundSalesInformation courierInboundSalesInformation = db.CourierInboundSalesInformations.Find(id);
            if (courierInboundSalesInformation == null)
            {
                return HttpNotFound();
            }
            return View(courierInboundSalesInformation);
        }

        // POST: CourierInboundSalesInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourierInboundSalesInformation courierInboundSalesInformation = db.CourierInboundSalesInformations.Find(id);
            db.CourierInboundSalesInformations.Remove(courierInboundSalesInformation);
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
