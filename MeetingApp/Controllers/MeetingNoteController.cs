using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingNoteController : Controller
    {
        // GET: MeetingNote
        public ActionResult Index()
        {
            return View();
        }
    }
}