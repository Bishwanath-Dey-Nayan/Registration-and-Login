﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Company1111.Models;
using NayanTraders.Models;

namespace Company1111.Controllers
{
    [Authorize]
    public class UserTypeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: UserType
        [Authorize]
        public ActionResult Index()
        {
            return View(db.userTypes.ToList());
        }

        // GET: UserType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.userTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // GET: UserType/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.userTypes.Add(userType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userType);
        }

        // GET: UserType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.userTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userType);
        }

        // GET: UserType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.userTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType userType = db.userTypes.Find(id);
            db.userTypes.Remove(userType);
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
