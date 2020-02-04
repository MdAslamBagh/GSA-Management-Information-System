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
    public class ContinentInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContinentInformation
        public ActionResult Index()
        {
            return View(db.ContinentInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<ContinentInformation> Informations = db.ContinentInformations.ToList<ContinentInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }
        // GET: ContinentInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContinentInformation continentInformation = db.ContinentInformations.Find(id);
            if (continentInformation == null)
            {
                return HttpNotFound();
            }
            return View(continentInformation);
        }

        // GET: ContinentInformation/Create
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            List<ContinentInformation> Informations = db.ContinentInformations.OrderByDescending(a => a.ContinentId).ToList<ContinentInformation>();

                ContinentInformation information = new ContinentInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    ContinentInformation objcontinent = new ContinentInformation();
                    int s = objcontinent.Continent_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Continent_Code = s.ToString();
                }
                else
                {
                    int code = information.Continent_Code + 1;
                    ViewBag.Continent_Code = code.ToString();//.PadLeft(4, '0');
                }
            
            return View();
        }

        // POST: ContinentInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContinentInformation continentInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                continentInformation.Entry_By = LogedInUser;
                continentInformation.Entry_Date = DateTime.Now;

                db.ContinentInformations.Add(continentInformation);
                if (continentInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var continentlist = db.ContinentInformations.Where(a => a.Continent_Code != continentInformation.Continent_Code).ToList();

                    foreach (var item in continentlist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(continentInformation);
        }

        // GET: ContinentInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContinentInformation continentInformation = db.ContinentInformations.Find(id);
            if (continentInformation == null)
            {
                return HttpNotFound();
            }

            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(continentInformation);
        }

        // POST: ContinentInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContinentInformation continentInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                continentInformation.Entry_By = LogedInUser;
                continentInformation.Entry_Date = DateTime.Now;
                db.Entry(continentInformation).State = EntityState.Modified;
                var list = db.ContinentInformations.Where(a => a.Continent_Code != continentInformation.Continent_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(continentInformation);
        }

        // GET: ContinentInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ContinentInformation Informations = db.ContinentInformations.Where(x => x.ContinentId == id).FirstOrDefault<ContinentInformation>();
                db.ContinentInformations.Remove(Informations);
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
