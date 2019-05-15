using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}