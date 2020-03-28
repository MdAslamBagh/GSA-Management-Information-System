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
            List<CompanyInformation> companyInformations = db.CompanyInformations.Where(a => a.Default_Code == true).ToList<CompanyInformation>();
            CompanyInformation informations = new CompanyInformation();
            informations = companyInformations.FirstOrDefault();
            string Company_Name = informations.Company_Name;
            string Company_Code = informations.Company_Code;
            string Branch_Name = informations.Branch_Name;
            string Branch_Code = informations.Branch_Code;
            ViewBag.Company_Name = Company_Name;
            ViewBag.Company_Code = Company_Code;
            ViewBag.Branch_Name = Branch_Name;
            ViewBag.Branch_Code = Branch_Code;
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

        //Company
        public JsonResult Get_Company_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Company_Name = (from c in db.CompanyInformations
                                where c.Company_Name.StartsWith(Prefix)
                                select new { c.Company_Name });
            return Json(Company_Name, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetCompanyCodeById(string companyname)
        {
            var company_code = db.CompanyInformations.Where(m => m.Company_Name == companyname).FirstOrDefault();
            return Json(company_code, JsonRequestBehavior.AllowGet);
    }


    //Branch search and create
    public JsonResult Get_Branch_Name(string Prefix)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Origin_Name = (from c in db.CompanyInformations
                               where c.Branch_Name.StartsWith(Prefix)
                               select new { c.Branch_Name });
            return Json(Origin_Name, JsonRequestBehavior.AllowGet);

        }

        //Branch
        public JsonResult GetBranchCodeById(string branchname)
        {
            var branch_code = db.CompanyInformations.Where(m => m.Branch_Name == branchname).FirstOrDefault();
            return Json(branch_code, JsonRequestBehavior.AllowGet);
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
