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
    public class FreighterInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FreighterInformation
        public ActionResult Index()
        {
            return View(db.FreighterInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<FreighterInformation> Informations = db.FreighterInformations.ToList<FreighterInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
             //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
           // ViewBag.Entry_Date = today;
            List<FreighterInformation> Informations = db.FreighterInformations.OrderByDescending(a => a.FreighterId).ToList<FreighterInformation>();

            try
            {
                FreighterInformation information = new FreighterInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    FreighterInformation objinformations = new FreighterInformation();
                    int s = objinformations.Freighter_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Freighter_Code = s.ToString();
                }
                else
                {
                    int code = information.Freighter_Code + 1;
                    ViewBag.Freighter_Code = code.ToString();//.PadLeft(4, '0');
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
        public ActionResult Create(FreighterInformation objfreighter)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objfreighter.Entry_By = LogedInUser;
                objfreighter.Entry_Date = DateTime.Now;
                db.FreighterInformations.Add(objfreighter);
                if (objfreighter.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var freighterlist = db.FreighterInformations.Where(a => a.Freighter_Code != objfreighter.Freighter_Code).ToList();

                    foreach (var item in freighterlist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(objfreighter);

        }



        // GET: FreighterInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreighterInformation Informations = db.FreighterInformations.Find(id);
            if (Informations == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
           
            return View(Informations);
        }

        // POST: FreighterInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( FreighterInformation objfreighter)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objfreighter.Entry_By = LogedInUser;
                objfreighter.Entry_Date = DateTime.Now;

                db.Entry(objfreighter).State = EntityState.Modified;
                var list = db.FreighterInformations.Where(a => a.Freighter_Code != objfreighter.Freighter_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objfreighter);
        }

        // GET: FreighterInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                FreighterInformation Informations = db.FreighterInformations.Where(x => x.FreighterId == id).FirstOrDefault<FreighterInformation>();
                db.FreighterInformations.Remove(Informations);
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
