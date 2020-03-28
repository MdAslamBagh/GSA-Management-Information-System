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
    public class ConsigneeInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConsigneeInformation
        public ActionResult Index()
        {
            return View(db.ConsigneeInformations.ToList());
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<ConsigneeInformation> Informations = db.ConsigneeInformations.ToList<ConsigneeInformation>();
            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public ActionResult Create()
        {
            //String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            ////String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;


            //var LogedInUser = User.Identity.Name;
            //ViewBag.Entry_By = LogedInUser;

            List<ConsigneeInformation> Informations = db.ConsigneeInformations.OrderByDescending(a=>a.ConsigneeId).ToList<ConsigneeInformation>();


            try
            {
                ConsigneeInformation information = new ConsigneeInformation();

                information = Informations.FirstOrDefault();
                if (information == null)
                {
                    int seq = 1;
                    string ss = string.Format("{0}", seq.ToString("D5"));

                    ViewBag.Consignee_Code = ss;
                    //int s = informations.Consignor_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    // ViewBag.Consignor_Code = s.ToString();
                }
                else
                {
                    ConsigneeInformation informations = new ConsigneeInformation();

                    information = Informations.FirstOrDefault();
                    string code = information.Consignee_Code;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 5);
                    int codeee = Int32.Parse(mystring) + 1;


                    string ss = string.Format("{0}", codeee.ToString("D5"));

                    ViewBag.Consignee_Code = ss;
                    // int code = information.Consignor_Code + 1;
                    // ViewBag.Consignor_Code = code.ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw;
            }




            //try
            //{
            //    ConsigneeInformation objconsignee = new ConsigneeInformation();
            //    objconsignee = Informations.FirstOrDefault();
            //    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
            //    int code = objconsignee.Consignee_Code + 1;
            //    ViewBag.Consignee_Code = code.ToString();//.PadLeft(4, '0');
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}




            var list = new List<string>() { "Active", "Inactive" };
                ViewBag.list = list;
                return View();          
        }

        [HttpPost]
        public ActionResult Create(ConsigneeInformation objconsignee)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
         

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objconsignee.Entry_By = LogedInUser;
                objconsignee.Entry_Date = DateTime.Now;
                db.ConsigneeInformations.Add(objconsignee);

                if (objconsignee.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {

                    var consigneeList = db.ConsigneeInformations.Where(a => a.Consignee_Code != objconsignee.Consignee_Code).ToList();

                    foreach (var item in consigneeList)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }
            return View(objconsignee);

        }

        // GET: ConsigneeInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ConsigneeInformation consigneeInformation = db.ConsigneeInformations.Find(id);
        //    if (consigneeInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(consigneeInformation);
        //}

        //// GET: ConsigneeInformation/Create
        //public ActionResult Create()
        //{
        //    var list = new List<string>() { "Active", "Inactive" };
        //    ViewBag.list = list;
        //    return View();
        //}

        //// POST: ConsigneeInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ConsigneeId,Consignee_Code,Consignee_Name,Consignee_Address,Email,Status,Default_Code,Entry_Date")] ConsigneeInformation consigneeInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ConsigneeInformations.Add(consigneeInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(consigneeInformation);
        //}

        //// GET: ConsigneeInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            //var LogedInUser = User.Identity.Name;
            //ViewBag.Entry_By = LogedInUser;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsigneeInformation Informations = db.ConsigneeInformations.Find(id);
            if (Informations == null)
            {
                return HttpNotFound();
            }
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
           
            return View(Informations);
        }

        // POST: ConsigneeInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsigneeId,Consignee_Code,Consignee_Name,Consignee_Address,Email,Status,Default_Code,Entry_Date,Entry_By")] ConsigneeInformation objconsignee)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                objconsignee.Entry_By = LogedInUser;
                objconsignee.Entry_Date = DateTime.Now;
                db.Entry(objconsignee).State = EntityState.Modified;

                var list = db.ConsigneeInformations.Where(a => a.Consignee_Code != objconsignee.Consignee_Code).ToList();

                foreach (var item in list)
                {
                    item.Default_Code = false;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objconsignee);
        }


        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ConsigneeInformation Informations = db.ConsigneeInformations.Where(x => x.ConsigneeId == id).FirstOrDefault<ConsigneeInformation>();
                db.ConsigneeInformations.Remove(Informations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: ConsigneeInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ConsigneeInformation consigneeInformation = db.ConsigneeInformations.Find(id);
        //    if (consigneeInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(consigneeInformation);
        //}

        //// POST: ConsigneeInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ConsigneeInformation consigneeInformation = db.ConsigneeInformations.Find(id);
        //    db.ConsigneeInformations.Remove(consigneeInformation);
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
