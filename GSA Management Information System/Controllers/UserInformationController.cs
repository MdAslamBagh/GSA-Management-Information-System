//using System;
////using DataTables.AspNet.Mvc5;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using GSA_Management_Information_System.Models;

//namespace GSA_Management_Information_System.Controllers
//{
//    public class UserInformationController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: UserInformation
//        public ActionResult Index() 
//        {
//            return View(db.UserInformations.ToList());
//        }

//        [HttpGet]
//        public ActionResult GetData()
//        {
//            List<UserInformation> UserInformations = db.UserInformations.ToList<UserInformation>();
//              return Json(new {data= UserInformations},JsonRequestBehavior.AllowGet);

//        }

//        [HttpGet]
//        public ActionResult AddOrEdit(int id = 0)
//        {
//            ViewBag.Name = new SelectList(db.RoleInformations.Select(u => u.Name).ToList());
//            if (id == 0)                
//            return View(new UserInformation());

//            else
//            {

//                using (ApplicationDbContext db = new ApplicationDbContext())
//                {
//                     ViewBag.Name = new SelectList(db.RoleInformations.Select(u => u.Name).ToList());
//                    return View(db.UserInformations.Where(x => x.UserId == id).FirstOrDefault<UserInformation>());

//                }
//            }
//        }

//        [HttpPost]
//        public ActionResult AddOrEdit(UserInformation userInformation)
//        {

//            if (userInformation.UserId == 0)
//            {

//                db.UserInformations.Add(userInformation);
//                db.SaveChanges();
//                return RedirectToAction("Index"); 
//                //return Json(new { success = true, message = "Saved Successsfully" }, JsonRequestBehavior.AllowGet);

//            }

//            else
//            {

//                db.Entry(userInformation).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");

//                //return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
//            }
//        }


//        [HttpPost]
//        public ActionResult Delete(int id)
//        {
//                using (ApplicationDbContext db = new ApplicationDbContext())
//                {
//                UserInformation UserInformations=db.UserInformations.Where(x => x.UserId == id).FirstOrDefault<UserInformation>();
//                db.UserInformations.Remove(UserInformations);
//                db.SaveChanges();
//                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
//            }


//            }



//        //public ActionResult getdata()
//        //{
//        //    List<UserInformation> UserInformations = db.UserInformations.ToList<UserInformation>();
//        //    return Json(new { UserInformations= UserInformations },JsonRequestBehavior.AllowGet);
//        //}

//        //public ActionResult postdata(int UserId)
//        //{

//        //    return View();
//        //}

//        // GET: UserInformation/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {;
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserInformation userInformation = db.UserInformations.Find(id);
//            if (userInformation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userInformation);
//        }

//        // GET: UserInformation/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserInformation/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "UserId,First_Name,Last_Name,Email,Address,Phoneno,Password,Confirm_Password")] UserInformation userInformation)
//        {
//            if (ModelState.IsValid)
//            {
//                db.UserInformations.Add(userInformation);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(userInformation);
//        }

//        // GET: UserInformation/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserInformation userInformation = db.UserInformations.Find(id);
//            if (userInformation == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userInformation);
//        }

//        // POST: UserInformation/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "UserId,First_Name,Last_Name,Email,Address,Phoneno,Password,Confirm_Password")] UserInformation userInformation)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userInformation).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(userInformation);
//        }

//        // GET: UserInformation/Delete/5
//        //public ActionResult Delete(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    UserInformation userInformation = db.UserInformations.Find(id);
//        //    if (userInformation == null)
//        //    {
//        //        return HttpNotFound();
//        //    }
//        //    return View(userInformation);
//        //}

//        // POST: UserInformation/Delete/5
//        //[HttpPost, ActionName("Delete")]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult DeleteConfirmed(int id)
//        //{
//        //    UserInformation userInformation = db.UserInformations.Find(id);
//        //    db.UserInformations.Remove(userInformation);
//        //    db.SaveChanges();
//        //    return RedirectToAction("Index");
//        //}

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
