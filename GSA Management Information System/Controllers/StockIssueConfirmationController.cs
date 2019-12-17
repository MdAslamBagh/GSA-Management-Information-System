using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GSA_Management_Information_System.Models
{
    public class StockIssueConfirmationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockIssueConfirmation
        public ActionResult Index()
        {
            return View(db.StockIssueConfirmations.ToList());
        }

        // GET: StockIssueConfirmation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueConfirmation stockIssueConfirmation = db.StockIssueConfirmations.Find(id);
            if (stockIssueConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueConfirmation);
        }

        public JsonResult GetReceivedCodeById(string sissued_Code)
        {
            //List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();
            //StockRecieveInformation informationss = new StockRecieveInformation();
            //informationss.Ticket_Quantity = informationss.Ticket_Quantity.valu
            var receivedcode = db.StockIssueInformations.Where(m => m.SIssued_Code == sissued_Code).FirstOrDefault();

            //ViewBag.Status = receivedcode.Ticket_Quantity;

            //ViewBag.Transaction_Status = "Issued";
            return Json(receivedcode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIssue_Code(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Issued_Code = (from c in db.StockIssueInformations
                                 where c.SIssued_Code.StartsWith(Prefix) && c.Confirm_Status == "No"
                                 select new { c.SIssued_Code});
            return Json(Issued_Code, JsonRequestBehavior.AllowGet);

            //var Countries = db.CustomerInformations.Select(x => x.Customer_Name).ToList();
            //return Json(Countries, JsonRequestBehavior.AllowGet);
        }





        // GET: StockIssueConfirmation/Create
        public ActionResult Create()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Confirm_Date = today;
            //ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations.Where(a => a.Default_Code == true), "Airlines_Code", "Long_Desc");
            return View();
        }

        // POST: StockIssueConfirmation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CIssueId,SIssued_Code,Airlines_Code,From_TicketNo,To_TicketNo,Ticket_Quantity,Customer_Code,Remarks,Status,Confirm_Date")] StockIssueConfirmation stockIssueConfirmation)
        {
            if (ModelState.IsValid)
            {

                if (stockIssueConfirmation.Status == "Confirmed")
                {
                    StockIssueInformation stockIssueInformation = new StockIssueInformation();
                    stockIssueInformation = db.StockIssueInformations.Where(a => a.SIssued_Code == stockIssueConfirmation.SIssued_Code).FirstOrDefault();
                    if (stockIssueConfirmation.SIssued_Code == stockIssueInformation.SIssued_Code)
                    {
                        db.StockIssueInformations.Attach(stockIssueInformation);
                        stockIssueInformation.Confirm_Status = stockIssueConfirmation.Status;

                        //db.StockRecieveInformations.Attach(stockRecieveInformation);
                        db.SaveChanges();
                    }
                }




 //StockIssueDetailInformations stockIssueDetailInformations = new StockIssueDetailInformations();
                    var stockIssueDetailInformation = db.StockIssueDetailInformations.Where(a => a.SIssued_Code == stockIssueConfirmation.SIssued_Code).ToList();                    
                    foreach (var item in stockIssueDetailInformation)
                    {
                        StockIssueDetailInformations stockIssueDetailInformations = item;
                      
                        db.StockIssueDetailInformations.Attach(stockIssueDetailInformations);
                        stockIssueDetailInformations.SIssued_Code = item.SIssued_Code;
                        stockIssueDetailInformations.Ticket_No = item.Ticket_No;
                        stockIssueDetailInformations.Status = stockIssueConfirmation.Status;

                        //stockIssueDetailInformations.SDetailsId = 1;

                        db.SaveChanges();
                    
                }


                //StockIssueDetailInformations stockDetails = new StockIssueDetailInformations();
                //stockDetails = db.StockIssueDetailInformations.Where(a => a.SIssued_Code == stockIssueConfirmation.SIssued_Code).FirstOrDefault();

                //for()
                //foreach(var item in stockDetails)
                //{
                //    item.Status = "Confirmed";


                //        db.StockIssueDetailInformations.Attach(stockDetails);
                //        stockDetails.Status = item.Status;

                //        //db.StockRecieveInformations.Attach(stockRecieveInformation);
                //        db.SaveChanges();


                //}

                db.StockIssueConfirmations.Add(stockIssueConfirmation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockIssueConfirmation);
        }

        // GET: StockIssueConfirmation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueConfirmation stockIssueConfirmation = db.StockIssueConfirmations.Find(id);
            if (stockIssueConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueConfirmation);
        }

        // POST: StockIssueConfirmation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CIssueId,SIssued_Code,Airlines_Code,From_TicketNo,To_TicketNo,Ticket_Quantity,Customer_Code,Remarks,Confirm_Date")] StockIssueConfirmation stockIssueConfirmation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIssueConfirmation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockIssueConfirmation);
        }

        // GET: StockIssueConfirmation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueConfirmation stockIssueConfirmation = db.StockIssueConfirmations.Find(id);
            if (stockIssueConfirmation == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueConfirmation);
        }

        // POST: StockIssueConfirmation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockIssueConfirmation stockIssueConfirmation = db.StockIssueConfirmations.Find(id);
            db.StockIssueConfirmations.Remove(stockIssueConfirmation);
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
