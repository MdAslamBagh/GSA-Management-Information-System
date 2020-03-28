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
    public class CargoDueReceiptController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargoDueReceipt
        public ActionResult Index()
        {
            return View(db.CargoDueReceipts.ToList());
        }

        public ActionResult GetData()
        {
            List<CargoDueReceipt> Informations = db.CargoDueReceipts.ToList<CargoDueReceipt>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: CargoDueReceipt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoDueReceipt cargoDueReceipt = db.CargoDueReceipts.Find(id);
            if (cargoDueReceipt == null)
            {
                return HttpNotFound();
            }
            return View(cargoDueReceipt);
        }


        public JsonResult GetAirwayById(string airway)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();
            //StockRecieveInformation informationss = new StockRecieveInformation();
            //informationss.Ticket_Quantity = informationss.Ticket_Quantity.valu
            var receiptfreightcharge = db.CargoDueReceipts.Where(m => m.Airway_No == airway).ToList();

            if (receiptfreightcharge.Count == 0)
            {

                var totalfreight = (from cargo in db.CargoSalesInformations
                                          where cargo.Airway_No == airway
                                          select new
                                          {
                                              TotalFreightCharge = ((cargo.Chargeable_Weight * cargo.B_Rate) + (cargo.THC + cargo.SSC + cargo.FSC_Charge + cargo.ISS_Charge + cargo.AMS)),
                                              Airway_No = cargo.Airway_No,

                                              //as [TotalFreightCharge]
                                          }).FirstOrDefault();

                return Json(totalfreight, JsonRequestBehavior.AllowGet);

            }


            float Receiptquantity = 0;

            foreach (var item in receiptfreightcharge)
            {

                Receiptquantity += item.Receipt_Amount;


            }

            var totalfreightcharge = (from cargo in db.CargoSalesInformations
                                          where cargo.Airway_No == airway
                                          select new
                                          {
                                              TotalFreightCharge = (((cargo.Chargeable_Weight * cargo.B_Rate) + (cargo.THC + cargo.SSC + cargo.FSC_Charge + cargo.ISS_Charge + cargo.AMS))- Receiptquantity),
                                              Airway_No = cargo.Airway_No,

                                              //as [TotalFreightCharge]
                                          }).FirstOrDefault();

            
            return Json(totalfreightcharge, JsonRequestBehavior.AllowGet);


            //totalleftquantity += receivedcode.Ticket_Quantity - item.Ticket_Quantity;





        }
        // GET: CargoDueReceipt/Create
        public ActionResult Create()
        {

            List<CargoDueReceipt> Informations = db.CargoDueReceipts.OrderByDescending(a => a.SalesSlno).ToList<CargoDueReceipt>();

            try
            {
                CargoDueReceipt information = new CargoDueReceipt();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    CargoDueReceipt objinformations = new CargoDueReceipt();
                    int s = objinformations.SalesSlno + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.SalesSlno = s.ToString();
                }
                else
                {
                    int code = information.SalesSlno + 1;
                    ViewBag.SalesSlno = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }





            try
            {

                CargoDueReceipt information = new CargoDueReceipt();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    string todaydate = DateTime.Now.ToString("yyMM");
                    int seq = 1;
                    string ss = string.Format("REC-{0}-{1}", todaydate, seq.ToString("D5"));

                    ViewBag.Receipt_No = ss;

                    //ConsigneeInformation objinformations = new ConsigneeInformation();
                    //int s = objinformations.Consignee_Code + 1;
                    ////ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    //ViewBag.Consignee_Code = s.ToString();
                }
                else
                {
                    CargoDueReceipt informations = new CargoDueReceipt();

                    information = Informations.FirstOrDefault();
                    string code = information.Receipt_No;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 5);
                    int codeee = Int32.Parse(mystring) + 1;
                    string todaydate = DateTime.Now.ToString("yyMM");

                    string ss = string.Format("REC-{0}-{1}", todaydate, codeee.ToString("D5"));

                    ViewBag.Receipt_No = ss;
                    //ViewBag.Consignee_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }




            var DocumentType = new List<string>() { "EXP", "ENC" };
            ViewBag.DocumentType = DocumentType;

            String time = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.Receipt_Date = time;

            String fromtime = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.From_Date = fromtime;
            String totime = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.To_Date = totime;
            return View();
        }

        public JsonResult Get_Customer_Name(string Prefix,DateTime fromdate, DateTime todate)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //var Customer_Name = (from cargo in db.CargoSalesInformations join customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
            //                     where customer.Customer_Name.StartsWith(Prefix)
            //                     select new { customer.Customer_Name });

            //var ccc = (from cargo in db.CargoSalesInformations
            //           join
            //           customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
            //           select new { customer.Customer_Name }).ToList();

            var Customer_Name = (from cargo in db.CargoSalesInformations
                                 join
                                 customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
                                 where customer.Customer_Name.StartsWith(Prefix) &&
                                (cargo.Entry_Date >= fromdate && cargo.Entry_Date <= todate)
                                 select new { customer.Customer_Name,customer.Customer_Code }).ToList();



            //            var Customer_Name = (from cargo in db.CargoSalesInformations
            //                                 join
            //customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
            //                                 where customer.Customer_Name.StartsWith(Prefix)

            //                                 select new { customer.Customer_Name });
                      return Json(Customer_Name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerCodeById(string customername,DateTime fromdate, DateTime todate)
        {
            // var customer_code = (from cargo in db.CargoSalesInformations join customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code.Where customer.Customer_Name == customername;
            //var customer_code = (from cargo in db.CargoSalesInformations join customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
            //Where (customer.Customer_Name == customername).FirstOrDefault();
            //var customer_code = db.CustomerInformations.Where(m => m.Customer_Name == customername).FirstOrDefault();

            var customer_code = (from cargo in db.CargoSalesInformations
                                 join
                                 customer in db.CustomerInformations on cargo.Customer_Code equals customer.Customer_Code
                                 where customer.Customer_Name==customername &&
                                  (cargo.Entry_Date >= fromdate && cargo.Entry_Date <= todate)
                                 select new { cargo.Airway_No,customer.Customer_Code}).ToList();


            return Json(customer_code, JsonRequestBehavior.AllowGet);
        }


        // POST: CargoDueReceipt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CargoDueReceipt cargoDueReceipt)
        {
            if (!ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                cargoDueReceipt.Entry_By = LogedInUser;
                cargoDueReceipt.Entry_Date = DateTime.Now;
                db.CargoDueReceipts.Add(cargoDueReceipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargoDueReceipt);
        }

        // GET: CargoDueReceipt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoDueReceipt cargoDueReceipt = db.CargoDueReceipts.Find(id);
            if (cargoDueReceipt == null)
            {
                return HttpNotFound();
            }
            return View(cargoDueReceipt);
        }

        // POST: CargoDueReceipt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargoDueReceipt cargoDueReceipt)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                cargoDueReceipt.Entry_By = LogedInUser;
                cargoDueReceipt.Entry_Date = DateTime.Now;
                db.CargoDueReceipts.Add(cargoDueReceipt);
                db.Entry(cargoDueReceipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargoDueReceipt);
        }

        // GET: CargoDueReceipt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoDueReceipt cargoDueReceipt = db.CargoDueReceipts.Find(id);
            if (cargoDueReceipt == null)
            {
                return HttpNotFound();
            }
            return View(cargoDueReceipt);
        }

        // POST: CargoDueReceipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CargoDueReceipt cargoDueReceipt = db.CargoDueReceipts.Find(id);
            db.CargoDueReceipts.Remove(cargoDueReceipt);
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
