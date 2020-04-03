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
    public class ConsignorInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConsignorInformation
        public ActionResult Index()
        {
            return View(db.ConsignorInformations.ToList());
        }


        public ActionResult GetData()
        {
            List<ConsignorInformation> ConsignorInformations = db.ConsignorInformations.ToList<ConsignorInformation>();
            return Json(new { data = ConsignorInformations }, JsonRequestBehavior.AllowGet);

        }

        // GET: ConsignorInformation/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            //String today = DateTime.Now.ToString("MM/dd/yyyy");
            //String today= DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            ////String today = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            //ViewBag.Entry_Date = today;

            //var LogedInUser = User.Identity.Name;
            //ViewBag.Entry_By = LogedInUser;


            List<ConsignorInformation> consignorInformations = db.ConsignorInformations.OrderByDescending(a => a.ConsignorId).ToList<ConsignorInformation>();

            try
            {
                ConsignorInformation information= new ConsignorInformation();
     
                information = consignorInformations.FirstOrDefault();
                if (information==null)
                {
                    int seq = 1;
                    string ss = string.Format("{0}", seq.ToString("D5"));

                    ViewBag.Consignor_Code = ss;
                    //int s = informations.Consignor_Code + 1;
                    //ViewBag.ConsignorCode = information.Consignor_Code + 1;
                    // ViewBag.Consignor_Code = s.ToString();
                }
                else
                {
                    ConsignorInformation informations = new ConsignorInformation();

                    information = consignorInformations.FirstOrDefault();
                    string code = information.Consignor_Code;

                    string mystring = code;
                    mystring = mystring.Substring(mystring.Length - 5);
                    int codeee = Int32.Parse(mystring) + 1;
                   

                    string ss = string.Format("{0}",codeee.ToString("D5"));

                    ViewBag.Consignor_Code = ss;
                    // int code = information.Consignor_Code + 1;
                    // ViewBag.Consignor_Code = code.ToString();//.PadLeft(4, '0');
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


        // POST: ConsignorInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ConsignorInformation consignorInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;

            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                consignorInformation.Entry_By = LogedInUser;
                consignorInformation.Entry_Date = DateTime.Now;
                //int x = Convert.ToInt32(TempData["ConsignorCode"]);
                //string y = (TempData["Data2"]).ToString();
                //consignorInformation.Consignor_Code = Convert.ToInt32(consignorInformation.Consignor_Code);
                db.ConsignorInformations.Add(consignorInformation);

                if (consignorInformation.Default_Code == false)
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                else
                {
                    var consignorlist = db.ConsignorInformations.Where(a => a.Consignor_Code != consignorInformation.Consignor_Code).ToList();

                    foreach (var item in consignorlist)
                    {
                        item.Default_Code = false;

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);
            }

            return View(consignorInformation);

        }

        // GET: ConsignorInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsignorInformation consignorInformation = db.ConsignorInformations.Find(id);
            if (consignorInformation == null)
            {
                return HttpNotFound();
            }
            return View(consignorInformation);
        }

        
    

      
        // GET: ConsignorInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            var LogedInUser = User.Identity.Name;
            ViewBag.Entry_By = LogedInUser;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsignorInformation consignorInformation = db.ConsignorInformations.Find(id);
            if (consignorInformation == null)
            {
                return HttpNotFound();
            }

            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            return View(consignorInformation);
        }

        // POST: ConsignorInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsignorInformation consignorInformation)
        {
            var list = new List<string>() { "Active", "Inactive" };
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                consignorInformation.Entry_By = LogedInUser;
                consignorInformation.Entry_Date = DateTime.Now;
                db.Entry(consignorInformation).State = EntityState.Modified;

                var consignordefault = db.ConsignorInformations.Where(a => a.Consignor_Code != consignorInformation.Consignor_Code).ToList();

                foreach (var item in consignordefault)
                {
                    item.Default_Code = false;

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consignorInformation);
        }


        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ConsignorInformation ConsignorInformations = db.ConsignorInformations.Where(x => x.ConsignorId == id).FirstOrDefault<ConsignorInformation>();
                db.ConsignorInformations.Remove(ConsignorInformations);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: ConsignorInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ConsignorInformation consignorInformation = db.ConsignorInformations.Find(id);
        //    if (consignorInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(consignorInformation);
        //}

        //// POST: ConsignorInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ConsignorInformation consignorInformation = db.ConsignorInformations.Find(id);
        //    db.ConsignorInformations.Remove(consignorInformation);
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
