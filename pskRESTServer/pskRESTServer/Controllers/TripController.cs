using pskRESTServer.Repository;
using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace pskRESTServer.Controllers
{
    public class TripController : ApiController
    {
        private Database database = new AzureDatabase();

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
        public void Post([FromBody]Trip value)
        {
            database.AddTrip(value);
        }

        // DELETE: api/Trip/5
        public void Delete(int id)
        {
            database.DeleteTripById(id);
        }
    }
}
