using MeetingApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MeetingApp.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports

        WPG_ConferenceEntities2 db = new WPG_ConferenceEntities2();
        public ActionResult Index()
        {
           
            return View(db.Companies);
        }

    }
}