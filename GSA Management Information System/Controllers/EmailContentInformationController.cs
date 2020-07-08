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
    public class EmailContentInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmailContentInformation
        public ActionResult Index()
        {
            return View(db.EmailContentInformations.ToList());
        }

        // GET: EmailContentInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailContentInformation emailContentInformation = db.EmailContentInformations.Find(id);
            if (emailContentInformation == null)
            {
                return HttpNotFound();
            }
            return View(emailContentInformation);
        }

        // GET: EmailContentInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailContentInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EmailContentInformation emailContentInformation)
        {
            var from = emailContentInformation.From;

            var to = emailContentInformation.To;
            var cc = emailContentInformation.Cc;
            var bcc = emailContentInformation.Bcc;
            var subject = emailContentInformation.Subject;
            var body = emailContentInformation.Body;
            var useremail = emailContentInformation.UserEmail;
            var password = emailContentInformation.UserPassword;
            var hostserver = emailContentInformation.HostServer;
            var smtpport = emailContentInformation.SmtpPort;


            if (ModelState.IsValid)
            {
                db.EmailContentInformations.Add(emailContentInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailContentInformation);
        }

        // GET: EmailContentInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailContentInformation emailContentInformation = db.EmailContentInformations.Find(id);
            if (emailContentInformation == null)
            {
                return HttpNotFound();
            }
            return View(emailContentInformation);
        }

        // POST: EmailContentInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailId,From,To,CC,BCC,Subject,Body,HostServer,UserEmail,UserPassword,SmtpPort,Entry_Date,Entry_By")] EmailContentInformation emailContentInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailContentInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailContentInformation);
        }

        // GET: EmailContentInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailContentInformation emailContentInformation = db.EmailContentInformations.Find(id);
            if (emailContentInformation == null)
            {
                return HttpNotFound();
            }
            return View(emailContentInformation);
        }

        // POST: EmailContentInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailContentInformation emailContentInformation = db.EmailContentInformations.Find(id);
            db.EmailContentInformations.Remove(emailContentInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
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
