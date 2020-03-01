using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GSA_Management_Information_System.Models;

namespace GSA_Management_Information_System.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var waitingIssue = db.StockRecieveInformations.Where(a => a.SRecievedId == a.SRecievedId && a.Issued == "No" || a.Issued == "partially").ToList();

            //var Recieved_Code = (from c in db.StockRecieveInformations
            // where c.Issued == "No" select new { c.SRecieved_Code, c.SRecievedId });

            //var waitingissued = db.StockRecieveInformations.Where(a => a.Issued == "No").ToList();
            var alreadyissued = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId && a.Confirm_Status == "No").ToList();
            var confirmedissued = db.StockIssueInformations.Where(a => a.Confirm_Status == "Confirmed").ToList();


            //var ttt = db.StockIssueInformations.Where(a => a.SIssueId == a.SIssueId).ToList();
            //// List<StockIssueInformation> Informations = db.StockIssueInformations.ToList<StockIssueInformation>();
            ViewBag.waitingissuedData = waitingIssue;
            ViewBag.alreadyissuedData = alreadyissued;
            ViewBag.confirmedissuedData = confirmedissued;

            return View();
        }

        public ActionResult About()
        {
            
           ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}