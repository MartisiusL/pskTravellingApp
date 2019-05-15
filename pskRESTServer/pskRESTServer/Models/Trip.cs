using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public String name { get; set; }
        public Office fromOffice { get; set; }
        public Office toOffice { get; set; }
        public DateTime date { get; set; }
        public List<User> peopleOfTheTrip = new List<User>();
        public List<bool> peopleAnswersForTheTrip = new List<bool>();
    }
}