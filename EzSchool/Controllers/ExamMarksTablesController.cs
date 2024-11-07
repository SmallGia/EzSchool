using System;
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
    public class ExamMarksTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: ExamMarksTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var examMarksTables = db.ExamMarksTables.Include(e => e.ClassSubjectTable).Include(e => e.ExamTable).Include(e => e.StudentTable).Include(e => e.UserTable).OrderByDescending(e => e.MarksID);
            return View(examMarksTables.ToList());
        }

        // GET: ExamMarksTables/Details/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name");
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ExamMarksTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamMarksTable examMarksTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userId = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            examMarksTable.UserID = userId;
            if (ModelState.IsValid)
            {
                db.ExamMarksTables.Add(examMarksTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", examMarksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", examMarksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", examMarksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examMarksTable.UserID);
            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Edit/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", examMarksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", examMarksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", examMarksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examMarksTable.UserID);
            return View(examMarksTable);
        }

        // POST: ExamMarksTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamMarksTable examMarksTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            examMarksTable.UserID = userId;
            if (ModelState.IsValid)
            {
                db.Entry(examMarksTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassSubjectID = new SelectList(db.ClassSubjectTables, "ClassSubjectID", "Name", examMarksTable.ClassSubjectID);
            ViewBag.ExamID = new SelectList(db.ExamTables, "ExamID", "Title", examMarksTable.ExamID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", examMarksTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", examMarksTable.UserID);
            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Delete/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            return View(examMarksTable);
        }

        // POST: ExamMarksTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            db.ExamMarksTables.Remove(examMarksTable);
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
        public ActionResult GetByPromoteID(string sid)
        {
            int promoteid = Convert.ToInt32(sid);
            var promoterecord = db.StudentPromotTables.Find(promoteid);
            List<StudentTable> stdlist = new List<StudentTable>();

            stdlist.Add(new StudentTable { StudentID = (int)promoterecord.StudentID, Name = promoterecord.StudentTable.Name });


            List<ClassSubjectTable> listsubjects = new List<ClassSubjectTable>();
            var classsubject = db.ClassSubjectTables.Where(cls => cls.ClassID == promoterecord.ClassID && cls.IsActive == true);
            foreach (var subj in classsubject)
            {
                listsubjects.Add(new ClassSubjectTable { ClassSubjectID = subj.ClassSubjectID , Name = subj.Name});
            }

            return Json(new { student = stdlist, subject = listsubjects }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTotalMarks(string sid)
        {
            int classsubjectid = Convert.ToInt32(sid);
            var totalmark = db.ClassSubjectTables.Find(classsubjectid).SubjectTable.TotalMarks;
            return Json(new { data = totalmark }, JsonRequestBehavior.AllowGet);
        }
    }
}
