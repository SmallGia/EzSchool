﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace EzSchool.Controllers
{
    public class StudentPromotTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();
        private StudentTable GetStudentByUserId(int userId)
        {
            var student = db.StudentTables.FirstOrDefault(s => s.UserID == userId);
            return student;
        }
        // GET: StudentPromotTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            var student = GetStudentByUserId(userid);

            if (usertypeid == 1)
            {
                var studentPromotTables = db.StudentPromotTables.Include(s => s.ClassTable).Include(s => s.ProgrameSessionTable).Include(s => s.SectionTable).Include(s => s.StudentTable).OrderByDescending(s => s.StudentPromotID);
                return View(studentPromotTables.ToList());
            }
            else
            {
                var studentPromotTables = db.StudentPromotTables.Include(s => s.ClassTable).Include(s => s.ProgrameSessionTable).Include(s => s.SectionTable).Include(s => s.StudentTable).Where(s => s.StudentID == student.StudentID).OrderByDescending(s => s.StudentPromotID);
                return View(studentPromotTables.ToList());
            }
        }

        // GET: StudentPromotTables/Details/5
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
            StudentPromotTable studentPromotTable = db.StudentPromotTables.Find(id);
            if (studentPromotTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromotTable);
        }

        // GET: StudentPromotTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            //Debug.WriteLine("abc");
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgrameSessionID = new SelectList(db.ProgrameSessionTables, "ProgrameSessionID", "Details");
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            return View();
        }

        // POST: StudentPromotTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentPromotTable studentPromotTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
          
            if (ModelState.IsValid)
            {
                db.StudentPromotTables.Add(studentPromotTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotTable.ClassID);
            ViewBag.ProgrameSessionID = new SelectList(db.ProgrameSessionTables, "ProgrameSessionID", "Details", studentPromotTable.ProgrameSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotTable.StudentID);
            return View(studentPromotTable);
        }

        // GET: StudentPromotTables/Edit/5
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
            StudentPromotTable studentPromotTable = db.StudentPromotTables.Find(id);
            if (studentPromotTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotTable.ClassID);
            ViewBag.ProgrameSessionID = new SelectList(db.ProgrameSessionTables, "ProgrameSessionID", "Details", studentPromotTable.ProgrameSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotTable.StudentID);
            return View(studentPromotTable);
        }

        // POST: StudentPromotTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( StudentPromotTable studentPromotTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(studentPromotTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", studentPromotTable.ClassID);
            ViewBag.ProgrameSessionID = new SelectList(db.ProgrameSessionTables, "ProgrameSessionID", "Details", studentPromotTable.ProgrameSessionID);
            ViewBag.SectionID = new SelectList(db.SectionTables, "SectionID", "SectionName", studentPromotTable.SectionID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotTable.StudentID);
            return View(studentPromotTable);
        }

        // GET: StudentPromotTables/Delete/5
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
            StudentPromotTable studentPromotTable = db.StudentPromotTables.Find(id);
            if (studentPromotTable == null)
            {
                return HttpNotFound();
            }
            return View(studentPromotTable);
        }

        // POST: StudentPromotTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            StudentPromotTable studentPromotTable = db.StudentPromotTables.Find(id);
            db.StudentPromotTables.Remove(studentPromotTable);
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
        public ActionResult GetPromotClsList(string sid)
        {
            Debug.WriteLine("Student ID: " + sid);
            int studentid = Convert.ToInt32(sid);
            var student = db.StudentTables.Find(studentid);
            int promoteid = 0;
            try
            {
                promoteid = db.StudentPromotTables.Where(p => p.StudentID == studentid).Max(m => m.StudentPromotID);
            }
            catch
            {
                promoteid = 0;
            }


            List<ClassTable> classTables = new List<ClassTable>();
            if (promoteid > 0)
            {
                var promotetable = db.StudentPromotTables.Find(promoteid);
                foreach (var cls in db.ClassTables.Where(cls => cls.ClassID == promotetable.ClassID))
                {
                    classTables.Add(new ClassTable { ClassID = cls.ClassID, Name = cls.Name });
                }
            }
            else
            {
                foreach (var cls in db.ClassTables.Where(cls => cls.ClassID == student.ClassID))
                {
                    classTables.Add(new ClassTable { ClassID = cls.ClassID, Name = cls.Name });
                }
            }

            return Json(new { data = classTables }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnnualFee(string sid)
        {
            int progressid = Convert.ToInt32(sid);
            var ps = db.ProgrameSessionTables.Find(progressid);
            var annualfee = db.AnnualTables.Where(a => a.ProgrameID == ps.ProgrameID).SingleOrDefault();
            double? fee = annualfee.Fees;
            return Json(new { fees = fee }, JsonRequestBehavior.AllowGet);
        }
    }
}
