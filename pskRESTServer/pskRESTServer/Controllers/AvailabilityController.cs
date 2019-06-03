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
    public class AvailabilityController : ApiController
    {
        // GET: api/Availability
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Availability/5
        public List<AnswerForAvailability> Get(int id)
        {
            List<AnswerForAvailability> answer = new List<AnswerForAvailability>();

            foreach(Availability availablility in RepositoryGetter.getDatabase().GetAvailabilitiesById(id))
            {
                AnswerForAvailability a = new AnswerForAvailability();
                a.title = availablility.Title;
                a.start = availablility.BusyFrom;
                a.end = availablility.BusyTo;
                a.availabilityId = availablility.Id;

                answer.Add(a);
            }

            return answer;
        }

        // POST: api/Availability
        public AnswerForPostRequests Post([FromBody]AvailabilityContract value)
        {
            AnswerForPostRequests answer = new AnswerForPostRequests();
            try
            {
                RepositoryGetter.getDatabase().AddAvailability(value);
               
                answer.success = true;
                answer.message = "Everything worked!";
        }
            catch
            {
                answer.success = false;
                answer.message = "Somehting went wrong!";
            }
            


            return answer;
        }

        // PUT: api/Availability/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("api/availabilityDelete/{id}")]
        public void RemoveAvailability(int id)
        {
            RepositoryGetter.getDatabase().DeleteAvailability(id);
        }
    }
}
