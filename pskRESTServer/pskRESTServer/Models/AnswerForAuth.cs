using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models
{
    public class AnswerForAuth
    {
        public bool success { get; set; }
        public bool admin { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
    }
}