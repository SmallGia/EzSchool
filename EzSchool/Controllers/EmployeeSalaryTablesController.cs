﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace EzSchool.Controllers
{
    public class EmployeeSalaryTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: EmployeeSalaryTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var employeeSalaryTables = db.EmployeeSalaryTables.Include(e => e.UserTable).Include(e => e.StaffTable);
            return View(employeeSalaryTables.ToList());
        }

        // GET: EmployeeSalaryTables/Details/5
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
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s=>s.IsActive == true), "StaffID", "Name");
            return View();
        }

        // POST: EmployeeSalaryTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeSalaryTable employeeSalaryTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            employeeSalaryTable.UserID = userid;
            employeeSalaryTable.SalaryDate = DateTime.Now;
            employeeSalaryTable.SalaryMonth = DateTime.Now.ToString("MMMM");
            employeeSalaryTable.SalaryYear = DateTime.Now.ToString("yyyy");
            if (ModelState.IsValid)
            {
                db.EmployeeSalaryTables.Add(employeeSalaryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s => s.IsActive == true), "StaffID", "Name", employeeSalaryTable.StaffID);
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Edit/5
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
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s => s.IsActive == true), "StaffID", "Name", employeeSalaryTable.StaffID);
            return View(employeeSalaryTable);
        }

        // POST: EmployeeSalaryTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeSalaryTable employeeSalaryTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            employeeSalaryTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(employeeSalaryTable).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", employeeSalaryTable.UserID);
            ViewBag.StaffID = new SelectList(db.StaffTables.Where(s => s.IsActive == true), "StaffID", "Name", employeeSalaryTable.StaffID);
            return View(employeeSalaryTable);
        }

        // GET: EmployeeSalaryTables/Delete/5
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
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            if (employeeSalaryTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalaryTable);
        }

        // POST: EmployeeSalaryTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            EmployeeSalaryTable employeeSalaryTable = db.EmployeeSalaryTables.Find(id);
            db.EmployeeSalaryTables.Remove(employeeSalaryTable);
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
        public ActionResult GetSalary(string sid)
        {
            int staffid = Convert.ToInt32(sid);
            var ps = db.StaffTables.Find(staffid);
            double? salary = ps.BasicSalary;
            return Json(new { Salary = salary }, JsonRequestBehavior.AllowGet);
        }
    }
}
