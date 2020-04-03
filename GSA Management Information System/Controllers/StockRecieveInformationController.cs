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

            var Informations = from stockreceive in db.StockRecieveInformations join customer in db.CustomerInformations on stockreceive.Customer_Code equals customer.Customer_Code join airlines in db.AirlinesInformations on stockreceive.Airlines_Code equals airlines.Airlines_Code
                               select new {stockreceive.SRecievedId, stockreceive.SRecieved_Code,stockreceive.SR_Type,
                               stockreceive.Airlines_Code,
                                   Airlines=airlines.Long_Desc,
                                   stockreceive.From_TicketNo, stockreceive.To_TicketNo,
                                   stockreceive.Ticket_Quantity,
                                   customer.Customer_Name,stockreceive.Customer_Code,stockreceive.Remarks,stockreceive.Issued };

            //    List<StockRecieveInformation> Informations = db.StockRecieveInformations.ToList<StockRecieveInformation>();
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


        //[AllowAnonymous]
        [HttpPost]
        public JsonResult RangeTicketData(int fromrangeDataa, int torangeDataa)
        {
            var findData = db.StockRecieveInformations.Where(x => x.From_TicketNo == fromrangeDataa ).SingleOrDefault();
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


            //var asdfg = db.StockIssueInformations.Where(a => a.From_TicketNo == a.From_TicketNo);
            var searchData = db.StockRecieveInformations.OrderByDescending(a=>a.SRecievedId).ToList();

            foreach (var item in searchData)
            {
              
                if(item.From_TicketNo <= fromDataa && item.To_TicketNo >= fromDataa)
                {
                    //var test = "";
                   // return Json(0); 
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);

                }
                
            }

            //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
            //int count = DuplicateCount(stockRecieveInformation);

            //return Json(1);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }




        //Edit Method Starting Ticket check another receivecode


        [HttpPost]
        public JsonResult StartingTicketDataEdit(int fromDataa,string receiveCode)
        {
            System.Threading.Thread.Sleep(200);


            //var asdfg = db.StockIssueInformations.Where(a => a.From_TicketNo == a.From_TicketNo);
            var searchData = db.StockRecieveInformations.Where(a => a.SRecieved_Code!=receiveCode).ToList();


            foreach (var item in searchData)
            {

                if (item.From_TicketNo <= fromDataa && item.To_TicketNo >= fromDataa)
                {
                    //var test = "";
                    // return Json(0); 
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);  //Already Received

                }

            }

            //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
            //int count = DuplicateCount(stockRecieveInformation);

            //return Json(1);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }




        //[HttpPost]
        //public JsonResult EndingTicketData(int fromDataa,int toDataa)
        //{
        //    System.Threading.Thread.Sleep(200);
        //    var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();




        //    foreach (var item in searchData)
        //    {
        //        if (item.From_TicketNo <= fromDataa)
        //        {
        //            if (item.From_TicketNo <= toDataa && item.To_TicketNo >= toDataa)
        //            {
        //                //var test = "";
        //                int[] list = {item.From_TicketNo,item.To_TicketNo };
        //                return Json(new { success = true, list }, JsonRequestBehavior.AllowGet);
        //               // return Json(list);
        //            }
        //        }
        //        else
        //        {
        //            if (item.From_TicketNo <= toDataa && item.To_TicketNo >= toDataa)
        //            {
        //                //var test = "";
        //                return Json(false,"");
        //            }
        //        }

        //    }

        //        return Json(true,"");

        //}


        //check

        [HttpPost]
        public JsonResult EndingTicketData(int fromDataa, int toDataa)
        {
            System.Threading.Thread.Sleep(200);
            int i = fromDataa;

            List<int> availList = new List<int>();

            List<int> rejectList = new List<int>();
            for ( i=fromDataa; i<=toDataa; i++)
            {
                var sss = db.StockRecieveInformations.Where(a=>a.From_TicketNo <= i && a.To_TicketNo >= i).FirstOrDefault();
                if (sss == null)
                {
                    int t = i;
                    availList.Add(t);
                    // return fromDataa;
                }
                else
                {
                    int tt = i;
                    rejectList.Add(tt);

                }
            }

            if (rejectList.Count() >= 1)
            {
                return Json(new { success = false, rejectList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, availList }, JsonRequestBehavior.AllowGet);

            }

            //var asdfg = db.StockIssueInformations.Where(a => a.From_TicketNo == a.From_TicketNo);
            //var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();

            //foreach (var item in searchData)
            //{

            //    int x = fromDataa;

            //    if (x >= item.From_TicketNo && x <= item.To_TicketNo)  //   4...9876545-9876547...8
            //    {

            //        //var test = "";
            //        return Json(0);  //available
            //    }

            //}

            //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
            //int count = DuplicateCount(stockRecieveInformation);
            

        }

        //Edit methlod ending ticket check which has been already taken someone

        [HttpPost]
        public JsonResult EndingTicketDataEdit(int fromDataa, int toDataa,string receiveCode)
        {
            System.Threading.Thread.Sleep(200);
            int i = fromDataa;

            List<int> availList = new List<int>();

            List<int> rejectList = new List<int>();
            for (i = fromDataa; i <= toDataa; i++)
            {
                var sss = db.StockRecieveInformations.Where(a => a.From_TicketNo <= i && a.To_TicketNo >= i && a.SRecieved_Code!= receiveCode).FirstOrDefault();
                if (sss == null)
                {
                    int t = i;
                    availList.Add(t);
                    // return fromDataa;
                }
                else
                {
                    int tt = i;
                    rejectList.Add(tt);

                }
            }

            if (rejectList.Count() >= 1)
            {
                return Json(new { success = false, rejectList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, availList }, JsonRequestBehavior.AllowGet);

            }
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

        //[HttpPost]
        //public JsonResult EndingTicketData(int fromDataa, int toDataa)
        //{
        //    System.Threading.Thread.Sleep(200);
        //    var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();


        //        foreach (var item in searchData)
        //    {
        //        if (searchData != null)
        //   {

        //        return Json(1);
        //    }
        //    else
        //    {
        //        return Json(0);
        //    }
        //}







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

            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            ////String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;

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

            List<CustomerInformation> customerInformations = db.CustomerInformations.Where(a => a.Default_Code == true).ToList<CustomerInformation>();
            CustomerInformation customer = new CustomerInformation();
            customer = customerInformations.FirstOrDefault();
            string c_Name = customer.Customer_Name;
            string c_Code = customer.Customer_Code;
            ViewBag.Customer_Name = c_Name;
            ViewBag.Customer_Code = c_Code;


            return View();
        }

        // POST: StockRecieveInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockRecieveInformation stockRecieveInformation)
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
                var LogedInUser = User.Identity.Name;
                stockRecieveInformation.Entry_By = LogedInUser;
                stockRecieveInformation.Entry_Date = DateTime.Now;
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
            var stockreceivedata = (from stockreceive in db.StockRecieveInformations
                                    join customer in db.CustomerInformations on stockreceive.Customer_Code equals customer.Customer_Code
                                    join airlines in db.AirlinesInformations on stockreceive.Airlines_Code equals airlines.Airlines_Code
                                    where
stockreceive.SRecievedId == id
                                    select new
                                    {
                                        stockreceive.SRecievedId,
                                        stockreceive.SRecieved_Code,
                                        stockreceive.SR_Type,
                                        stockreceive.Trans_Date,
                                        stockreceive.Airlines_Code,
                                        Airlines = airlines.Long_Desc,
                                        stockreceive.From_TicketNo,
                                        stockreceive.To_TicketNo,
                                        stockreceive.Ticket_Quantity,
                                        customer.Customer_Name,
                                        stockreceive.Customer_Code,
                                        stockreceive.Remarks,
                                        stockreceive.Issued
                                    }).FirstOrDefault();


            return View(new EditStockReceiveEditViewModel()
            {
                SRecievedId=stockreceivedata.SRecievedId,
                SRecieved_Code = stockreceivedata.SRecieved_Code,
                SR_Type = stockreceivedata.SR_Type,
                Trans_Date = stockreceivedata.Trans_Date,
                Airlines_Code = stockreceivedata.Airlines_Code,
                Airlines = stockreceivedata.Airlines,
                From_TicketNo = stockreceivedata.From_TicketNo,
                To_TicketNo = stockreceivedata.To_TicketNo,
                Ticket_Quantity = stockreceivedata.Ticket_Quantity,
                Customer_Name = stockreceivedata.Customer_Name,
                Customer_Code = stockreceivedata.Customer_Code,
                Remarks = stockreceivedata.Remarks,
                Issued = stockreceivedata.Issued,
                

            });
        }

        // POST: StockRecieveInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditStockReceiveEditViewModel editrecieve)
        {
            if (ModelState.IsValid)
            {
                StockRecieveInformation stockRecieveInformation = db.StockRecieveInformations.Find(editrecieve.SRecievedId);
                //var stockRecieveInformation = db.StockRecieveInformations.Where(a => a.SRecievedId == a.SRecievedId).FirstOrDefault();
                var LogedInUser = User.Identity.Name;
                stockRecieveInformation.Entry_By = LogedInUser;
                stockRecieveInformation.Entry_Date = DateTime.Now;
                stockRecieveInformation.SRecieved_Code = editrecieve.SRecieved_Code;
                stockRecieveInformation.SR_Type = editrecieve.SR_Type;
                stockRecieveInformation.Airlines_Code = editrecieve.Airlines_Code;
                stockRecieveInformation.From_TicketNo = editrecieve.From_TicketNo;
                stockRecieveInformation.To_TicketNo = editrecieve.To_TicketNo;
                stockRecieveInformation.Ticket_Quantity = editrecieve.Ticket_Quantity;
                stockRecieveInformation.Trans_Date = editrecieve.Trans_Date;
                stockRecieveInformation.Remarks = editrecieve.Remarks;
                stockRecieveInformation.Issued = editrecieve.Issued;                
                stockRecieveInformation.Customer_Code = editrecieve.Customer_Code;
                db.Entry(stockRecieveInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editrecieve);
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
