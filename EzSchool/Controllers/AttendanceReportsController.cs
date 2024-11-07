using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class AttendanceReportsController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();
        // GET: AttendanceReports
        public ActionResult StudentAttendance(int? id)
        {
            var studentPromotion = db.StudentPromotTables
                                     .Where(p => p.StudentID == id && p.IsActive == true)
                                     .FirstOrDefault();

            if (studentPromotion == null)
            {
                // Pass an empty list to the view if no active student promotion record is found
                return View(new List<AttendanceTable>());
            }

            var classid = studentPromotion.ClassID;
            var studentattendance = db.AttendanceTables
                                      .Where(a => a.StudentID == id && a.ClassID == classid)
                                      .OrderByDescending(a => a.AttendanceID)
                                      .ToList();
            return View(studentattendance);
        }

        //public ActionResult StudentAttendanceWise(int? id)
        //{
        //    if (id == null)
        //    {
        //        // Pass an empty list to the view if id is null
        //        return View(new List<AttendanceTable>());
        //    }

        //    var attendance = db.AttendanceTables.Where(a => a.StudentID == id).ToList();
        //    return View(attendance);
        //}
        public ActionResult StudentAttendanceWise()
        {
            var attendance = db.AttendanceTables.ToList();
            return View(attendance);
        }

        //public ActionResult StaffAttendanceWise(int? id)
        //{
        //    if (id == null)
        //    {
        //        // Pass an empty list to the view if id is null
        //        return View(new List<StaffAttendanceTable>());
        //    }

        //    var attendance = db.StaffAttendanceTables.Where(a => a.StaffID == id).ToList();
        //    return View(attendance);
        //}
        public ActionResult StaffAttendanceWise()
        {
            var attendance = db.StaffAttendanceTables.ToList();
            return View(attendance);
        }

        public ActionResult StaffAttendance(int? id)
        {
            if (id == null)
            {
                // Pass an empty list to the view if id is null
                return View(new List<StaffAttendanceTable>());
            }

            var staffattendance = db.StaffAttendanceTables.Where(a => a.StaffID == id).ToList();
            return View(staffattendance);
        }
    }
}