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
    public class AccessInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessListInformation
        //public ActionResult Index()
        //{
        //    return View(db.AccessLists.ToList());
        //}

        // GET: AccessListInformation/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}


        //GET: AccessInformation/AccessList/5
        //public ActionResult AccessList(string Id)
        //{
        //    //var GroupList = db.Roles.ToList();
        //    //List<RoleViewModel> list = GroupList;
        //    //list = list.Where(a => a.Id == id).ToList();
        //    //ViewBag.GroupList = list;
        //    ViewBag.RoleID = new SelectList(db.Roles.Where(a => a.Id == Id.ToString()), "Id", "Name");
        //    ViewBag.Id = Id;
        //    return View();
        //}

        [HttpPost]
        public JsonResult AccessList(Models.AccessInformation accessInfo)
        {
            try
            {
                // TODO: Add insert logic here
                accessInfo.RoleStatus = 1;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (ModelState.IsValid)
                    {
                        var previuosAccess = db.AccessInformations.Where(a => a.RoleId == accessInfo.RoleId).FirstOrDefault();
                        if (previuosAccess != null)
                        {
                            previuosAccess.SubMenuList = accessInfo.SubMenuList;
                            db.Entry(previuosAccess).State = EntityState.Modified;
                        }
                        else
                        {
                            db.AccessInformations.Add(accessInfo);
                        }
                        db.SaveChanges();
                        return Json("Success", JsonRequestBehavior.AllowGet);
                    }

                }
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
            }
            catch (Exception ex)

            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
            }
        }

        //AccessInformation/PermisssionList
        public JsonResult PermisssionList()
        {

            // select c.Menu_Name,d.Access_Name,d.Controller_Name,d.Action_Name from MenuItemInformations c join SubMenuInformations d on c.MenuItemId = d.MenuItemId
            // var submenulist=from
            var submenulist = from menu in db.MenuInformations join submenu in db.SubMenuInformations on menu.MenuItemId equals submenu.MenuItemId orderby menu.Menu_Name select new { menu.Menu_Name, menu.MenuItemId, submenu.SubMenuId, submenu.Access_Name, submenu.Controller_Name, submenu.Action_Name };

            return Json(submenulist, JsonRequestBehavior.AllowGet);


        }

        public JsonResult PermisssionListById(string id)
        {
            //RoleViewModel role = new RoleViewModel();
            //role.Id = id.ToString();

            string[] list = { };
            var PermisssionList = db.AccessInformations.Where(a => a.RoleId == id.ToString()).FirstOrDefault();
            
            if (PermisssionList != null)
            {
                list = PermisssionList.SubMenuList.Split(',');
            }
            //List<string> list = new List<string>();
            //foreach (var item in PermisssionList)
            //{
            //    list.Add(item);
            //}
            // AccessInformation access = db.AccessInformations.Where(role.Id);
            return Json(list, JsonRequestBehavior.AllowGet);

        }

       



        // POST: AccessMapper/Edit/5
        [HttpPost]
        public JsonResult Edit(AccessInformation acccess)
        {
            try
            {
                // TODO: Add insert logic here
                //accessMapperViewModel.CreateDate = DateTime.Now;
                //accessMapperViewModel.CreateTime = DateTime.Now;
                //acccess.MapperName = "";
                //using (var repository = new WebApiClientRepository<Models.AccessMapper>())
                //{
                if (ModelState.IsValid)
                {
                    // Models.AccessMapper accessMapper = new Models.AccessMapper();
                    AccessInformation access = new AccessInformation();

                    //access.AccessListId = accessMapperViewModel.MapperID;
                    //accessMapper.AccessList = accessMapperViewModel.AccessList;
                    //accessMapper.CreateDate = DateTime.Now;
                    //accessMapper.CreateTime = DateTime.Now;
                    //accessMapper.RoleStatus = 0;
                    //accessMapper.IsVisible = 0;
                    //if (repository.GlobalApiCallFunction(accessMapper, "UpdateNewAccessMapper").Success)
                    //{
                    //    return Json("Success", JsonRequestBehavior.AllowGet);
                    //}

                    //}

                }
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
            }
            catch

            {
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
            }
        }


        public ActionResult Role_Create()
        {
            return View();
        }

        // POST: RoleInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.




        // POST: RoleInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: AccessListInformation/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}

        //// POST: AccessListInformation/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "AccessId,AccessName,BaseModule,Controller,Action")] AccessListInformation accessListInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(accessListInformation).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(accessListInformation);
        //}

        //// GET: AccessListInformation/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    if (accessListInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(accessListInformation);
        //}

        //// POST: AccessListInformation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AccessListInformation accessListInformation = db.AccessLists.Find(id);
        //    db.AccessLists.Remove(accessListInformation);
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
