using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models.RestModels
{
    public class AnswerForRegistration
    {
        public bool success { get; set; }
        public int userId { get; set; }
    }
}