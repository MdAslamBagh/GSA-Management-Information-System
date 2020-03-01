using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_Management_Information_System.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace GSA_Management_Information_System.Controllers
{
    public class StockIssueInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockIssueInformation
        public ActionResult Index()
        {

            var waitingIssue = db.StockRecieveInformations.Where(a => a.SRecievedId == a.SRecievedId && a.Issued=="No" ||a.Issued=="partially").ToList();

            //var Recieved_Code = (from c in db.StockRecieveInformations
            // where c.Issued == "No" select new { c.SRecieved_Code, c.SRecievedId });

            //var waitingissued = db.StockRecieveInformations.Where(a => a.Issued == "No").ToList();
            var alreadyissued= db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId && a.Confirm_Status =="No").ToList();
            //var confirmedissued = db.StockIssueConfirmations.Where(a => a.Status == "Confirmed").ToList();


            //var ttt = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId).ToList();
            //// List<StockIssueInformation> Informations = db.StockIssueInformations.ToList<StockIssueInformation>();
            ViewBag.waitingissuedData = waitingIssue;
            ViewBag.alreadyissuedData = alreadyissued;
           // ViewBag.confirmedissuedData = confirmedissued;

            //ViewBag.asd = ttt;
            return View();
            //return View(db.StockIssueInformations.ToList());
        }


        //public ActionResult SaveResult()
        //{
        //   // ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
        //    ViewBag.StockRecievelist = db.StockRecieveInformations.ToList();
        //    //ViewBag.GradeList = db.Grades.ToList();
        //    return View();
        //}

       

        //..............................
        public ActionResult GetData()
        {
            // var data = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId).ToList();
            //List<StockIssueInformation> Informations = db.StockIssueInformations.ToList<StockIssueInformation>();
            // ViewBag.stockdata = data;
            // return View();

            var Informations = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId && a.Confirm_Status == "No").ToList();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }


       // starting ticket checking if have been issued
        [HttpPost]
        public JsonResult StartingTicketData(int fromDataa)
        {
            System.Threading.Thread.Sleep(200);


            //var asdfg = db.StockIssueInformations.Where(a => a.From_TicketNo == a.From_TicketNo);
            var searchData = db.StockIssueInformations.OrderByDescending(a => a.SIssueId).ToList();

            foreach (var item in searchData)
            {

                if (item.From_TicketNo <= fromDataa && item.To_TicketNo >= fromDataa)
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



        //[HttpPost]
        //public JsonResult StartingTicketData(int fromDataa, int toDataa)
        //{
        //    System.Threading.Thread.Sleep(200);
        //    int i = fromDataa;

        //    List<int> availList = new List<int>();

        //    List<int> rejectList = new List<int>();
        //    for (i = fromDataa; i <= toDataa; i++)
        //    {
        //        var sss = db.StockIssueInformations.Where(a => a.From_TicketNo <= i && a.To_TicketNo >= i).FirstOrDefault();
        //        if (sss == null)
        //        {
        //            int t = i;
        //            availList.Add(t);
        //            // return fromDataa;
        //        }
        //        else
        //        {
        //            int tt = i;
        //            rejectList.Add(tt);

        //        }
        //    }

        //    if (rejectList.Count() >= 1)
        //    {
        //        return Json(new { success = false, rejectList }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { success = true, availList }, JsonRequestBehavior.AllowGet);

        //    }

        //    //var asdfg = db.StockIssueInformations.Where(a => a.From_TicketNo == a.From_TicketNo);
        //    //var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();

        //    //foreach (var item in searchData)
        //    //{

        //    //    int x = fromDataa;

        //    //    if (x >= item.From_TicketNo && x <= item.To_TicketNo)  //   4...9876545-9876547...8
        //    //    {

        //    //        //var test = "";
        //    //        return Json(0);  //available
        //    //    }

        //    //}

        //    //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
        //    //int count = DuplicateCount(stockRecieveInformation);


        //}


        [HttpPost]
        //public JsonResult StartingTicketDataEdit(int fromDataa, int toDataa,string issueCode,string srreceiveCode,int fromTicket,int toTicket)
       public JsonResult StartingTicketDataEdit(int fromDataa, int toDataa, string issueCode, string srreceiveCode)
        {
            var result = (from sr in db.StockRecieveInformations
                          join si in db.StockIssueInformations on sr.SRecieved_Code equals si.SRecieved_Code where si.SIssued_Code!= issueCode
                          select new
                          {
                              SIssued_Code=si.SIssued_Code,
                              SRecieved_Code=sr.SRecieved_Code,
                              Receive_Fromticket = sr.From_TicketNo,
                              Receive_Toticket = sr.To_TicketNo,
                              Received_TicketQuantity = sr.Ticket_Quantity,
                              Issued_FromTicket = si.From_TicketNo,
                              Issued_ToTicket = si.To_TicketNo,
                              Issued_TicketQuantity = si.Ticket_Quantity
                           
                          }).ToList();


            var tttt = result.ToList();
            //var ssss = tttt.Where(a => a.SRecieved_Code == srreceiveCode).FirstOrDefault();
            var pppp = db.StockRecieveInformations.Where(a => a.SRecieved_Code == srreceiveCode).FirstOrDefault();



            //var From = fromTicket;
            ////var receiveFromTicket = ssss.Receive_Fromticket;
            ////var receiveToTicket = ssss.Receive_Toticket;
            //var To = toTicket;
            //var receiveFromTicket = pppp.From_TicketNo;
            //var receiveToTicket = pppp.To_TicketNo;

            if(pppp !=null)
            //if (From < receiveFromTicket)
            {
                return Json(new { success = 1, pppp }, JsonRequestBehavior.AllowGet);   //range cross

            }
            else

            System.Threading.Thread.Sleep(200);
            int i = fromDataa;

            List<int> availList = new List<int>();

            List<int> rejectList = new List<int>();
           
            
            for (i = fromDataa; i <= toDataa; i++)
            {
                var ttt = result.ToList();
                var sss = ttt.Where(a => a.Issued_FromTicket <= i && a.Issued_ToTicket >= i).FirstOrDefault();
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
                return Json(new { success = 2, rejectList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = 3, availList}, JsonRequestBehavior.AllowGet);

            }

          


        }



        [HttpPost]
        public JsonResult EndingTicketData(int fromDataa, int toDataa,string issueCode)
        {
            System.Threading.Thread.Sleep(200);
            int i = fromDataa;

            List<int> availList = new List<int>();

            List<int> rejectList = new List<int>();
            for (i = fromDataa; i <= toDataa; i++)
            {
                var sss = db.StockIssueInformations.Where(a => a.From_TicketNo <= i && a.To_TicketNo >= i && a.SIssued_Code != issueCode).FirstOrDefault();
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

        //Ending Ticket checking if already been issued 

        //Edit methlod ending ticket check which has been already taken someone

        [HttpPost]
        //public JsonResult StartingTicketDataEdit(int fromDataa, int toDataa,string issueCode,string srreceiveCode,int fromTicket,int toTicket)
        public JsonResult EndingTicketDataEdit(int fromDataa, int toDataa, string issueCode, string srreceiveCode)
        {
            var result = (from sr in db.StockRecieveInformations
                          join si in db.StockIssueInformations on sr.SRecieved_Code equals si.SRecieved_Code
                          where si.SIssued_Code != issueCode
                          select new
                          {
                              SIssued_Code = si.SIssued_Code,
                              SRecieved_Code = sr.SRecieved_Code,
                              Receive_Fromticket = sr.From_TicketNo,
                              Receive_Toticket = sr.To_TicketNo,
                              Received_TicketQuantity = sr.Ticket_Quantity,
                              Issued_FromTicket = si.From_TicketNo,
                              Issued_ToTicket = si.To_TicketNo,
                              Issued_TicketQuantity = si.Ticket_Quantity

                          }).ToList();


            var tttt = result.ToList();
            //var ssss = tttt.Where(a => a.SRecieved_Code == srreceiveCode).FirstOrDefault();
            var pppp = db.StockRecieveInformations.Where(a => a.SRecieved_Code == srreceiveCode).FirstOrDefault();



            //var From = fromTicket;
            ////var receiveFromTicket = ssss.Receive_Fromticket;
            ////var receiveToTicket = ssss.Receive_Toticket;
            //var To = toTicket;
            //var receiveFromTicket = pppp.From_TicketNo;
            //var receiveToTicket = pppp.To_TicketNo;

            if (pppp != null)
            //if (From < receiveFromTicket)
            {
                return Json(new { success = 1, pppp }, JsonRequestBehavior.AllowGet);   //range cross

            }
            else

                System.Threading.Thread.Sleep(200);
            int i = fromDataa;

            List<int> availList = new List<int>();

            List<int> rejectList = new List<int>();


            for (i = fromDataa; i <= toDataa; i++)
            {
                var ttt = result.ToList();
                var sss = ttt.Where(a => a.Issued_FromTicket <= i && a.Issued_ToTicket >= i).FirstOrDefault();
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
                return Json(new { success = 2, rejectList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = 3, availList }, JsonRequestBehavior.AllowGet);

            }




        }



        //StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
        //int count = DuplicateCount(stockRecieveInformation);





        //..................................

        public JsonResult GetReceivedCodeById(string srecieved_Code)
        {
              ApplicationDbContext db = new ApplicationDbContext();
            //List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();
            //StockRecieveInformation informationss = new StockRecieveInformation();
            //informationss.Ticket_Quantity = informationss.Ticket_Quantity.valu
            var receivedcode = db.StockRecieveInformations.Where(m => m.SRecieved_Code == srecieved_Code).FirstOrDefault();






            // var query = from e in db.StockRecieveInformations join d in db.StockIssueInformations on e.SRecieved_Code equals d.SRecieved_Code
            //    select new { e.SRecieved_Code};


            
            //var r = db.StockIssueInformations.Where(a => a.SRecieved_Code == srecieved_Code).ToList();
            //if (r.Count!=0)
            //{
            //    int fromticketno = receivedcode.From_TicketNo;
            //    int toticketno = receivedcode.To_TicketNo;
            //    int quantity = receivedcode.Ticket_Quantity;


                //var result = (from p in db.StockRecieveInformations
                //              join o in db.StockIssueInformations on p.SRecieved_Code equals o.SRecieved_Code
                //              where o.SRecieved_Code == srecieved_Code
                //              select new
                //              {
                //                  p.SRecieved_Code,
                //                  o.Stock_Type,
                //                  o.From_TicketNo,
                //                  o.To_TicketNo,
                //                  o.Ticket_Quantity,
                //                  //o.TotalAmount,
                //                  //o.OrderDate
                //              }).ToList();



                //int Issuequantity = 0;
                ////int fromticektttt;

                //foreach (var item in r)
                //{

                //   Issuequantity += item.Ticket_Quantity;

                   
                 
                //}
                //int totalleftquantity = receivedcode.Ticket_Quantity - Issuequantity;
                //int firsttoticket = (receivedcode.To_TicketNo - totalleftquantity) + 1;
                //int lasttoticket = receivedcode.To_TicketNo;


                //receivedcode.Ticket_Quantity = totalleftquantity;
                //receivedcode.From_TicketNo = firsttoticket;
                //receivedcode.To_TicketNo = lasttoticket;

                return Json(receivedcode, JsonRequestBehavior.AllowGet);


                    //totalleftquantity += receivedcode.Ticket_Quantity - item.Ticket_Quantity;


               

              
            }

            //if (result == null)
            //{
            //    return Json(receivedcode, JsonRequestBehavior.AllowGet);

            //}

            //int totalleftquantity = receivedcode.Ticket_Quantity - result.Ticket_Quantity;
            //int firsttoticket = (receivedcode.To_TicketNo - totalleftquantity) + 1;
            //int lasttoticket = receivedcode.To_TicketNo;

            //receivedcode.Ticket_Quantity = totalleftquantity;
            //receivedcode.From_TicketNo = firsttoticket;
            //receivedcode.To_TicketNo = lasttoticket;

            // var query = from e in db.StockRecieveInformations join d in db.StockIssueInformations on e.SRecieved_Code equals d.SRecieved_Code
            //    select new { e.SRecieved_Code};


            //var result = (from p in db.StockRecieveInformations
            //              join o in db.StockIssueInformations on p.SRecieved_Code equals o.SRecieved_Code where o.SRecieved_Code == srecieved_Code
            //              select new
            //              {
            //                  p.SRecieved_Code,
            //                  o.Stock_Type,
            //                  o.From_TicketNo,
            //                  o.To_TicketNo,
            //                  o.Ticket_Quantity,
            //                  //o.TotalAmount,
            //                  //o.OrderDate
            //              }).FirstOrDefault();

            //if (result == null)
            //{
            //    return Json(receivedcode, JsonRequestBehavior.AllowGet);

            //}

            //int totalleftquantity = receivedcode.Ticket_Quantity - result.Ticket_Quantity;
            //int firsttoticket = (receivedcode.To_TicketNo - totalleftquantity) + 1;
            //int lasttoticket = receivedcode.To_TicketNo;

            //receivedcode.Ticket_Quantity = totalleftquantity;
            //receivedcode.From_TicketNo = firsttoticket;
            //receivedcode.To_TicketNo = lasttoticket;




            //ViewBag.From_TicketNo = firsttoticket.ToString();
            //ViewBag.To_TicketNo = lasttoticket.ToString();
            //ViewBag.Ticket_Quantity = totalleftquantity.ToString();

        //    return Json(receivedcode, JsonRequestBehavior.AllowGet);


        //    //int issuefromticketno = result.From_TicketNo;
        //    //int issuetoticketno = result.To_TicketNo;
        //    //int issuequantity = result.Ticket_Quantity;



        //    // receivedcode.SIssued_Code = receivedcode.SIssued_Code;
        //    //stockIssueDetailInformations.Ticket_No = i;
        //    //stockIssueDetailInformations.Status = "Issued";
        //    //db.StockIssueDetailInformations.Add(stockIssueDetailInformations);
        //    //stockIssueDetailInformations.SDetailsId = 1;

        //    //}



        //    //ViewBag.Status = receivedcode.Ticket_Quantity;

        //    //ViewBag.Transaction_Status = "Issued";

        //}


        public JsonResult GetQuantityById(int quantity)
        {
            var receivedcode = db.StockRecieveInformations.Where(m => m.SRecieved_Code == quantity.ToString()).ToList();


            return Json(receivedcode, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult StartingTicketData(int fromDataa)
        //{
        //    System.Threading.Thread.Sleep(200);
        //    var searchData = db.StockRecieveInformations.Where(x => x.From_TicketNo > fromDataa).SingleOrDefault();
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
        public JsonResult TicketQuantity(int quantitydataa)
        {
            System.Threading.Thread.Sleep(200);
            var searchData = db.StockRecieveInformations.Where(x => x.Ticket_Quantity == quantitydataa).SingleOrDefault();
            if (searchData != null)
            {

                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        public JsonResult GetRecieved_Code(string Prefix)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            var Recieved_Code = (from c in db.StockRecieveInformations
                                 where c.SRecieved_Code.StartsWith(Prefix) && c.Issued=="No" || c.Issued=="Partially"
                                 select new { c.SRecieved_Code, c.SRecievedId});
            return Json(Recieved_Code, JsonRequestBehavior.AllowGet);

            //var Countries = db.CustomerInformations.Select(x => x.Customer_Name).ToList();
            //return Json(Countries, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetCustomer(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Customer_Code = (from c in db.CustomerInformations
                                 where c.Customer_Name.StartsWith(Prefix)
                                 select new { c.Customer_Code, c.Customer_Name, c.CustomerId });
            return Json(Customer_Code, JsonRequestBehavior.AllowGet);

            //var Countries = db.CustomerInformations.Select(x => x.Customer_Name).ToList();
            //return Json(Countries, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult Getairlinesbyreceivedcode(int Airlines_Code)
        //{
        //    //var courses = db.Courses.Where(m => m.Department.Id == SRecievedId).ToList();
        //    //return Json(courses, JsonRequestBehavior.AllowGet);

        //    var AirlinesCode = db.AirlinesInformations.Where(m => m.Airlines_Code == Airlines_Code).ToList();
        //    return Json(AirlinesCode, JsonRequestBehavior.AllowGet);
        //}



        // GET: StockIssueInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
            if (stockIssueInformation == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueInformation);
        }

        // GET: StockIssueInformation/Create
        public ActionResult Create()

        {

            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            //ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations.Where(a => a.Default_Code == true), "Airlines_Code", "Long_Desc");
            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations, "Airlines_Code", "Long_Desc");
            ViewBag.StockRecievelist = db.StockRecieveInformations.ToList();
            String time = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Issue_Date = time;
            List<StockIssueInformation> Informations = db.StockIssueInformations.OrderByDescending(a => a.SIssueId).ToList<StockIssueInformation>();


           // ViewBag.Transaction_Staus = "ISSUED";
            //var quantiy=db.StockRecieveInformations.Where(a=>a.Ticket_Quantity)
            //ViewBag.Ticket_Quantity = db.StockRecieveInformations.ToList();

            //var quantity = db.StockRecieveInformations.Where(a => a.Ticket_Quantity.ToString()).ToList();

            //foreach (var item in quantity)
            //{
            //    item.Default_Code = false;

            //}

            try
            {

                StockIssueInformation information = new StockIssueInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    string todaydate = DateTime.Now.ToString("yyMM");
                    int seq = 1;
                    string ss = string.Format("ISS-{0}-{1}", todaydate, seq.ToString("D5"));

                    ViewBag.SIssued_Code = ss;

                    //ConsigneeInformation objinformations = new ConsigneeInformation();
                    //int s = objinformations.Consignee_Code + 1;
                    ////ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    //ViewBag.Consignee_Code = s.ToString();
                }
                else
                {
                    StockIssueInformation informations = new StockIssueInformation();

                    information = Informations.FirstOrDefault();
                    string code = information.SIssued_Code;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 5);
                    int codeee = Int32.Parse(mystring) + 1;
                    string todaydate = DateTime.Now.ToString("yyMM");

                    string ss = string.Format("ISS-{0}-{1}", todaydate, codeee.ToString("D5"));

                    ViewBag.SIssued_Code = ss;
                    //ViewBag.Consignee_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            //List<StockRecieveInformation> Informationss = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList<StockRecieveInformation>();

            //try
            //{

            //    StockRecieveInformation information= new StockRecieveInformation();

            //    information = Informationss.FirstOrDefault();
            //    if (information == null)
            //    {
            //        string Issue = "ISSUED";
     
            //        ViewBag.Transaction_Status = Issue;

            //        //ConsigneeInformation objinformations = new ConsigneeInformation();
            //        //int s = objinformations.Consignee_Code + 1;
            //        ////ViewBag.ConsignorCode = information.Consignor_Code + 1;
            //        //ViewBag.Consignee_Code = s.ToString();
            //    }
            //    else
            //    {
            //        StockRecieveInformation informations = new StockRecieveInformation();

            //        string Issue = "ISSUED";

            //        ViewBag.Transaction_Status = Issue;

            //        //information = Informations.FirstOrDefault();
            //        //string code = information.SIssued_Code;

            //        //string mystring = code;
            //        //mystring = mystring.Substring(mystring.Length - 5);
            //        //int codeee = Int32.Parse(mystring) + 1;
            //        //string todaydate = DateTime.Now.ToString("yyMM");

            //        //string ss = string.Format("ISS-{0}-{1}", todaydate, codeee.ToString("D5"));

            //        //ViewBag.SIssued_Code = ss;
            //        //ViewBag.Consignee_Code = code.ToString();//.PadLeft(4, '0');
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}




            var list = new List<string>() { "Issued" };
            ViewBag.list = list;

            var list2 = new List<string>() { "No" };
            ViewBag.list2 = list2;

            return View();
        }



        // POST: StockIssueInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockIssueInformation stockIssueInformation)
        {
           
            var list = new List<string>() { "Issued" };
            ViewBag.list = list;

            var list2 = new List<string>() { "No" };
            ViewBag.list2 = list2;
            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations.Where(a=>a.Default_Code==true), "Airlines_Code", "Long_Desc");
            if (ModelState.IsValid)
            {

               

                if (stockIssueInformation.Transaction_Status == "Issued")

                {
                    //var original = db.StockRecieveInformations.Find(id);
                    StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
                    stockRecieveInformation = db.StockRecieveInformations.Where(a => a.SRecieved_Code == stockIssueInformation.SRecieved_Code).FirstOrDefault();

                   // ViewBag.Ticket_Quantity == stockRecieveInformation.Ticket_Quantity
                    if (stockIssueInformation.SRecieved_Code == stockRecieveInformation.SRecieved_Code)
                    {
                        db.StockRecieveInformations.Attach(stockRecieveInformation);
                        stockRecieveInformation.Issued = stockIssueInformation.Transaction_Status;

                        //db.StockRecieveInformations.Attach(stockRecieveInformation);
                        db.SaveChanges();
                    }
                    //var item = StockRecieveInformation.Find(id);

                    //StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
                    //var receivecode = db.StockRecieveInformations.Where(a => a.SRecieved_Code != stockRecieveInformation.SRecieved_Code).ToList();

                    //foreach (var item in original)
                    //{
                    //    item.Transaction_Status = "Issued";

                    //}
                    //  List<StockRecieveInformation> Informations = db.StockRecieveInformations.OrderByDescending(a => a.SRecieved_Code).ToList<StockRecieveInformation>();


                    //StockRecieveInformation stockRecieveInformation =db.StockRecieveInformations.Find(SRecieved_Code);






                }

                else if (stockIssueInformation.Transaction_Status == "Partially")
                    {

                    StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
                    stockRecieveInformation = db.StockRecieveInformations.Where(a => a.SRecieved_Code == stockIssueInformation.SRecieved_Code).FirstOrDefault();
                    string srecieved_Code= stockRecieveInformation.SRecieved_Code;




                    //StockRecieveInformation StockRecieveInformation = new StockRecieveInformation();
                   // StockRecieveInformation stockRecieve = new StockRecieveInformation();
                   // stockRecieveInformation = db.StockRecieveInformations.Where(a => a.SRecieved_Code == stockIssueInformation.SRecieved_Code).FirstOrDefault();
                   // string receivecode = stockRecieveInformation.SRecieved_Code;
                  
                    ////StockRecieveInformation stockRecieveInformation = new StockRecieveInformation();
                    //stockIssueInformation = db.StockIssueInformations.Where(a => a.SRecieved_Code ==a.SRecieved_Code ).ToList();

                    //StockIssueInformation stockissuequantity = new StockIssueInformation();
                   // stockissuequantity = db.StockIssueInformations.Where(a => a.SRecieved_Code==stockRecieveInformation).ToList();
                    if (stockIssueInformation.SRecieved_Code == stockRecieveInformation.SRecieved_Code)
                    {


                        var result = (from p in db.StockRecieveInformations
                                      join o in db.StockIssueInformations on p.SRecieved_Code equals o.SRecieved_Code
                                      where o.SRecieved_Code == srecieved_Code
                                      select new
                                      {
                                          p.SRecieved_Code,
                                          o.Stock_Type,
                                          o.From_TicketNo,
                                          o.To_TicketNo,
                                          o.Ticket_Quantity,
                                          //o.TotalAmount,
                                          //o.OrderDate
                                      }).ToList();

                        int Issuequantity = 0;
                        //int fromticektttt;

                        foreach (var item in result)
                        {

                            Issuequantity += item.Ticket_Quantity;
                            



                        }
                        Issuequantity += stockIssueInformation.Ticket_Quantity;

                        if (stockRecieveInformation.Ticket_Quantity!= Issuequantity)
                        {

                            db.StockRecieveInformations.Attach(stockRecieveInformation);

                            stockRecieveInformation.Issued = stockIssueInformation.Transaction_Status;

                            //db.StockRecieveInformations.Attach(stockRecieveInformation);
                            db.SaveChanges();
                        }
                        else
                        {
                            db.StockRecieveInformations.Attach(stockRecieveInformation);

                            stockRecieveInformation.Issued = "Issued";

                            //db.StockRecieveInformations.Attach(stockRecieveInformation);
                            db.SaveChanges();
                        }
                    }



                }

                StockIssueDetailInformations stockIssueDetailInformations = new StockIssueDetailInformations();



                //////
                //DataSet ds = new DataSet();

                ////Here we declare the parameter which we have to use in our application  
                //SqlCommand cmd = new SqlCommand();
              

                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString);
                //// SqlConnection con = new SqlConnection("Server=DHKLTINWASLAM\\INNOWEB,Authentication=Windows Authentication, Database=GSAMISDB");
                //// cmd.Parameters.AddWithValue("@FIRST", SqlDbType.VarChar).Value = stockIssueInformation.From_TicketNo.ToString();
                ////   cmd.Parameters.AddWithValue("@LAST", SqlDbType.VarChar).Value = stockIssueInformation.To_TicketNo.ToString();
                //cmd = new SqlCommand("PROC_SAVETICKET", con);
                //cmd.Parameters.Add("@FIRST", SqlDbType.Int);
                //cmd.Parameters["@FIRST"].Value = stockIssueInformation.From_TicketNo;


                //cmd.Parameters.Add("@LAST", SqlDbType.Int);
                //cmd.Parameters["@LAST"].Value = stockIssueInformation.To_TicketNo;

                //cmd.Parameters.Add("@ISSUECODE", SqlDbType.NVarChar);
                //cmd.Parameters["@ISSUECODE"].Value = stockIssueInformation.SIssued_Code;

                //cmd.CommandType = CommandType.StoredProcedure;
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();



                ///////

                //stockIssueDetailInformations = db.StockIssueDetailInformations.Where(a => a.SIssued_Code == stockIssueDetailInformations.SIssued_Code).FirstOrDefault();

                //var searchData = db.StockRecieveInformations.OrderByDescending(a => a.SRecievedId).ToList();


                //ViewBag.To_TicketNo = stockIssueInformation.To_TicketNo;

                for (int i = stockIssueInformation.From_TicketNo; i <= stockIssueInformation.To_TicketNo; i++)
                {
                    stockIssueDetailInformations.SIssued_Code = stockIssueInformation.SIssued_Code;
                    stockIssueDetailInformations.Ticket_No =i;
                    stockIssueDetailInformations.Status = "Issued";
                    db.StockIssueDetailInformations.Add(stockIssueDetailInformations);
                    //stockIssueDetailInformations.SDetailsId = 1;

                    db.SaveChanges();

                }
            

                //stockIssueDetailInformations.SIssued_Code = stockIssueInformation.SIssued_Code;
                //stockIssueDetailInformations.Ticket_No = stockIssueInformation.To_TicketNo;
                //stockIssueDetailInformations.Status = "Issued";
                //db.StockIssueDetailInformations.Add(stockIssueDetailInformations);
                //stockIssueDetailInformations.SDetailsId = 1;

                db.SaveChanges();

                //b.StockIssueDetailInformatmons.Add()


                var LogedInUser = User.Identity.Name;
                stockIssueInformation.Entry_By = LogedInUser;
                stockIssueInformation.Entry_Date = DateTime.Now;
                db.StockIssueInformations.Add(stockIssueInformation);


                //var receivelist = db.StockRecieveInformations.Where(a => a.SRecieved_Code != stockRecieveInformation.SRecieved_Code).ToList();
                //foreach (var item in receivelist)
                //{
                //    item.Transaction_Status = "ISSUED";

                //}
                //db.StockRecieveInformations.Attach(stockRecieveInformation);
                db.SaveChanges();
               


                return RedirectToAction("Index");
            }

            return View(stockIssueInformation);





        }

        // GET: StockIssueInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
            if (stockIssueInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Issued" };
            ViewBag.list = list;

            var list2 = new List<string>() { "No" };
            ViewBag.list2 = list2;
            ViewBag.Airlines_Code = new SelectList(db.AirlinesInformations, "Airlines_Code", "Long_Desc");
            return View(stockIssueInformation);
        }

        // POST: StockIssueInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockIssueInformation stockIssueInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                stockIssueInformation.Entry_By = LogedInUser;
                stockIssueInformation.Entry_Date = DateTime.Now;
                db.Entry(stockIssueInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockIssueInformation);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Confirm(int id)
        {
            StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
            stockIssueInformation.Confirm_Status = "Confirmed";
            db.Entry(stockIssueInformation).State = EntityState.Modified;
            db.SaveChanges();




            var stockIssueDetailInformation = db.StockIssueDetailInformations.Where(a => a.SIssued_Code == stockIssueInformation.SIssued_Code).ToList();
            foreach (var item in stockIssueDetailInformation)
            {
                StockIssueDetailInformations stockIssueDetailInformations = item;

                db.StockIssueDetailInformations.Attach(stockIssueDetailInformations);
                stockIssueDetailInformations.SIssued_Code = item.SIssued_Code;
                stockIssueDetailInformations.Ticket_No = item.Ticket_No;
                stockIssueDetailInformations.Status = "Confirmed";

                //stockIssueDetailInformations.SDetailsId = 1;

                db.SaveChanges();

            }
            //StockIssueDetailInformations stockIssueDetailInformations = new StockIssueDetailInformations();

            //for (int i = stockIssueInformation.From_TicketNo; i <= stockIssueInformation.To_TicketNo; i++)
            //{
            //    stockIssueDetailInformations.SIssued_Code = stockIssueInformation.SIssued_Code;
            //    stockIssueDetailInformations.Ticket_No = i;
            //    stockIssueDetailInformations.Status = "Confirmed";
            //    db.StockIssueDetailInformations.Add(stockIssueDetailInformations);
            //    //stockIssueDetailInformations.SDetailsId = 1;

            //    db.SaveChanges();

            //}




            return Json(new { success = true, message = "Confirmed Successfully" }, JsonRequestBehavior.AllowGet);

            //return RedirectToAction("Index");
        }







        // GET: StockIssueInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
            if (stockIssueInformation == null)
            {
                return HttpNotFound();
            }
            return View(stockIssueInformation);
        }

        // POST: StockIssueInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockIssueInformation stockIssueInformation = db.StockIssueInformations.Find(id);
            db.StockIssueInformations.Remove(stockIssueInformation);
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
