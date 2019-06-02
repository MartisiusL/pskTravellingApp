using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pskRESTServer;

namespace pskRESTServer.Models
{
    public class TripWithUserTrips : pskRESTServer.Trip
    {

        public virtual ICollection<UserTrip> UserTrips { get; set; }

        public TripWithUserTrips(pskRESTServer.Trip t)
        {
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