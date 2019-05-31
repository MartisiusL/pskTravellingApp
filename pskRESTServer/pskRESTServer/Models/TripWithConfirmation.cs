using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pskRESTServer;

namespace pskRESTServer.Models
{
    public class TripWithConfirmation: pskRESTServer.Trip
    {

        public Boolean confirmed { get; set; }
        public int UserTripId { get; set; }


        public TripWithConfirmation(pskRESTServer.Trip t) {
            Id = t.Id;
            TripName = t.TripName;
            TripStartDate = t.TripStartDate;
            TripEndDate = t.TripEndDate;
            ToOfficeId = t.ToOfficeId;
            FromOfficeId = t.FromOfficeId;
            UserTrips = new List<UserTrip>();
    }
    }
}