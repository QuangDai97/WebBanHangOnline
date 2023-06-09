﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class HangsanxuatsController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Hangsanxuats
        public ActionResult Index()
        {
            return View(db.Hangsanxuats.ToList());
        }

        // GET: Hangsanxuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hangsanxuat = db.Hangsanxuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hangsanxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahang,Tenhang")] Hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Hangsanxuats.Add(hangsanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hangsanxuat = db.Hangsanxuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Hangsanxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahang,Tenhang")] Hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangsanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangsanxuat);
        }

        // GET: Hangsanxuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hangsanxuat = db.Hangsanxuats.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Hangsanxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hangsanxuat hangsanxuat = db.Hangsanxuats.Find(id);
            db.Hangsanxuats.Remove(hangsanxuat);
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
