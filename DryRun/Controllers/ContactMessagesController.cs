using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DryRun.Infrastructure.Extensions;
using DryRun.Models;

namespace DryRun.Controllers
{
    public class ContactMessagesController : Controller
    {
        private readonly DryRunContext _db;

        public ContactMessagesController(DryRunContext db)
        {
            _db = db;
        }

        // GET: ContactMessages
        public ActionResult Index()
        {
            return View(_db.ContactMessages.ToList());
        }

        // GET: ContactMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = _db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // GET: ContactMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMail,UserName,CreationDate,Text,Answer,MessageType,BusinessArea")] ContactMessage contactMessage)
        {

            if (ModelState.IsValid)
            {
                _db.ContactMessages.Add(contactMessage);
                _db.SaveChanges();
                return RedirectToAction("Index").WithSuccess("Data saved");
            }

            return View(contactMessage).WithError("Check the errors");
        }

        // GET: ContactMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = _db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: ContactMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EMail,UserName,CreationDate,Text,Answer,MessageType,BusinessArea")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(contactMessage).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index").WithSuccess("Data saved");
            }
            return View(contactMessage).WithError("Check the errors");
        }

        // GET: ContactMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = _db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: ContactMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactMessage contactMessage = _db.ContactMessages.Find(id);
            _db.ContactMessages.Remove(contactMessage);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Pipoca()
        {
            return View(new ContactMessage());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
