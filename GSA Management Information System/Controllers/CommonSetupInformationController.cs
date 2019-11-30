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
    public class CommonSetupInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommonSetupInformation
        public ActionResult Index()
        {
            return View(db.CommonSetupInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<CommonSetupInformation> Informations = db.CommonSetupInformations.ToList<CommonSetupInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: CommonSetupInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonSetupInformation commonSetupInformation = db.CommonSetupInformations.Find(id);
            if (commonSetupInformation == null)
            {
                return HttpNotFound();
            }
            return View(commonSetupInformation);
        }

        // GET: CommonSetupInformation/Create
        public ActionResult Add()
        {
            List<CommonSetupInformation> Informations = db.CommonSetupInformations.OrderByDescending(a => a.CommonId).ToList<CommonSetupInformation>();

            try
            {
                CommonSetupInformation information = new CommonSetupInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    CommonSetupInformation objinformations = new CommonSetupInformation();
                    int s = objinformations.SerialNo + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.SerialNo = s.ToString();
                }
                else
                {
                    int code = information.SerialNo + 1;
                    ViewBag.SerialNo = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return View();
        }

        // POST: CommonSetupInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "CommonId,SerialNo,Particulars,Description,Particular_Value,Minimum_Value,Entry_Date")] CommonSetupInformation commonSetupInformation)
        {
            if (ModelState.IsValid)
            {
                db.CommonSetupInformations.Add(commonSetupInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commonSetupInformation);
        }

        // GET: CommonSetupInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonSetupInformation commonSetupInformation = db.CommonSetupInformations.Find(id);
            if (commonSetupInformation == null)
            {
                return HttpNotFound();
            }
            return View(commonSetupInformation);
        }

        // POST: CommonSetupInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommonId,SerialNo,Particulars,Description,Particular_Value,Minimum_Value,Entry_Date")] CommonSetupInformation commonSetupInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commonSetupInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commonSetupInformation);
        }

        // GET: CommonSetupInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CommonSetupInformation Informations = db.CommonSetupInformations.Where(x => x.CommonId == id).FirstOrDefault<CommonSetupInformation>();
                db.CommonSetupInformations.Remove(Informations);
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
