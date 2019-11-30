using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using GSA_Management_Information_System.Models;

namespace GSA_Management_Information_System.Controllers
{
    public class CustomerTypeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerTypeInformation
        public ActionResult Index()
        {
            return View(db.CustomerTypeInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<CustomerTypeInformation> CustomerTypeInformations = db.CustomerTypeInformations.ToList<CustomerTypeInformation>();
            return Json(new { data = CustomerTypeInformations }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Export()
        {

            ReportDocument rd = new ReportDocument();
            //D:\project\Software\GSA Management Information System\Reports\rptTest.rpt
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "crpCargoSalesSummeryAgentwise.rpt"));
            rd.SetDataSource(db.CargoSalesInformations.Select(p => new
            {
                Id = p.Airway_No,
                Name = p.Freighter_Code,
                Price = p.AMS,
                Quantity = p.HDS
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File("application/pdf", "ListProducts.pdf");

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
        public ActionResult Add(CustomerTypeInformation CustomerTypeInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                db.CustomerTypeInformations.Add(CustomerTypeInformation);

                if (CustomerTypeInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var customerTypeList = db.CustomerTypeInformations.Where(a => a.Type_Code != CustomerTypeInformation.Type_Code).ToList();

                    foreach (var item in customerTypeList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(CustomerTypeInformation);

        }

        // GET: CustomerTypeInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTypeInformation customerTypeInformation = db.CustomerTypeInformations.Find(id);
            if (customerTypeInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerTypeInformation);
        }

        // GET: CustomerTypeInformation/Create
        //public ActionResult Create(int id=0)
        //{
        //    if (id == 0)
        //    {
        //        var list = new List<string>() { "Active", "Inactive" };
        //        ViewBag.list = list;
        //        return View();

        //    }


        //    else
        //    {
        //        var list = new List<string>() { "Active", "Inactive" };
        //        ViewBag.list = list;
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            return View(db.CustomerTypeInformations.Where(x => x.CustomerTypeId == id).FirstOrDefault<CustomerTypeInformation>());

        //        }
        //    }
        //}

    


        //// POST: CustomerTypeInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CustomerTypeId,Type_Code,Long_Desc,Status,Default_Code,Entry_Date")] CustomerTypeInformation customerTypeInformation)
        //{

        //    if (customerTypeInformation.CustomerTypeId == 0)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.CustomerTypeInformations.Add(customerTypeInformation);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        db.Entry(customerTypeInformation).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

          
        //    return View(customerTypeInformation);
        //}

        // GET: CustomerTypeInformation/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTypeInformation CustomerTypeInformation = db.CustomerTypeInformations.Find(id);
            if (CustomerTypeInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(CustomerTypeInformation);
           
        }

        // POST: CustomerTypeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerTypeId,Type_Code,Long_Desc,Status,Default_Code,Entry_Date")] CustomerTypeInformation CustomerTypeInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CustomerTypeInformation).State = EntityState.Modified;

                var list = db.CustomerTypeInformations.Where(a=>a.Type_Code != CustomerTypeInformation.Type_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }



                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CustomerTypeInformation);
        }

        // GET: CustomerTypeInformation/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CustomerTypeInformation CustomerTypeInformations = db.CustomerTypeInformations.Where(x => x.CustomerTypeId == id).FirstOrDefault<CustomerTypeInformation>();
                db.CustomerTypeInformations.Remove(CustomerTypeInformations);
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
