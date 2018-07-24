using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetingApp.DAL;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {

        private WPG_ConferenceEntities2 _db;
        public MeetingController()
        {
            _db = new WPG_ConferenceEntities2();
        }
        // GET: Meeting
        public PartialViewResult EmployeeMeetings(int? empId )
        {
            var empMeeting = _db.MeetingEmployees.Where(x => x.Employee_Id == empId).Select(x => x.Meeting).ToList();
            return PartialView(empMeeting);
        }

        public PartialViewResult MeetingDetails(int? meetingId)
        {
            var meetingInfo = _db.Meetings.Find(meetingId);
            return PartialView(meetingInfo);
        }
    }
}