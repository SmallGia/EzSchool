﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;
using WebGrease.Css.Ast;

namespace EzSchool.Controllers
{
    public class TimeTblTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: TimeTblTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            var filteredUsers = db.UserTables.Where(u => u.UserTypeID != 1).ToList();
            ViewBag.UserID = new SelectList(filteredUsers, "UserID", "FullName");
            if (usertypeid != 1)
            {
                var timeTblTables = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable).Where(s => s.UserID == userid).OrderByDescending(e => e.TimeTableID);
                return View(timeTblTables.ToList());
            }
            else
            {
                var timeTblTables = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable).OrderByDescending(e => e.TimeTableID);
                return RedirectToAction("Index2");
            }

        }
        public ActionResult Index3(int? uid)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var schedule = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable).Where(s => s.UserID == uid).OrderByDescending(e => e.TimeTableID);
            return View(schedule.ToList());
        }

        public ActionResult Index2()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            var filteredUsers = db.UserTables.Where(u => u.UserTypeID != 1).ToList();
            ViewBag.UserID = new SelectList(filteredUsers, "UserID", "FullName");
            if (usertypeid != 1)
            {
                var timeTblTables = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable).Where(s => s.UserID == userid).OrderByDescending(e => e.TimeTableID);
                return View(timeTblTables.ToList());
            }
            else
            {
                var timeTblTables = db.TimeTblTables.Include(t => t.ClassSubjectTable).Include(t => t.StaffTable).Include(t => t.UserTable).OrderByDescending(e => e.TimeTableID);
                return View(timeTblTables.ToList());
            }
        }


        // GET: TimeTblTables/Details/5
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
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var filteredUsers = db.UserTables.Where(u => u.UserTypeID != 1).ToList();
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables.Where(s => s.IsActive == true), "ClassSubjectID", "Name");
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s=>s.IsActive == true), "StaffID", "Name");
            ViewBag.UserID = new SelectList(filteredUsers, "UserID", "FullName");
            return View();
        }

        // POST: TimeTblTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeTblTable timeTblTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            //timeTblTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.TimeTblTables.Add(timeTblTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables.Where(s => s.IsActive == true), "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s => s.IsActive == true), "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Edit/5
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
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables.Where(s => s.IsActive == true), "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s => s.IsActive == true), "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // POST: TimeTblTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeTblTable timeTblTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
         //   timeTblTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(timeTblTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", timeTblTable.ClassSubjectID);
            ViewBag.StaffID = new SelectList(db.StaffTables, "StaffID", "Name", timeTblTable.StaffID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", timeTblTable.UserID);
            return View(timeTblTable);
        }

        // GET: TimeTblTables/Delete/5
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
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            if (timeTblTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTblTable);
        }

        // POST: TimeTblTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            TimeTblTable timeTblTable = db.TimeTblTables.Find(id);
            db.TimeTblTables.Remove(timeTblTable);
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
