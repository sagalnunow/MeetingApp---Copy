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
    public class EmployeeGuestsController : Controller
    {
        private WPG_ConferenceEntities2 db = new WPG_ConferenceEntities2();

        // GET: EmployeeGuests
        public ActionResult Index()
        {
            var employeeGuests = db.EmployeeGuests.Include(e => e.Employee).Include(e => e.Guest);
            return View(employeeGuests.ToList());
        }

        public ActionResult Search(string search)
        {
            var employeeGuests = db.EmployeeGuests.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                employeeGuests = db.EmployeeGuests.Where(x => x.Employee.F_Name.Contains(search)).ToList();
            }

            return View("Index", employeeGuests);
        }

        // GET: EmployeeGuests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employeeGuest = db.EmployeeGuests.Find(id);
            if (employeeGuest == null)
            {
                return HttpNotFound();
            }
            return View(employeeGuest);
        }

        // GET: EmployeeGuests/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name");
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name");
            return View();
        }

        // POST: EmployeeGuests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Guest_Id")] EmployeeGuest employeeGuest)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeGuests.Add(employeeGuest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employeeGuest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employeeGuest.Guest_Id);
            return View(employeeGuest);
        }

        // GET: EmployeeGuests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employeeGuest = db.EmployeeGuests.Find(id);
            if (employeeGuest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employeeGuest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employeeGuest.Guest_Id);
            return View(employeeGuest);
        }

        // POST: EmployeeGuests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Guest_Id")] EmployeeGuest employeeGuest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeGuest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", employeeGuest.Employee_Id);
            ViewBag.Guest_Id = new SelectList(db.Guests, "Id", "F_Name", employeeGuest.Guest_Id);
            return View(employeeGuest);
        }

        // GET: EmployeeGuests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGuest employeeGuest = db.EmployeeGuests.Find(id);
            if (employeeGuest == null)
            {
                return HttpNotFound();
            }
            return View(employeeGuest);
        }

        // POST: EmployeeGuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeGuest employeeGuest = db.EmployeeGuests.Find(id);
            db.EmployeeGuests.Remove(employeeGuest);
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
