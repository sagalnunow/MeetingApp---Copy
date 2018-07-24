﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetingApp.DAL;

namespace MeetingApp.Controllers
{
    public class EmployeeGuestController : Controller
    {
        private WPG_ConferenceEntities2 db = new WPG_ConferenceEntities2();

        // GET: EmployeeGuest
        public ActionResult Index()
        {
            var employee_Guest = db.EmployeeGuests.Include(e => e.Employee).Include(e => e.Guest);
            return View(employee_Guest.ToList());
        }

        public ActionResult Search(string search)
        {
            var employee_Guest = db.EmployeeGuests.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                employee_Guest = db.EmployeeGuests.Where(x => x.Employee.F_Name.Contains(search)).ToList();
            }

            return View("Index", employee_Guest);
        }

        // GET: EmployeeGuest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employee_Guest = db.EmployeeGuests.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name");
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name");
            return View();
        }

        // POST: EmployeeGuest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Guest_Id")] EmployeeGuest employee_Guest)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeGuests.Add(employee_Guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employee_Guest = db.EmployeeGuests.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // POST: EmployeeGuest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Guest_Id")] EmployeeGuest employee_Guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employee_Guest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employee_Guest.Guest_Id);
            return View(employee_Guest);
        }

        // GET: EmployeeGuest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employee_Guest = db.EmployeeGuests.Find(id);
            if (employee_Guest == null)
            {
                return HttpNotFound();
            }
            return View(employee_Guest);
        }

        // POST: EmployeeGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeGuest employee_Guest = db.EmployeeGuests.Find(id);
            db.EmployeeGuests.Remove(employee_Guest);
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
