using pskRESTServer.Repository;
using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using pskRESTServer.Models.RestModels;
using System.Data.Entity;
using pskRESTServer.Filters;

namespace pskRESTServer.Controllers
{
    [LogInvocationsFilters]
    public class TripController : ApiController
    {

        // GET: api/Trip
        public IEnumerable<Trip> Get()
        {
            return RepositoryGetter.getDatabase().GetTripsList();
        }

        // GET: api/Trip/5
        public Trip Get(int id)
        {
            return RepositoryGetter.getDatabase().GetTripById(id);
        }

        // POST: api/Trip
        public AnswerForTripRegistration Post([FromBody]TripContract tripContract)
        {
            AnswerForTripRegistration ans = new AnswerForTripRegistration();
            RepositoryGetter.getDatabase().AddTripByContract(tripContract);
            ans.success = true;
            ans.message = "Successfully registered trip!";
            return ans;
        }

        // PUT: api/Trip/5

        public void Put(int id, [FromBody] Trip trip)
        {
            RepositoryGetter.getDatabase().PutTrip(id, trip);
        }

        [Route("api/tripmerge")]
        public AnswerForPostRequests Post([FromBody] MergeTripsContract mergeTripsContract)
        {
            AnswerForPostRequests answer = new AnswerForPostRequests();
            
            try
            {
                RepositoryGetter.getDatabase().MergeTrips(mergeTripsContract.firstTripId, mergeTripsContract.secondTripId);
                answer.success = true;
                answer.message = "Trips successfully merged!";
            }
            catch
            {
                answer.success = false;
                answer.message = "Something went wrong!";
            }
            

            return answer;
        }

        public AnswerForTripRegistration Put([FromBody] UpdateTripNameContract tripContract)
        {
            AnswerForTripRegistration answer = new AnswerForTripRegistration();

            if(!RepositoryGetter.getDatabase().PutTripName(tripContract))
            {
                answer.success = false;
                answer.message = "Concurrency Exception Occurred.";
                return answer;
            }
            
            answer.success = true;
            answer.message = "Successfully updated!";
            return answer;
        }

        // DELETE: api/Trip/5
        public void Delete(int id)
        {
            RepositoryGetter.getDatabase().DeleteTripById(id);
        }
    }
}
