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
    public class CustomerInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerInformation
        public ActionResult Index()
        {
            return View(db.CustomerInformations.ToList());
        }

        public ActionResult GetData()
        {
            List<CustomerInformation> Informations = db.CustomerInformations.ToList<CustomerInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        // GET: CustomerInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            return View(customerInformation);
        }

        // GET: CustomerInformation/Create
        public ActionResult Add()
        {
            String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.Entry_Date = today;

            List<CustomerInformation> Informations = db.CustomerInformations.OrderByDescending(a => a.CustomerId).ToList<CustomerInformation>();

            try
            {
                CustomerInformation information = new CustomerInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    int seq = 1;
                    string ss = string.Format("CRGO-{0}", seq.ToString("D6"));

                    ViewBag.Customer_Code = ss;
                    //CustomerInformation objinformations = new CustomerInformation();
                    //int s = objinformations.Customer_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    //ViewBag.Customer_Code = s.ToString();
                }
                else
                {
                    CustomerInformation informationS = new CustomerInformation();
                 

                    information = Informations.FirstOrDefault();
                    string code = information.Customer_Code;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 6);
                    int codeee = Int32.Parse(mystring) + 1;
                   // string todaydate = DateTime.Now.ToString("yyMM");

                    string ss = string.Format("CRGO-{0}", codeee.ToString("D6"));

                    ViewBag.Customer_Code = ss;
                    //int code = information.Customer_Code + 1;
                    // ViewBag.Customer_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Type_Code = new SelectList(db.CustomerTypeInformations.Where(a=>a.Default_Code == true), "Type_Code", "Long_Desc");
            ViewBag.Group_Code = new SelectList(db.CustomerGroupInformations, "Group_Code", "Long_Desc");
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            ViewBag.City_Code = new SelectList(db.CityInformations, "City_Code", "Long_Desc");
            return View();
        }

        // POST: CustomerInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "CustomerId,Customer_Code,Bp_Code,Customer_Name,Type_Code,Group_Code,Address,Country_Code,City_Code,Contact_No,Fax,Email,Web,Contact_Person,Status,Default_Code,Entry_Date")] CustomerInformation customerInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                db.CustomerInformations.Add(customerInformation);

                if (customerInformation.Default_Code == false)
                {
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
                else
                {
                    var customerlist = db.CustomerInformations.Where(a => a.Customer_Code != customerInformation.Customer_Code).ToList();

                    foreach (var item in customerlist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }

            return View(customerInformation);
        }

        // GET: CustomerInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            ViewBag.Type_Code = new SelectList(db.CustomerTypeInformations, "Type_Code", "Long_Desc");
            ViewBag.Group_Code = new SelectList(db.CustomerGroupInformations, "Group_Code", "Long_Desc");
            ViewBag.Country_Code = new SelectList(db.CountryInformations, "Country_Code", "Long_Desc");
            ViewBag.City_Code = new SelectList(db.CityInformations, "City_Code", "Long_Desc");
            return View(customerInformation);
        }

        // POST: CustomerInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Customer_Code,Bp_Code,Customer_Name,Type_Code,Group_Code,Address,Country_Code,City_Code,Contact_No,Fax,Email,Web,Contact_Person,Status,Default_Code,Entry_Date")] CustomerInformation customerInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInformation).State = EntityState.Modified;
                var list = db.CustomerInformations.Where(a => a.Customer_Code != customerInformation.Customer_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInformation);
        }

        // GET: CustomerInformation/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CustomerInformation Informations = db.CustomerInformations.Where(x => x.CustomerId == id).FirstOrDefault<CustomerInformation>();
                db.CustomerInformations.Remove(Informations);
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
