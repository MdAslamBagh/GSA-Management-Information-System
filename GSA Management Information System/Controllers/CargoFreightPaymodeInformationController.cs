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
    public class CargoFreightPaymodeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargoFreightPaymodeInformation
        public ActionResult Index()
        {
            return View(db.CargoFreightPaymodeInformations.ToList());
        }


        public ActionResult GetData()
        {
            List<CargoFreightPaymodeInformation> CargoFreightPaymodeInformations = db.CargoFreightPaymodeInformations.ToList<CargoFreightPaymodeInformation>();
            return Json(new { data = CargoFreightPaymodeInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;

            List<CargoFreightPaymodeInformation> Informations = db.CargoFreightPaymodeInformations.OrderByDescending(a => a.CFPaymodeId).ToList<CargoFreightPaymodeInformation>();

            try
            {
                CargoFreightPaymodeInformation information = new CargoFreightPaymodeInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    CargoFreightPaymodeInformation objfreightpaymode = new CargoFreightPaymodeInformation();
                    int s = objfreightpaymode.CFPaymode_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    ViewBag.CFPaymode_Code = s.ToString();
                }
                else
                {
                    int code = information.CFPaymode_Code + 1;
                    ViewBag.CFPaymode_Code = code.ToString();//.PadLeft(4, '0');
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
        public ActionResult Add(CargoFreightPaymodeInformation CargoFreightPaymodeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.CargoFreightPaymodeInformations.Add(CargoFreightPaymodeInformation);

                if (CargoFreightPaymodeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {

                    var CargoFreightList = db.CargoFreightPaymodeInformations.Where(a => a.CFPaymode_Code != CargoFreightPaymodeInformation.CFPaymode_Code).ToList();

                    foreach (var item in CargoFreightList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CargoFreightPaymodeInformation);

        }

        // GET: CargoFreightPaymodeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoFreightPaymodeInformation cargoFreightPaymodeInformation = db.CargoFreightPaymodeInformations.Find(id);
            if (cargoFreightPaymodeInformation == null)
            {
                return HttpNotFound();
            }
            return View(cargoFreightPaymodeInformation);
        }

        // GET: CargoFreightPaymodeInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargoFreightPaymodeInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CFPaymodeId,CFPaymode_Code,Long_Desc,Status,Default_Code,Entry_Date")] CargoFreightPaymodeInformation cargoFreightPaymodeInformation)
        {
            if (ModelState.IsValid)
            {
                db.CargoFreightPaymodeInformations.Add(cargoFreightPaymodeInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargoFreightPaymodeInformation);
        }

        // GET: CargoFreightPaymodeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoFreightPaymodeInformation cargoFreightPaymodeInformation = db.CargoFreightPaymodeInformations.Find(id);
            if (cargoFreightPaymodeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(cargoFreightPaymodeInformation);
        }

        // POST: CargoFreightPaymodeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CFPaymodeId,CFPaymode_Code,Long_Desc,Status,Default_Code,Entry_Date")] CargoFreightPaymodeInformation cargoFreightPaymodeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargoFreightPaymodeInformation).State = EntityState.Modified;

                var list = db.CargoFreightPaymodeInformations.Where(a => a.CFPaymode_Code != cargoFreightPaymodeInformation.CFPaymode_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargoFreightPaymodeInformation);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CargoFreightPaymodeInformation CargoFreightPaymodeInformations = db.CargoFreightPaymodeInformations.Where(x => x.CFPaymodeId == id).FirstOrDefault<CargoFreightPaymodeInformation>();
                db.CargoFreightPaymodeInformations.Remove(CargoFreightPaymodeInformations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: CargoFreightPaymodeInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CargoFreightPaymodeInformation cargoFreightPaymodeInformation = db.CargoFreightPaymodeInformations.Find(id);
        //    if (cargoFreightPaymodeInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cargoFreightPaymodeInformation);
        //}

        //// POST: CargoFreightPaymodeInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CargoFreightPaymodeInformation cargoFreightPaymodeInformation = db.CargoFreightPaymodeInformations.Find(id);
        //    db.CargoFreightPaymodeInformations.Remove(cargoFreightPaymodeInformation);
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
