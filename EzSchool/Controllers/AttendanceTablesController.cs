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
    public class AttendanceTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: AttendanceTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            var student = db.StudentTables.FirstOrDefault(s => s.UserID == userid);
            if (usertypeid == 1)
            {
                var attendanceTables = db.AttendanceTables.Include(a => a.StudentTable).Include(a => a.ClassTable).OrderByDescending(a => a.AttendanceID);
                return View(attendanceTables.ToList());
            }
            else
            {
                var attendanceTables = db.AttendanceTables.Include(a => a.StudentTable).Include(a => a.ClassTable).Where(s => s.StudentID == student.StudentID).OrderByDescending(a => a.AttendanceID);
                return View(attendanceTables.ToList());
            }


        }

        // GET: AttendanceTables/Details/5
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
            AttendanceTable attendanceTable = db.AttendanceTables.Find(id);
            if (attendanceTable == null)
            {
                return HttpNotFound();
            }
            var name = db.SessionTables.Where(s => s.SessionID == attendanceTable.SessionID).Select(s => s.Name).FirstOrDefault();
            ViewBag.SessionName = name;

            return View(attendanceTable);
        }

        // GET: AttendanceTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            return View();
        }

        // POST: AttendanceTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceTable attendanceTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.AttendanceTables.Add(attendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", attendanceTable.StudentID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", attendanceTable.ClassID);
            return View(attendanceTable);
        }

        // GET: AttendanceTables/Edit/5
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
            AttendanceTable attendanceTable = db.AttendanceTables.Find(id);
            if (attendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", attendanceTable.StudentID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", attendanceTable.ClassID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            return View(attendanceTable);
        }

        // POST: AttendanceTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendanceTable attendanceTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(attendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", attendanceTable.StudentID);
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", attendanceTable.ClassID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            return View(attendanceTable);
        }

        // GET: AttendanceTables/Delete/5
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
            AttendanceTable attendanceTable = db.AttendanceTables.Find(id);
            if (attendanceTable == null)
            {
                return HttpNotFound();
            }
            var name = db.SessionTables.Where(s => s.SessionID == attendanceTable.SessionID).Select(s => s.Name).FirstOrDefault();
            ViewBag.SessionName = name;
            return View(attendanceTable);
        }

        // POST: AttendanceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            AttendanceTable attendanceTable = db.AttendanceTables.Find(id);
            db.AttendanceTables.Remove(attendanceTable);
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
        public ActionResult GetClassesByStudent(string sid)
        {
            int studentid = Convert.ToInt32(sid);

            // Lấy danh sách ClassID từ StudentTables
            var classIds = db.StudentTables
                             .Where(c => c.StudentID == studentid)
                             .Select(c => c.ClassID)
                             .ToList();

            // Sử dụng ClassID để tìm kiếm trong ClassTables
            var classes = db.ClassTables
                            .Where(c => classIds.Contains(c.ClassID))
                            .Select(c => new
                            {
                                ClassID = c.ClassID,
                                Name = c.Name
                            }).ToList();

            return Json(new { data = classes }, JsonRequestBehavior.AllowGet);
        }


    }
}
