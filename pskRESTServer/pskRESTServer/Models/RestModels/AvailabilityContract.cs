using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models.RestModels
{
    public class AvailabilityContract
    {
        public string Title { get; set; }
        public DateTime BusyFrom { get; set; }
        public DateTime BusyTo { get; set; }
        public int UserId { get; set; }
    }
}