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
    public class OriginInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OriginInformation
        public ActionResult Index()
        {
            return View(db.OriginInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<OriginInformation> OriginInformations = db.OriginInformations.ToList<OriginInformation>();
            return Json(new { data = OriginInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
                ViewBag.list = list;
                return View();            
        }

        [HttpPost]
        public ActionResult Create(OriginInformation OriginInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                OriginInformation.Entry_By = LogedInUser;
                OriginInformation.Entry_Date = DateTime.Now;
                db.OriginInformations.Add(OriginInformation);
                db.OriginInformations.Add(OriginInformation);

                if (OriginInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var originList = db.OriginInformations.Where(a => a.Origin_Code != OriginInformation.Origin_Code).ToList();

                    foreach (var item in originList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(OriginInformation);

        }

        // GET: OriginInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OriginInformation originInformation = db.OriginInformations.Find(id);
        //    if (originInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(originInformation);
        //}

        //// GET: OriginInformation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: OriginInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OriginId,Origin_Code,Long_Desc,Status,Default_Code,Entry_Date")] OriginInformation originInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.OriginInformations.Add(originInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(originInformation);
        //}

        // GET: OriginInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OriginInformation originInformation = db.OriginInformations.Find(id);
            if (originInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(originInformation);
        }

        // POST: OriginInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OriginInformation originInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                originInformation.Entry_By = LogedInUser;
                originInformation.Entry_Date = DateTime.Now;
                db.Entry(originInformation).State = EntityState.Modified;
                var list = db.OriginInformations.Where(a => a.Origin_Code != originInformation.Origin_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(originInformation);
        }

        // GET: OriginInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                OriginInformation OriginInformations = db.OriginInformations.Where(x => x.OriginId == id).FirstOrDefault<OriginInformation>();
                db.OriginInformations.Remove(OriginInformations);
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
