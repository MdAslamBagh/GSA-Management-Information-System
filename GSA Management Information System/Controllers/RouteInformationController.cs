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
    public class RouteInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RouteInformation
        public ActionResult Index()
        {
            return View(db.RouteInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<RouteInformation> Informations = db.RouteInformations.ToList<RouteInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }
        // GET: RouteInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInformation routeInformation = db.RouteInformations.Find(id);
            if (routeInformation == null)
            {
                return HttpNotFound();
            }
            return View(routeInformation);
        }

        // GET: RouteInformation/Create
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            ////String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            ViewBag.Type_Code = new SelectList(db.CustomerTypeInformations, "Type_Code", "Long_Desc");
            return View();
        }

        public int DuplicateCount(RouteInformation routeInformation)
        {
            List<RouteInformation> _checkUnique = (from d in db.RouteInformations
                                                  where d.Route_Code == routeInformation.Route_Code
                                                  select d).ToList();
            return _checkUnique.Count;
        }
        // POST: RouteInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RouteInformation routeInformation)
        {

            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                routeInformation.Entry_By = LogedInUser;
                routeInformation.Entry_Date = DateTime.Now;

                //check if values is duplicate
                int count = DuplicateCount(routeInformation);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Already Exists!!";
                     ViewBag.Type_Code = new SelectList(db.CustomerTypeInformations, "Type_Code", "Long_Desc");
                    return View(routeInformation);
                }


                db.RouteInformations.Add(routeInformation);

                if (routeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var routelist = db.RouteInformations.Where(a => a.Route_Code != routeInformation.Route_Code).ToList();

                    foreach (var item in routelist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routeInformation);
        }

        // GET: RouteInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInformation routeInformation = db.RouteInformations.Find(id);
            if (routeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Type_Code = new SelectList(db.CustomerTypeInformations, "Type_Code", "Long_Desc");
            return View(routeInformation);
        }

        // POST: RouteInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteInformation routeInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                routeInformation.Entry_By = LogedInUser;
                routeInformation.Entry_Date = DateTime.Now;
                db.Entry(routeInformation).State = EntityState.Modified;
                var list = db.RouteInformations.Where(a => a.Route_Code != routeInformation.Route_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routeInformation);
        }

        // GET: RouteInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                RouteInformation Informations = db.RouteInformations.Where(x => x.RouteId == id).FirstOrDefault<RouteInformation>();
                db.RouteInformations.Remove(Informations);
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
