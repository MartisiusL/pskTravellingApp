using pskRESTServer.Filters;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    [LogInvocationsFilters]
    public class TripByOrganizerIdController : ApiController
    { 
        
        // GET: api/TripByOrganizerId/5
        public List<Trip> Get(int id)
        {
            return RepositoryGetter.getDatabase().GetTripsListByOrganizerId(id);
        }

        [HttpGet]
        [Route("api/TripForOrganizer/{id}")]
        public Trip GetTripByIdForOrganizer(int id)
        {
            return RepositoryGetter.getDatabase().GetTripByIdForOrganizer(id);
        }

        // POST: api/TripByOrganizerId
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TripByOrganizerId/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TripByOrganizerId/5
        public void Delete(int id)
        {
        }
    }
}
