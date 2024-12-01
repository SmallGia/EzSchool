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
    public class ExpensesTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: ExpensesTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            int usertypeid = Convert.ToInt32(Convert.ToString(Session["UserTypeID"]));
            if (usertypeid == 1)
            {
                var expensesTables = db.ExpensesTables.Include(e => e.ExpenseTypeTable).Include(e => e.UserTable);
                return View(expensesTables.ToList());
            }
            else
            {
                var expensesTables = db.ExpensesTables.Include(e => e.ExpenseTypeTable).Include(e => e.UserTable).Where(s => s.UserID == userid);
                return View(expensesTables.ToList());
            }

        }

        // GET: ExpensesTables/Details/5
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
            ExpensesTable expensesTable = db.ExpensesTables.Find(id);
            if (expensesTable == null)
            {
                return HttpNotFound();
            }
            return View(expensesTable);
        }

        // GET: ExpensesTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ExpensesTypeID = new SelectList(db.ExpenseTypeTables, "ExpensesTypeID", "Name");
            var filteruserid = db.UserTables.Where(s => s.UserTypeID != 1);
            ViewBag.UserID = new SelectList(filteruserid, "UserID", "FullName");
            return View();
        }

        // POST: ExpensesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpensesTable expensesTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.ExpensesTables.Add(expensesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpensesTypeID = new SelectList(db.ExpenseTypeTables, "ExpensesTypeID", "Name", expensesTable.ExpensesTypeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", expensesTable.UserID);
            return View(expensesTable);
        }

        // GET: ExpensesTables/Edit/5
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
            ExpensesTable expensesTable = db.ExpensesTables.Find(id);
            if (expensesTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpensesTypeID = new SelectList(db.ExpenseTypeTables, "ExpensesTypeID", "Name", expensesTable.ExpensesTypeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", expensesTable.UserID);
            return View(expensesTable);
        }

        // POST: ExpensesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpensesTable expensesTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(expensesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpensesTypeID = new SelectList(db.ExpenseTypeTables, "ExpensesTypeID", "Name", expensesTable.ExpensesTypeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", expensesTable.UserID);
            return View(expensesTable);
        }

        // GET: ExpensesTables/Delete/5
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
            ExpensesTable expensesTable = db.ExpensesTables.Find(id);
            if (expensesTable == null)
            {
                return HttpNotFound();
            }
            return View(expensesTable);
        }

        // POST: ExpensesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ExpensesTable expensesTable = db.ExpensesTables.Find(id);
            db.ExpensesTables.Remove(expensesTable);
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
