using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GSA_Management_Information_System.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GSA_Management_Information_System.Controllers
{
    public class GsaGroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationRoleManager _roleManager;

       // [CustomAuthorize]
        // GET: GSAGroup
        public ActionResult Index()
        {
            return View();
        }
        public GsaGroupController()
        {
        }

        public GsaGroupController(ApplicationRoleManager roleManager)
        {
           
            RoleManager = roleManager;
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //Get
        //TaxGroup/AccessList
        public ActionResult AccessList(string Id)
        {
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "Name");
            ViewBag.RoleID = new SelectList(db.Roles.Where(a => a.Id == Id.ToString()), "Id", "Name");
            ViewBag.Id = Id;
            return View();
        }


        //Post
        //TaxGroup/AccessList
        //[HttpPost]
        //public JsonResult AccessList(Models.AccessInformation accessInfo)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        accessInfo.RoleStatus = 1;
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var previuosAccess = db.AccessInformations.Where(a => a.RoleId == accessInfo.RoleId).FirstOrDefault();
        //                if (previuosAccess != null)
        //                {
        //                    previuosAccess.SubMenuList = accessInfo.SubMenuList;
        //                    db.Entry(previuosAccess).State = EntityState.Modified;
        //                }
        //                else
        //                {
        //                    db.AccessInformations.Add(accessInfo);
        //                }
        //                db.SaveChanges();
        //                return Json("Success", JsonRequestBehavior.AllowGet);
        //            }

        //        }
        //        return Json("Success", JsonRequestBehavior.AllowGet);
        //        //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
        //    }
        //    catch (Exception ex)

        //    {
        //        return Json("Failed", JsonRequestBehavior.AllowGet);
        //        //return RedirectToAction("Message", "Home", new { msg = "Error Updating Access" });
        //    }
        //}

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


        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(IdentityRole Role)
        //{
        //    IdentityResult Result = RoleManager.Create(new IdentityRole());
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(GsaGroup group)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(group.Name);
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Edit/Admin
        //[CustomAuthorize]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            GsaGroup group = new GsaGroup { Id = role.Id, Name = role.Name };
            return View(group);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] GsaGroup group)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(group.Id);
                role.Name = group.Name;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Roles/Delete/5
        //[CustomAuthorize]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                else
                {
                    result = await RoleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }



       
        public ActionResult Save()
        {
            return View();
        }

        //group data
        [HttpGet]
        public JsonResult GetGroupData()
        {

            //List<GSAGroup> Informations = db.GSAGroups.ToList<GSAGroup>();
            //return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);
            var Informations = db.Roles.Select(asset => new
            {
                RoleId = asset.Id.ToString(),
                RoleName = asset.Name
            }).ToList();

            return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        }

        //[HttpGet]
        //public ActionResult GetData()
        //{

        //    //List<GSAGroup> Informations = db.GSAGroups.ToList<GSAGroup>();
        //    //return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);
        //    var Informations = db.GSAGroups.Select(asset => new
        //     {
        //       GroupID = asset.GroupID.ToString(),
        //       GroupName = asset.GroupName
        //    }).ToList();

        //    return Json(new { data = Informations }, JsonRequestBehavior.AllowGet);

        //}


        // POST: GSAGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public JsonResult Save([Bind(Include = "GroupID,GroupName,GroupDescription")] GSAGroup gSAGroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        GSAGroup group = new GSAGroup
        //        {
        //            GroupName = gSAGroup.GroupName,
        //            GroupDescription = gSAGroup.GroupDescription,
                    
        //        };
        //        db.GSAGroups.Add(group);
        //        db.SaveChanges();
        //        return Json(group, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(0, JsonRequestBehavior.AllowGet);
        //    //db.GSAGroups.Add(gSAGroup);
        //    //db.SaveChanges();
        //    //return Json("Index");
        

        //    //return Json(gSAGroup);
        //}

        // GET: GSAGroup/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GSAGroup gSAGroup = db.GSAGroups.Find(id);
        //    if (gSAGroup == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gSAGroup);
        //}

        //// POST: GSAGroup/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "GroupID,GroupName,GroupDescription")] GSAGroup gSAGroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gSAGroup).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gSAGroup);
        //}

        //// GET: GSAGroup/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GSAGroup gSAGroup = db.GSAGroups.Find(id);
        //    if (gSAGroup == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gSAGroup);
        //}

        //// POST: GSAGroup/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    GSAGroup gSAGroup = db.GSAGroups.Find(id);
        //    db.GSAGroups.Remove(gSAGroup);
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
