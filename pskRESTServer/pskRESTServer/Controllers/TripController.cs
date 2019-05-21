using pskRESTServer.Repository;
using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    public class TripController : ApiController
    {
        private Database database = new MockDatabase();

        // GET: api/Trip
        public IEnumerable<Trip> Get()
        {
            return database.GetTripsList();
        }

        // GET: api/Trip/5
        public Trip Get(int id)
        {
            return database.GetTripById(id);
        }

        // POST: api/Trip
        //[HttpPost]
        public bool Post([FromBody]Trip value)
        {
            database.AddTrip(value);
            return true;
        }

        // DELETE: api/Trip/5
        public void Delete(int id)
        {
            database.DeleteTripById(id);
        }
    }
}
