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
    public class UplimentTypeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UplimentTypeInformation
        public ActionResult Index()
        {
            return View(db.UplimentTypeInformations.ToList());
        }


        // GET: UplimentTypeInformation/Details/5
        public ActionResult GetData()
        {
            List<UplimentTypeInformation> Informations = db.UplimentTypeInformations.ToList<UplimentTypeInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Add()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            List<UplimentTypeInformation> Informations = db.UplimentTypeInformations.OrderByDescending(a => a.UTypeId).ToList<UplimentTypeInformation>();

            try
            {
                UplimentTypeInformation information = new UplimentTypeInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    UplimentTypeInformation objinformations = new UplimentTypeInformation();
                    int s = objinformations.UType_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.UType_Code = s.ToString();
                }
                else
                {
                    int code = information.UType_Code + 1;
                    ViewBag.UType_Code = code.ToString();//.PadLeft(4, '0');
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
        public ActionResult Add(UplimentTypeInformation objupliment)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objupliment.Entry_By = LogedInUser;
                objupliment.Entry_Date = DateTime.Now;
                db.UplimentTypeInformations.Add(objupliment);
                if (objupliment.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var uplimentList = db.UplimentTypeInformations.Where(a => a.UType_Code != objupliment.UType_Code).ToList();

                    foreach (var item in uplimentList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(objupliment);

        }

        // GET: UplimentTypeInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UplimentTypeInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( UplimentTypeInformation uplimentTypeInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                uplimentTypeInformation.Entry_By = LogedInUser;
                uplimentTypeInformation.Entry_Date = DateTime.Now;
                db.UplimentTypeInformations.Add(uplimentTypeInformation);
                var uplimentList = db.UplimentTypeInformations.Where(a => a.UType_Code != uplimentTypeInformation.UType_Code).ToList();

                foreach (var item in uplimentList)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uplimentTypeInformation);
        }

        // GET: UplimentTypeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UplimentTypeInformation Informations = db.UplimentTypeInformations.Find(id);
            if (Informations == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(Informations);
        }

        // POST: UplimentTypeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( UplimentTypeInformation objupliment)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objupliment.Entry_By = LogedInUser;
                objupliment.Entry_Date = DateTime.Now;
                db.Entry(objupliment).State = EntityState.Modified;
                var list = db.UplimentTypeInformations.Where(a => a.UType_Code != objupliment.UType_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objupliment);
        }

        // GET: UplimentTypeInformation/Delete/5


        // POST: UplimentTypeInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UplimentTypeInformation Informations = db.UplimentTypeInformations.Where(x => x.UTypeId == id).FirstOrDefault<UplimentTypeInformation>();
                db.UplimentTypeInformations.Remove(Informations);
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
