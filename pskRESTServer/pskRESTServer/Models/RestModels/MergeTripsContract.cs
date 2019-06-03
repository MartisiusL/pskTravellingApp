using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models.RestModels
{
    public class MergeTripsContract
    {
        public int firstTripId { get; set; }
        public int secondTripId { get; set; }
    }
}