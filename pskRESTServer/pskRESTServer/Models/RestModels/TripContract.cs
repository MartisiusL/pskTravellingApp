using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Models.RestModels
{
    public class TripContract
    {
        public bool carRent { get; set; }
        public DateTime endDate { get; set; }
        public int endLocationId { get; set; }
        public bool hotelTickets { get; set; }
        public string miscInfo { get; set; }
        public string name { get; set; }
        public bool planeTicket { get; set; }
        public int organizerId { get; set; }
        public float price { get; set; }
        public DateTime startDate { get; set; }
        public int startLocationId { get; set; }
        public selectedItems[] selectedItems { get; set; }
    }
}