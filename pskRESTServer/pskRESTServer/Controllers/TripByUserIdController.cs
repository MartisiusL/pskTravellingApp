using pskRESTServer.Models;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    public class TripByUserIdController : ApiController
    {
        AzureDatabase azureDatabase = new AzureDatabase();

        // GET: api/TripByUserId
        public IEnumerable<Trip> Get()
        {
            return azureDatabase.GetTripsList();
        }

        // GET: api/TripByUserId/5
        public List<TripWithConfirmation> Get(int id)
        {
            return azureDatabase.GetTripsListByUserId(id);
        }

        // POST: api/TripByUserId
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TripByUserId/5
        public void Put([FromBody]int tripId, [FromBody]int userId, [FromBody]bool value)
        {
            azureDatabase.PutUserTrip(tripId, userId, value);
        }

        // DELETE: api/TripByUserId/5
        public void Delete(int id)
        {
        }
    }
}
