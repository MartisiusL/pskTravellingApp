﻿using pskRESTServer.Filters;
using pskRESTServer.Models;
using pskRESTServer.Models.RestModels;
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
    public class TripByUserIdController : ApiController
    {

        // GET: api/TripByUserId
        public IEnumerable<Trip> Get()
        {
            return RepositoryGetter.getDatabase().GetTripsList();
        }

        // GET: api/TripByUserId/5
        public List<TripWithConfirmation> Get(int id)
        {
            try
            {
                return RepositoryGetter.getDatabase().GetTripsListByUserId(id);
            }
            catch
            {
                return null;
            }
            
        }

        // POST: api/TripByUserId
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TripByUserId/5
        public void Put(int id, [FromBody]TripConfirmationBody confirmed)
        {
            RepositoryGetter.getDatabase().PutUserTrip(id, confirmed.confirmed);
            if(confirmed.confirmed)
            {
                RepositoryGetter.getDatabase().AddAvailabilityTrip(id);
            }
            else
            {
                RepositoryGetter.getDatabase().DeleteAvailabilityTrip(id);
            }
        }

        // DELETE: api/TripByUserId/5
        public void Delete(int id)
        {
        }
    }
}
