﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace EzSchool.Controllers
{
    public class StaffAttendanceTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: StaffAttendanceTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var staffAttendanceTables = db.StaffAttendanceTables.Include(s => s.StaffTable);
            return View(staffAttendanceTables.ToList());
        }

        // GET: StaffAttendanceTables/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name");
            return View();
        }

        // POST: StaffAttendanceTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffAttendanceTable staffAttendanceTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.StaffAttendanceTables.Add(staffAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s=>s.IsActive == true), "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // POST: StaffAttendanceTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffAttendanceTable staffAttendanceTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(staffAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", staffAttendanceTable.StaffID);
            return View(staffAttendanceTable);
        }

        // GET: StaffAttendanceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            if (staffAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(staffAttendanceTable);
        }

        // POST: StaffAttendanceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            StaffAttendanceTable staffAttendanceTable = db.StaffAttendanceTables.Find(id);
            db.StaffAttendanceTables.Remove(staffAttendanceTable);
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
