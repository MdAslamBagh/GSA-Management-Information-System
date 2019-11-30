using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GSA_Management_Information_System.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;

namespace GSA_Management_Information_System.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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

        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetData()
        {
            //var userList = UserManager.Users.Select(asset => new
            //{
            //Id = asset.Id,
            //NameIdentifier=asset.NameIdentifier,
            //UserName = asset.UserName,
            //  Email = asset.Email
            //}).ToList();
            //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userList = UserManager.Users.ToList();
            return Json(new { data = userList }, JsonRequestBehavior.AllowGet);

        }
        //menulist
        public JsonResult RootMenu()
        {
            //try
            //{
            //    Menu menu = new Menu();
            //    //Helper.CustomAuthorizationAttribute customAuthorizationHelper = new Helper.CustomAuthorizationAttribute();
            //    List<AccessInformation> AllAccesslist = new List<AccessInformation>();

            //    List<MenuItemInformation> menueList = new List<MenuItemInformation>();

            //    List<int> AccesList = new List<int>();
            //    using (ApplicationDbContext db = new ApplicationDbContext())
            //    {
            //        var userid = User.Identity.GetUserId();
            //        // var userRoles = await UserManager.GetRolesAsync(userid);
            //        string role = "";
            //        var user = UserManager.FindById(userid);
            //        foreach (IdentityUserRole roleId in user.Roles)
            //        {
            //            role = roleId.RoleId;
            //        }
            //        int GroupID = customAuthorizationHelper.GetGroupID(User.Identity.GetUserId());

            //        //string UserName = customAuthorizationHelper.GetUserName(User.Identity.GetUserId());
            //        //string GroupName = unit.PmsGroupRepository.GetByID();

            //        string LoggedInUser = User.Identity.GetUserId();
            //        var UserName = UserManager.FindById(LoggedInUser).UserName; ;
            //        var PmsGroupId = unit.AspNetUserRepository.GetByID(LoggedInUser);
            //        string GroupName = unit.PmsGroupRepository.GetByID(PmsGroupId.PmsGroupID).GroupName;


            //        if (GroupID != 0)
            //        {
            //            var accessMapper = unit.AccessMapperRepository.GetByID(GroupID);
            //            string s = accessMapper.AccessList;
            //            string[] values = s.Split(',');
            //            foreach (var value in values)
            //            {
            //                AccesList.Add(Convert.ToInt32(value));
            //            }
            //            foreach (var item in AccesList)
            //            {
            //                try
            //                {
            //                    var access = unit.AccesslistRepository.GetByID(item);

            //                    CustomerAccessList custom = new CustomerAccessList();
            //                    custom.AccessID = access.AccessID;
            //                    custom.AccessStatus = access.AccessStatus;
            //                    custom.ActionName = access.ActionName;
            //                    custom.BaseModule = access.BaseModule;
            //                    custom.ControllerName = access.ControllerName;
            //                    custom.IconClass = access.IconClass;
            //                    custom.Mask = access.Mask;
            //                    custom.BaseModuleIndex = access.BaseModuleIndex;

            //                    if (access != null && access.IsRemoved == 0 && access.IsVisible == 0)
            //                    {
            //                        AllAccesslist.Add(custom);
            //                    }
            //                }
            //                catch (Exception ex)
            //                {


            //                }

            //            }
            //            var ModuleList = unit.ModuleRepository.GetAll().OrderBy(a => a.MenueOrder).ToList();
            //            foreach (var item in ModuleList)
            //            {
            //                Models.ViewModel.MenueViewModel menue = new Models.ViewModel.MenueViewModel();
            //                menue.ModuleID = item.ModuleID;
            //                menue.ModuleName = item.ModuleName;
            //                menue.ModuleIcon = item.ModuleIcon;
            //                var module = unit.ModuleRepository.GetByID(item.ModuleID);

            //                if (module.IsVisible == 0)
            //                {
            //                    var menulist = AllAccesslist.Where(a => a.BaseModule == item.ModuleID).OrderBy(a => a.BaseModuleIndex).ToList();
            //                    if (menulist.Count > 0)
            //                    {
            //                        menue.AccessList = menulist;
            //                        menueList.Add(menue);
            //                    }
            //                }


            //            }
            //        }
            //        menu.MenuList = menueList;
            //        menu.UserName = UserName;
            //        menu.GroupName = GroupName;

            //        var formatter = RequestFormat.JsonFormaterString();
            //        return Request.CreateResponse(HttpStatusCode.OK, new PayloadResponse { Success = true, Message = "200", Payload = menu }, formatter);

            //        //var formatter1 = RequestFormat.JsonFormaterString();
            //        //return Request.CreateResponse(HttpStatusCode.OK, new PayloadResponse { Success = false, Message = "400" }, formatter1);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    var formatter = RequestFormat.JsonFormaterString();
            //    return Request.CreateResponse(HttpStatusCode.OK, new PayloadResponse { Success = false, Message = "200", Payload = null }, formatter);


            //}


            //string LoggedInUser = User.Identity.GetUserId();
            //var UserName = UserManager.FindById(LoggedInUser).UserName;
            //List<MenuItemInformation> menueList = new List<MenuItemInformation>();

            //MenuItemInformation menue = new MenuItemInformation();
            //var menulist = db.AccessInformations.ToList();
            //if (menulist.Count > 0)
            //{
            //    menue.AccessList = menulist;
            //    menueList.Add(menue);
            //}

            //menu.MenuList = menueList;
            //menu.UserName = UserName;
            //menu.GroupName = GroupName;

            //return Json(menulist, JsonRequestBehavior.AllowGet);


            using (var db = new ApplicationDbContext())
            {

                var res = db.MenuInformations.ToList();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            /////////...............
        }


        //submenulist
        public async Task<JsonResult> SubMenu()
        {
            using (var db = new ApplicationDbContext())
            {
                //var userRoles = await UserManager.GetRolesAsync(user.Id);
                //MenuItemInformation Accesslist = new MenuItemInformation();
                //Accesslist = db.MenuInformations.Where(a => a.MenuItemId == submenu.MenuItemId).FirstOrDefault();
                //var Accesslist = from menu in db.MenuInformations join submenu in db.SubMenuInformations on menu.MenuItemId equals submenu.MenuItemId select new {submenu = submenu };

                try
                {
                    var userid = User.Identity.GetUserId();
                    // var userRoles = await UserManager.GetRolesAsync(userid);
                    string role = "";
                    var user = UserManager.FindById(userid);
                    foreach (IdentityUserRole roleId in user.Roles)
                    {
                        role = roleId.RoleId;
                    }
                    string[] list = { };
                    var AccessList = db.AccessInformations.Where(m => m.RoleId == role).FirstOrDefault();

                    if (AccessList != null)
                    {
                        list = AccessList.SubMenuList.Split(',');
                    }
                    List<SubMenuInformation> subMenuList = new List<SubMenuInformation>();
                    foreach (var item in list)
                    {

                        int id = Convert.ToInt32(item);
                        var subMenu = db.SubMenuInformations.Where(a => a.SubMenuId == id).FirstOrDefault();
                        if (subMenu.IsVisible == 1)

                            subMenuList.Add(subMenu);
                    }
                    HttpContext.Session["Page"] = subMenuList;
                    return Json(subMenuList, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }



            }
        }

        ////
        //// GET: /Account/Login
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginInformation objUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            var obj = db.UserInformations.Where(a => a.UserName.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["UserID"] = obj.UserId.ToString();
        //                Session["UserName"] = obj.UserName.ToString();
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //    }
        //    return View(objUser);
        //}

        //
        // POST: /Account/Login
        //[HttpPost]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }

        //     // This doesn't count login failures towards account lockout
        //     // To enable password failures to trigger account lockout, change to shouldLockout: true
        //     var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //     switch (result)
        //     {
        //         case SignInStatus.Success:
        //             return RedirectToLocal(returnUrl);
        //         case SignInStatus.LockedOut:
        //             return View("Lockout");
        //         case SignInStatus.RequiresVerification:
        //             return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //         case SignInStatus.Failure:
        //         default:
        //             ModelState.AddModelError("", "Invalid login attempt.");
        //             return View(model);
        //     }
        // }


        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.UserType="Admin";
                model.Status = "Active";
                //model.UserType = "User";
                //model.Status = "Inactive";
                var user = new ApplicationUser {UserName = model.UserName, Email = model.Email, FullName=model.FullName,  Status = model.Status };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        // GET: /Users/Edit/1
        // [CustomAuthorize]
        public async Task<ActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);

            // ViewBag.GroupID = new SelectList(db.GSAGroups, "GroupID", "GroupName");
            return View(new EditUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }




        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(EditUserViewModel editUser, params string[] selectedRole)
        {
            if (ModelState.IsValid)

            {

                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = editUser.UserName;
                user.Email = editUser.Email;
                //user.GroupID = editUser.GroupID;
                //UserManager.Update(user);


                var userRoles = await UserManager.GetRolesAsync(user.Id);


                selectedRole = selectedRole ?? new string[] { };

                var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }



        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user;
            if (model.Email.Contains("@"))
                user = UserManager.FindByEmail(model.Email);
            else
                user = UserManager.FindByName(model.Email);
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

      


        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}