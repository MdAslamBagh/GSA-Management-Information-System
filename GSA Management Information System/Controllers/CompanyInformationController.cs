using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_Management_Information_System.Models;
using System.IO;

namespace GSA_Management_Information_System.Controllers
{
    public class CompanyInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyInformation
        public ActionResult Index()
        {
            return View(db.CompanyInformations.ToList());
        }


        //public ActionResult ViewAll()
        //{
        //    return View(GetAllCompanyInformation());
        //}

        //IEnumerable<CompanyInformation> GetAllCompanyInformation()
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        return db.CompanyInformations.ToList<CompanyInformation>();
        //    }
        //}



        //[HttpGet]
        //public ActionResult AddOrEdit(int id = 0)
        //{
        //    CompanyInformation ci = new CompanyInformation();
        //    if (id != 0)
        //    {
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            ci = db.CompanyInformations.Where(x => x.CompanyID == id).FirstOrDefault<CompanyInformation>();
        //        }
        //    }
        //    return View(ci);
        //}


        //[HttpPost]
        //public ActionResult AddOrEdit(CompanyInformation ci)
        //{
        //    try
        //    {
        //        if (ci.Company_ImageUpload != null)
        //        {
        //            string fileName = Path.GetFileNameWithoutExtension(ci.Company_ImageUpload.FileName);
        //            string extension = Path.GetExtension(ci.Company_ImageUpload.FileName);
        //            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //            ci.Company_ImagePath = "~/AppFiles/Images/" + fileName;
        //            ci.Company_ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
        //        }
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            if (ci.CompanyID == 0)
        //            {
        //                db.CompanyInformations.Add(ci);
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                db.Entry(ci).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }
        //        }
        //        return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllCompanyInformation()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            CompanyInformation ci = db.CompanyInformations.Where(x => x.CompanyID == id).FirstOrDefault<CompanyInformation>();
        //            db.CompanyInformations.Remove(ci);
        //            db.SaveChanges();
        //        }
        //        return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllCompanyInformation()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        public ActionResult GetData()
        {
            List<CompanyInformation> CompanyInformations = db.CompanyInformations.ToList<CompanyInformation>();
            return Json(new { data = CompanyInformations }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Branch_Name = new SelectList(db.CompanyInformations, "Branch_Name", "Branch_Name");
           //var branchname = db.CompanyInformations.Where(a => a.Branch_Name == a.Branch_Name).FirstOrDefault();
           // ViewBag.Branch_Name = branchname;
            //List<CompanyInformation> Informations = db.CompanyInformations.ToList<CompanyInformation>();
            //CompanyInformation informations = new CompanyInformation();
            //informations = informations.FirstOrDefault();
            //string f_Name = informations.Long_Desc;
            //string f_Code = informations.Freighter_Code.ToString();
           //ViewBag.Freighter_Name = f_Name;
            //ViewBag.Freighter_Code = f_Code;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyInformation companyInformation)
        {

            string fileName = Path.GetFileNameWithoutExtension(companyInformation.Company_ImageUpload.FileName);
            string extension = Path.GetExtension(companyInformation.Company_ImageUpload.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            companyInformation.Company_ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            companyInformation.Company_ImageUpload.SaveAs(fileName);

            var LogedInUser = User.Identity.Name;
            var Entry_Date = System.DateTime.Now;
            companyInformation.Entry_Date = Entry_Date;
            companyInformation.Entry_By = LogedInUser;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                db.CompanyInformations.Add(companyInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

           
        }
        // GET: CompanyInformation/Details/5
        public ActionResult Details(int id)
        {

            CompanyInformation companyInformation = new CompanyInformation();
            using (ApplicationDbContext db=new ApplicationDbContext())
            {
                companyInformation=db.CompanyInformations.Where(x=>x.CompanyId==id).FirstOrDefault();
            }
            return View(companyInformation);
        }

        //// GET: CompanyInformation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CompanyInformation/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       // [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CompanyID,Company_Name,Company_Code,Branch_Name,Branch_Code,Company_Tin,Company_Address,Company_Postcode,Company_City,Company_Country,Company_ContacNo,Company_Fax,Company_Email,Company_Web,Company_Dialogue,Company_ImagePath")] CompanyInformation companyInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CompanyInformations.Add(companyInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(companyInformation);
        //}

        //public ActionResult Create(CompanyInformation companyInformation)
        //{
        //    if (companyInformation.Company_ImageUpload != null)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(companyInformation.Company_ImageUpload.FileName);
        //        string extension = Path.GetExtension(companyInformation.Company_ImageUpload.FileName);
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        companyInformation.Company_ImagePath = "~/AppFiles/Images/" + fileName;
        //        companyInformation.Company_ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
        //    }

        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {

        //        db.CompanyInformations.Add(companyInformation);
        //        db.SaveChanges();

        //    }
        //    ModelState.Clear();
        //    return View();
        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.CompanyInformations.Add(companyInformation);
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}

        //}

        //public ActionResult Create(CompanyInformation companyInformation)
        //{

        //            string fileName = Path.GetFileNameWithoutExtension(companyInformation.Company_ImageUpload.FileName);
        //            string extension = Path.GetExtension(companyInformation.Company_ImageUpload.FileName);
        //            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //            companyInformation.Company_ImagePath = "~/Image/" + fileName;
        //            fileName=Path.Combine(Server.MapPath("~/Image/"),fileName);
        //    companyInformation.Company_ImageUpload.SaveAs(fileName);
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
                
        //            db.CompanyInformations.Add(companyInformation);
        //            db.SaveChanges();
        //        }
        //    ModelState.Clear();

        //        return View();        
        //}
        // GET: CompanyInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInformation companyInformation = db.CompanyInformations.Find(id);
            if (companyInformation == null)
            {
                return HttpNotFound();
            }


            return View(companyInformation);
        }

        // POST: CompanyInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,Company_Name,Company_Code,Branch_Name,Branch_Code,Company_Tin,Company_Address,Company_Postcode,Company_City,Company_Country,Company_ContacNo,Company_Fax,Company_Email,Company_Web,Company_Dialogue,Company_ImagePath")] CompanyInformation companyInformation)
        {
            if (ModelState.IsValid)
            {
                var LogedInUser = User.Identity.Name;
                var Entry_Date = System.DateTime.Now;
                companyInformation.Entry_Date = Entry_Date;
                companyInformation.Entry_By = LogedInUser;
                db.Entry(companyInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyInformation);
        }

        // GET: CompanyInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CompanyInformation CompanyInformations = db.CompanyInformations.Where(x => x.CompanyId == id).FirstOrDefault<CompanyInformation>();
                db.CompanyInformations.Remove(CompanyInformations);
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
