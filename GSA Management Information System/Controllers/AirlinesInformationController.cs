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
    public class AirlinesInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AirlinesInformation
        public ActionResult Index()
        {
            return View(db.AirlinesInformations.ToList());
        }

        public ActionResult Indexx()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<AirlinesInformation> AirlinesInformations = db.AirlinesInformations.ToList<AirlinesInformation>();
            return Json(new { data = AirlinesInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Add()
        {

            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;

            List<AirlinesInformation> Informations = db.AirlinesInformations.OrderByDescending(a => a.AirlinesId).ToList<AirlinesInformation>();

            try
            {
                AirlinesInformation information = new AirlinesInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    AirlinesInformation objairlines = new AirlinesInformation();
                    int s = objairlines.Airlines_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.Airlines_Code = s.ToString();
                }
                else
                {
                    int code = information.Airlines_Code + 1;
                    ViewBag.Airlines_Code = code.ToString();//.PadLeft(4, '0');
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
        public ActionResult Add(AirlinesInformation AirlinesInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.AirlinesInformations.Add(AirlinesInformation);


                if (AirlinesInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var AirlinesList = db.AirlinesInformations.Where(a => a.Airlines_Code != AirlinesInformation.Airlines_Code).ToList();

                    foreach (var item in AirlinesList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(AirlinesInformation);

        }


        // GET: AirlinesInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AirlinesInformation airlinesInformation = db.AirlinesInformations.Find(id);
        //    if (airlinesInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(airlinesInformation);
        //}

        //// GET: AirlinesInformation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AirlinesInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "AirlinesId,Airlines_Code,Long_Desc,Status,Default_Code,Entry_Date")] AirlinesInformation airlinesInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AirlinesInformations.Add(airlinesInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(airlinesInformation);
        //}

        // GET: AirlinesInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirlinesInformation airlinesInformation = db.AirlinesInformations.Find(id);
            if (airlinesInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(airlinesInformation);
        }

        // POST: AirlinesInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AirlinesId,Airlines_Code,Long_Desc,Status,Default_Code,Entry_Date")] AirlinesInformation airlinesInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlinesInformation).State = EntityState.Modified;

                var list = db.AirlinesInformations.Where(a => a.Airlines_Code != airlinesInformation.Airlines_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(airlinesInformation);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AirlinesInformation AirlinesInformations = db.AirlinesInformations.Where(x => x.AirlinesId == id).FirstOrDefault<AirlinesInformation>();
                db.AirlinesInformations.Remove(AirlinesInformations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: AirlinesInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AirlinesInformation airlinesInformation = db.AirlinesInformations.Find(id);
        //    if (airlinesInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(airlinesInformation);
        //}

        //// POST: AirlinesInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AirlinesInformation airlinesInformation = db.AirlinesInformations.Find(id);
        //    db.AirlinesInformations.Remove(airlinesInformation);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
