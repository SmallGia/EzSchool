using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace EzSchool.Views.Shared
{
    public class StudentPromotTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: StudentPromotTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var studentPromotTables = db.StudentPromotTables.Include(s => s.ClassTable).Include(s => s.ProgrameSessionTable).Include(s => s.StudentTable);
            return View(studentPromotTables.ToList());
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
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgrameSessionID = new SelectList(db.ProgrameSessionTables, "ProgrameSessionID", "Details");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            return View();
        }

        // POST: StudentPromotTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentPromotTable studentPromotTable)
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
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", studentPromotTable.StudentID);
            return View(studentPromotTable);
        }

        // POST: StudentPromotTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentPromotTable studentPromotTable)
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
    }
}
