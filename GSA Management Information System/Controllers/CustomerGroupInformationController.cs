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
    public class CustomerGroupInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerGroupInformation
        public ActionResult Index()
        {
            return View(db.CustomerGroupInformations.ToList());
        }
        public ActionResult GetData()
        {
            List<CustomerGroupInformation> CustomerGroupInformations = db.CustomerGroupInformations.ToList<CustomerGroupInformation>();
            return Json(new { data = CustomerGroupInformations }, JsonRequestBehavior.AllowGet);

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
        public ActionResult Add(CustomerGroupInformation CustomerGroupInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.CustomerGroupInformations.Add(CustomerGroupInformation);
                if (CustomerGroupInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var customerGroupList = db.CustomerGroupInformations.Where(a => a.Group_Code != CustomerGroupInformation.Group_Code).ToList();

                    foreach (var item in customerGroupList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CustomerGroupInformation);

        }

        // GET: CustomerGroupInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CustomerGroupInformation customerGroupInformation = db.CustomerGroupInformations.Find(id);
        //    if (customerGroupInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customerGroupInformation);
        //}

        //// GET: CustomerGroupInformation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CustomerGroupInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CustomerGroupId,Group_Code,Long_Desc,Status,Default_Code,Entry_Date")] CustomerGroupInformation customerGroupInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CustomerGroupInformations.Add(customerGroupInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(customerGroupInformation);
        //}

        // GET: CustomerGroupInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGroupInformation customerGroupInformation = db.CustomerGroupInformations.Find(id);
            if (customerGroupInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(customerGroupInformation);
        }

        // POST: CustomerGroupInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerGroupId,Group_Code,Long_Desc,Status,Default_Code,Entry_Date")] CustomerGroupInformation customerGroupInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerGroupInformation).State = EntityState.Modified;
                var list = db.CustomerGroupInformations.Where(a => a.Group_Code != customerGroupInformation.Group_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerGroupInformation);
        }

        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CustomerGroupInformation CustomerGroupInformations = db.CustomerGroupInformations.Where(x => x.CustomerGroupId == id).FirstOrDefault<CustomerGroupInformation>();
                db.CustomerGroupInformations.Remove(CustomerGroupInformations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: CustomerGroupInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CustomerGroupInformation customerGroupInformation = db.CustomerGroupInformations.Find(id);
        //    if (customerGroupInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customerGroupInformation);
        //}

        //// POST: CustomerGroupInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CustomerGroupInformation customerGroupInformation = db.CustomerGroupInformations.Find(id);
        //    db.CustomerGroupInformations.Remove(customerGroupInformation);
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
