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
    public class BankInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankInformation
        public ActionResult Index()
        {
            return View(db.BankInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<BankInformation> BankInformations = db.BankInformations.ToList<BankInformation>();
            return Json(new { data = BankInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
        

            List<BankInformation> Informations = db.BankInformations.OrderByDescending(a => a.BankId).ToList<BankInformation>();

            try
            {
                BankInformation information = new BankInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    BankInformation objbank = new BankInformation();
                    int s = objbank.Bank_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Bank_Code = s.ToString();
                }
                else
                {
                    int code = information.Bank_Code + 1;
                    ViewBag.Bank_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(BankInformation bankInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                bankInformation.Entry_By = LogedInUser;
                bankInformation.Entry_Date = DateTime.Now;
                db.BankInformations.Add(bankInformation);

                if (bankInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {

                    var BankList = db.BankInformations.Where(a => a.Bank_Code != bankInformation.Bank_Code).ToList();

                    foreach (var item in BankList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(bankInformation);

        }
        // GET: BankInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankInformation bankInformation = db.BankInformations.Find(id);
            if (bankInformation == null)
            {
                return HttpNotFound();
            }
            return View(bankInformation);
        }

        // GET: BankInformation/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: BankInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "BankId,Bank_Code,Long_Desc,Status,Default_Code,Entry_Date")] BankInformation bankInformation)
        {
            if (ModelState.IsValid)
            {
                db.BankInformations.Add(bankInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankInformation);
        }

        // GET: BankInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankInformation bankInformation = db.BankInformations.Find(id);
            if (bankInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(bankInformation);
        }

        // POST: BankInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankInformation bankInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                bankInformation.Entry_By = LogedInUser;
                bankInformation.Entry_Date = DateTime.Now;
                db.Entry(bankInformation).State = EntityState.Modified;

                var list = db.BankInformations.Where(a => a.Bank_Code != bankInformation.Bank_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankInformation);
        }

        // GET: BankInformation/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BankInformation bankInformation = db.BankInformations.Where(x => x.BankId == id).FirstOrDefault<BankInformation>();
                db.BankInformations.Remove(bankInformation);
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
