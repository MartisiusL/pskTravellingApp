using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models.RestModels
{
    public class UpdateTripNameContract
    {
        public string TripName { get; set; }
        public int CurrentTripId { get; set; }
        public byte[] RowVersion { get; set; }
        public bool Force { get; set; }
    }
}