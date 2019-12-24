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
    public class StockRecieveInformationController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockRecieveInformation
        public ActionResult Index()
        {
            return View(db.StockRecieveInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<StockRecieveInformation> Informations = db.StockRecieveInformations.ToList<StockRecieveInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: StockRecieveInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecieveInformation stockRecieveInformation = db.StockRecieveInformations.Find(id);
            if (stockRecieveInformation == null)
            {
                return HttpNotFound();
            }
            return View(stockRecieveInformation);
        }


        [AllowAnonymous]
        public JsonResult RangeTicketCheck(int from,int to)
        {
            var findData = db.StockRecieveInformations.Where(x => x.From_TicketNo == from ).SingleOrDefault();
            return Json(findData == null, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult DuplicateCount(StockRecieveInformation stockRecieveInformation)
        //{
        //    List<StockRecieveInformation> _checkUnique = (from d in db.StockRecieveInformations
        //                                                  where d.From_TicketNo == stockRecieveInformation.From_TicketNo || d.To_TicketNo==stockRecieveInformation.To_TicketNo
        //                                                  select d).ToList();
        //    if (_checkUnique != null)
        //    {

        //        return Json(1);
        //    }
        //    else
        //    {
        //        return Json(0);
        //    }
        //}

        [HttpPost]
        public JsonResult StartingTicketData(int fromDataa)
        {
            System.Threading.Thread.Sleep(200);



            var searchData = db.StockRecieveInformations.OrderByDescending(a=>a.SRecievedId).ToList();

            foreach (var item in searchData)
            {
                if(item.From_TicketNo <= fromDataa && item.To_TicketNo >= fromDataa)
                {
                    //var test = "";
                    return Json(1);
                }
                
            }

            //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
            //int count = DuplicateCount(stockRecieveInformation);

            return Json(0);
        
        }


        [HttpPost]
        public JsonResult EndingTicketData(int toDataa)
        {
            System.Threading.Thread.Sleep(200);
            var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();

            foreach (var item in searchData)
            {
                if (item.From_TicketNo <= toDataa && item.To_TicketNo >= toDataa)
                {
                    //var test = "";
                    return Json(1);
                }
             
            }
           
                return Json(0);
           
        }


      



        //public JsonResult Betweencheck(int x)
        //{
        //    var searchData = db.StockRecieveInformations.Where(x => x.From_TicketNo >= x  || x>=x.To_TicketNo).SingleOrDefault();
        //    if (searchData != null)
        //    {

        //        return Json(1);
        //    }
        //    else
        //    {
        //        return Json(0);
        //    }
        //}

        [HttpPost]
        public JsonResult GetCustomer(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Customer_Code = (from c in db.CustomerInformations
                             where c.Customer_Name.StartsWith(Prefix)
                             select new { c.Customer_Code, c.Customer_Name, c.CustomerId});
            return Json(Customer_Code, JsonRequestBehavior.AllowGet);

            //var Countries = db.CustomerInformations.Select(x => x.Customer_Name).ToList();
            //return Json(Countries, JsonRequestBehavior.AllowGet);
        }

        // GET: StockRecieveInformation/Create



        public JsonResult IsAlreadyEnrolled(string SRecievedCode, int SRecievedId)
        {
            var enrollrecieved = db.StockRecieveInformations.Where(m => m.SRecieved_Code == SRecievedCode && m.SRecievedId == SRecievedId);

            if (enrollrecieved.Count() == 0)
            {
                return Json(false);
            }
            return Json(true);
        }

        public ActionResult Create()
        {

            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;

            String time = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Trans_Date = time;

            //String strSQL = "select max(cast(substring(SRecieved_Code,5,len(SRecieved_Code)-4) as numeric))+1 from StockRecieveInformations";


            List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();

            try
            {

                StockRecieveInformation information = new StockRecieveInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    string todaydate = DateTime.Now.ToString("yyMM");
                    int seq = 1;
                    string ss = string.Format("REV-{0}-{1}", todaydate, seq.ToString("D5"));

                    ViewBag.SRecieved_Code = ss;

                    //ConsigneeInformation objinformations = new ConsigneeInformation();
                    //int s = objinformations.Consignee_Code + 1;
                    ////ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    //ViewBag.Consignee_Code = s.ToString();
                }
                else
                {
                    StockRecieveInformation informations = new StockRecieveInformation();

                    information = Informations.FirstOrDefault();
                    string code =information.SRecieved_Code;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 5);
                    int codeee = Int32.Parse(mystring) + 1;
                    string todaydate = DateTime.Now.ToString("yyMM");
                   
                    string ss = string.Format("REV-{0}-{1}", todaydate, codeee.ToString("D5"));

                    ViewBag.SRecieved_Code = ss;
                    //ViewBag.Consignee_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            //string todaydate = DateTime.Now.ToString("yyMM");

            //int seq=1;
            //string ss = string.Format("REV-{0}-{1}",todaydate, seq.ToString("D4"));

            //ViewBag.SRecieved_Code =ss;

            //string todaydate = DateTime.Today.ToString("ddMMyyyy");
            //int seq = 1;
            //string ss = "REV-";
            //string sss = seq.ToString("D4");
            //string sssss = ss + todaydate + sss;
            //ViewBag.SRecieved_Code = sssss;
            var list = new List<string>() { "Received"};
            ViewBag.list = list;
            //var list2 = new List<string>() { "Confirmed" };
            //ViewBag.list2 = list2;

            var list3 = new List<string>() { "No" };
            ViewBag.list3 = list3;
            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations, "Airlines_Code", "Long_Desc");
            //ViewBag.Customer_Code = new SelectList(db.CustomerInformations, "Customer_Code", "Customer_Name");




            return View();
        }

        // POST: StockRecieveInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SRecievedId,SRecieved_Code,SR_Type,Trans_Date,Airlines_Code,From_TicketNo,To_TicketNo,Ticket_Quantity,Customer_Code,Remarks,Issued,Entry_Date")] StockRecieveInformation stockRecieveInformation)
        {

            //var exists = (from c in db.StockRecieveInformations
            //              where c.SRecieved_Code == SRecieved_Code)

            //var foo = db.StockRecieveInformations.FirstOrDefault(w => w.SRecieved_Code== SRecieved_Code);
            //if (foo == null)
            //{
            //}

            var list = new List<string>() { "Received" };
            ViewBag.list = list;
            //var list2 = new List<string>() { "Confirmed" };
            //ViewBag.list2 = list2;

            var list3 = new List<string>() { "No" };
            ViewBag.list3 = list3;

            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations, "Airlines_Code", "Long_Desc");
            //int num1 = Convert.ToInt32(HttpContext.Request.Form["From_TicketNo"].ToString());
            //int num2 = Convert.ToInt32(HttpContext.Request.Form["To_TicketNo"].ToString());
            //int result = (num2-num1)+1;


            // int Ticket_Quantity = To_TicketNo.tos
            if (ModelState.IsValid)
            {
                db.StockRecieveInformations.Add(stockRecieveInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockRecieveInformation);
        }

        // GET: StockRecieveInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockRecieveInformation stockRecieveInformation = db.StockRecieveInformations.Find(id);
            if (stockRecieveInformation == null)
            {
                return HttpNotFound();
            }

            var list = new List<string>() { "Received" };
            ViewBag.list = list;
            //var list2 = new List<string>() { "Confirmed" };
            //ViewBag.list2 = list2;

            var list3 = new List<string>() { "No" };
            ViewBag.list3 = list3;
            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations, "Airlines_Code", "Long_Desc");
            //ViewBag.Customer_Code = new SelectList(db.CustomerInformations, "Customer_Code", "Customer_Name");
            return View(stockRecieveInformation);
        }

        // POST: StockRecieveInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SRecievedId,SRecieved_Code,SR_Type,Trans_Date,Airlines_Code,From_TicketNo,To_TicketNo,Ticket_Quantity,Customer_Code,Remarks,Issued,Entry_Date")] StockRecieveInformation stockRecieveInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockRecieveInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockRecieveInformation);
        }

        // GET: StockRecieveInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                StockRecieveInformation Informations = db.StockRecieveInformations.Where(x => x.SRecievedId == id).FirstOrDefault<StockRecieveInformation>();
                db.StockRecieveInformations.Remove(Informations);
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
