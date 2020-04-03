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
    public class CargoTypeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CargoTypeInformation
        public ActionResult Index()
        {
            return View(db.CargoTypeInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<CargoTypeInformation> CargoTypeInformations = db.CargoTypeInformations.ToList<CargoTypeInformation>();
            return Json(new { data = CargoTypeInformations }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Create()
        {
           // String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
           // ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CargoTypeInformation CargoTypeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                CargoTypeInformation.Entry_By = LogedInUser;
                CargoTypeInformation.Entry_Date = DateTime.Now;
                db.CargoTypeInformations.Add(CargoTypeInformation);
               

                if (CargoTypeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {

                    var CargoTypeList = db.CargoTypeInformations.Where(a => a.Cargo_Code != CargoTypeInformation.Cargo_Code).ToList();

                    foreach (var item in CargoTypeList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CargoTypeInformation);

        }



        [HttpGet]
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Add(CargoTypeInformation CargoTypeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.CargoTypeInformations.Add(CargoTypeInformation);

                if (CargoTypeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {

                    var CargoTypeList = db.CargoTypeInformations.Where(a => a.Cargo_Code != CargoTypeInformation.Cargo_Code).ToList();

                    foreach (var item in CargoTypeList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CargoTypeInformation);

        }

        // GET: CargoTypeInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CargoTypeInformation cargoTypeInformation = db.CargoTypeInformations.Find(id);
        //    if (cargoTypeInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cargoTypeInformation);
        //}

        //// GET: CargoTypeInformation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CargoTypeInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CargoTypeId,Cargo_Code,Long_Desc,Status,Default_Code,Entry_Date")] CargoTypeInformation cargoTypeInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CargoTypeInformations.Add(cargoTypeInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(cargoTypeInformation);
        //}

        // GET: CargoTypeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CargoTypeInformation cargoTypeInformation = db.CargoTypeInformations.Find(id);
            if (cargoTypeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(cargoTypeInformation);
        }

        // POST: CargoTypeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CargoTypeInformation cargoTypeInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                cargoTypeInformation.Entry_By = LogedInUser;
                cargoTypeInformation.Entry_Date = DateTime.Now;
                db.CargoTypeInformations.Add(cargoTypeInformation);
                db.CargoTypeInformations.Add(cargoTypeInformation);

                db.Entry(cargoTypeInformation).State = EntityState.Modified;

                var list = db.CargoTypeInformations.Where(a => a.Cargo_Code != cargoTypeInformation.Cargo_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargoTypeInformation);
        }

        // GET: CargoTypeInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CargoTypeInformation CargoTypeInformations = db.CargoTypeInformations.Where(x => x.CargoTypeId == id).FirstOrDefault<CargoTypeInformation>();
                db.CargoTypeInformations.Remove(CargoTypeInformations);
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
