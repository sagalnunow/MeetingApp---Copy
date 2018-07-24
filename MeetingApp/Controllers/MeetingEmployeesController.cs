using System;
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
    public class MeetingEmployeesController : Controller
    {
        private WPG_ConferenceEntities2 db = new WPG_ConferenceEntities2();

        // GET: MeetingEmployees
        public ActionResult Index()
        {
            var meetingEmployees = db.MeetingEmployees.Include(m => m.Employee).Include(m => m.Meeting).Include(m => m.RequirementOption);
            return View(meetingEmployees.ToList());
        }

        // GET: MeetingEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingEmployee meetingEmployee = db.MeetingEmployees.Find(id);
            if (meetingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(meetingEmployee);
        }

        // GET: MeetingEmployees/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name");
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic");
            ViewBag.RequirementOption_Id = new SelectList(db.RequirementOptions, "Id", "Id");
            return View();
        }

        // POST: MeetingEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee_Id,Meeting_Id,RequirementOption_Id")] MeetingEmployee meetingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.MeetingEmployees.Add(meetingEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meetingEmployee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meetingEmployee.Meeting_Id);
            ViewBag.RequirementOption_Id = new SelectList(db.RequirementOptions, "Id", "Id", meetingEmployee.RequirementOption_Id);
            return View(meetingEmployee);
        }

        // GET: MeetingEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingEmployee meetingEmployee = db.MeetingEmployees.Find(id);
            if (meetingEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meetingEmployee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meetingEmployee.Meeting_Id);
            ViewBag.RequirementOption_Id = new SelectList(db.RequirementOptions, "Id", "Id", meetingEmployee.RequirementOption_Id);
            return View(meetingEmployee);
        }

        // POST: MeetingEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee_Id,Meeting_Id,RequirementOption_Id")] MeetingEmployee meetingEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "F_Name", meetingEmployee.Employee_Id);
            ViewBag.Meeting_Id = new SelectList(db.Meetings, "Id", "Topic", meetingEmployee.Meeting_Id);
            ViewBag.RequirementOption_Id = new SelectList(db.RequirementOptions, "Id", "Id", meetingEmployee.RequirementOption_Id);
            return View(meetingEmployee);
        }

        // GET: MeetingEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingEmployee meetingEmployee = db.MeetingEmployees.Find(id);
            if (meetingEmployee == null)
            {
                return HttpNotFound();
            }
            return View(meetingEmployee);
        }

        // POST: MeetingEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingEmployee meetingEmployee = db.MeetingEmployees.Find(id);
            db.MeetingEmployees.Remove(meetingEmployee);
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
