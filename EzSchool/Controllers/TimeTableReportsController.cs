using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzSchool.Controllers
{
    public class TimeTableReportsController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();
        // GET: TimeTableReports
        public ActionResult TeacherReport(int? id)
        {
            if (id == null)
            {
                // Pass an empty list to the view if id is null
                return View(new List<TimeTblTable>());
            }

            var teacherclas = db.TimeTblTables
                                .Where(t => t.StaffID == id && t.IsActive == true)
                                .OrderByDescending(e => e.TimeTableID)
                                .ToList();
            return View(teacherclas);
        }

        public ActionResult TeacherWiseReport(int? id)
        {
            var teacherclas = db.TimeTblTables
                                .Where(t => t.IsActive == true)
                                .OrderBy(e => e.StaffID)
                                .ToList();
            return View(teacherclas);
        }
        public ActionResult StudentReport(int? id)
        {
            var studentPromotion = db.StudentPromotTables
                         .Where(p => p.StudentID == id && p.IsActive == true)
                         .FirstOrDefault();

            if (studentPromotion == null)
            {
                // Pass an empty list to the view if no active student promotion record is found
                return View(new List<TimeTblTable>());
            }
            var classid = db.StudentPromotTables.Where(p => p.StudentID == id && p.IsActive == true).FirstOrDefault().ClassID;
            //var classsubjectids = db.ClassSubjectTables.Where(cls => cls.ClassID == classid && cls.IsActive == true);
            //List<TimeTblTable> timetable = new List<TimeTblTable>();
            //foreach(var clssubjectid in classsubjectids)
            //{
            //    var subjectime = db.TimeTblTables.Where(t => t.ClassSubjectTable.ClassID == ClassS clssubjectid.ClassSubjectID && t.IsActive == true).FirstOrDefault();
            //    timetable.Add(new TimeTblTable
            //    {
            //        ClassSubjectID = subjectime.ClassSubjectID,
            //        Day = subjectime.Day,
            //        ClassSubjectTable = subjectime.ClassSubjectTable,
            //        EndTime = subjectime.EndTime,
            //        IsActive = subjectime.IsActive,
            //        StaffID = subjectime.StaffID,
            //        StaffTable = subjectime.StaffTable,
            //        StartTime = subjectime.StartTime,
            //        TimeTableID = subjectime.TimeTableID,
            //        UserID = subjectime.UserID,
            //        UserTable = subjectime.UserTable
            //    });
            //}

            //var teacherclas = db.TimeTblTables.Where(t => t.IsActive == true).OrderBy(e => e.StaffID);
            var subjectime = db.TimeTblTables.Where(t => t.ClassSubjectTable.ClassID == classid && t.IsActive == true);
            return View(subjectime);
        }
    }
}