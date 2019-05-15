using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public bool admin { get; set; }
        public Office office { get; set; }
        public Account account { get; set; }
    }
}