using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models
{
    public class AuthorizationBody
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}