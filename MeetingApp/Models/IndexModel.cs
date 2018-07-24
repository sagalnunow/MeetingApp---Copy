using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetingApp.DAL;

namespace MeetingApp.Models
{
    public class IndexModel
    {
        public Employee Employee { get; set; }
        public List<Meeting> Meetings { get; set; }
        public List<Guest> Guests { get; set; }
        public List<Note> Notes { get; set; }
        public List<Company> Companies { get; set; }
        public MeetingEmployee MeetingEmployee { get; set; }
    }
}