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
    public class ExpenseTypeTablesController : Controller
    {
        private SchoolMgDbEntities db = new SchoolMgDbEntities();

        // GET: ExpenseTypeTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.ExpenseTypeTables.ToList());
        }

        // GET: ExpenseTypeTables/Details/5
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
            ExpenseTypeTable expenseTypeTable = db.ExpenseTypeTables.Find(id);
            if (expenseTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTypeTable);
        }

        // GET: ExpenseTypeTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: ExpenseTypeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseTypeTable expenseTypeTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.ExpenseTypeTables.Add(expenseTypeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseTypeTable);
        }

        // GET: ExpenseTypeTables/Edit/5
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
            ExpenseTypeTable expenseTypeTable = db.ExpenseTypeTables.Find(id);
            if (expenseTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTypeTable);
        }

        // POST: ExpenseTypeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseTypeTable expenseTypeTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(expenseTypeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseTypeTable);
        }

        // GET: ExpenseTypeTables/Delete/5
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
            ExpenseTypeTable expenseTypeTable = db.ExpenseTypeTables.Find(id);
            if (expenseTypeTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTypeTable);
        }

        // POST: ExpenseTypeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ExpenseTypeTable expenseTypeTable = db.ExpenseTypeTables.Find(id);
            db.ExpenseTypeTables.Remove(expenseTypeTable);
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
