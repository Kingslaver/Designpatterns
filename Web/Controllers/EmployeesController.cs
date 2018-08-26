using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Factory.FactoryMethods;
using Web.Factory;

namespace Web.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeePortalEntities db = new EmployeePortalEntities();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Designation).Include(e => e.EmployeeType);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.DesignationID = new SelectList(db.Designations, "Id", "DesignationName");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Number,DepartmentID,DesignationID,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                BaseEmployeeFactory bEmpFact = new EmployeeManagerFactory().GetFactory(employee);
                bEmpFact.CalculateSalary();
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Number,DepartmentID,DesignationID,HourlyRate,Bonus,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentID);
            ViewBag.DesignationID = new SelectList(db.Designations, "Id", "DesignationName", employee.DesignationID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "Id", "EmployeeTypeName", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
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
