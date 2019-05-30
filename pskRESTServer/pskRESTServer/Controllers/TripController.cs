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

namespace pskRESTServer.Controllers
{
    public class TripController : ApiController
    {
        private AzureDatabase database = new AzureDatabase();

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
        public AnswerForTripRegistration Post([FromBody]TripContract tripContract)
        {
            AnswerForTripRegistration ans = new AnswerForTripRegistration();
            using (pskTravellingEntities db = new pskTravellingEntities())
            {
                Trip trip = new Trip();
                trip.TripName = tripContract.name;
                trip.ToOfficeId = tripContract.endLocationId;
                trip.FromOfficeId = tripContract.startLocationId;
                trip.HasHotel = tripContract.hotelTickets;
                trip.RentCar = tripContract.carRent;
                trip.TravelTickets = tripContract.planeTicket;
                trip.TripStartDate = tripContract.startDate;
                trip.TripEndDate = tripContract.endDate;
                try
                {
                    trip.Id = db.Trips.Max(record => record.Id) + 1;
                }
                catch
                {
                    trip.Id = 0;
                }
                
                database.AddTrip(trip);

                foreach (selectedItems employee in tripContract.selectedItems)
                {
                    UserTrip userTrip = new UserTrip();
                    userTrip.TripId = trip.Id;
                    userTrip.UserId = employee.id;
                    userTrip.Confirmed = false;
                    try
                    {
                        userTrip.Id = db.UserTrips.Max(record => record.Id) + 1;
                    }
                    catch
                    {
                        userTrip.Id = 0;
                    }
                    database.AddUserTrip(userTrip);
                }

            };
         
            ans.success = true;
            ans.message = "Successfully registered trip!";
            return ans;
        }

        // PUT: api/Trip/5

        public void Put(int id, [FromBody] Trip trip)
        {
            database.PutTrip(id, trip);
        }

        public AnswerForTripRegistration Put([FromBody] UpdateTripNameContract tripContract)
        {
            Trip trip = null;
            AnswerForTripRegistration answer = new AnswerForTripRegistration();

            using (pskTravellingEntities db = new pskTravellingEntities())
            {
                trip = db.Trips.FirstOrDefault(x => x.Id == tripContract.CurrentTripId);
            }

            trip.TripName = tripContract.TripName;
            if(!tripContract.Force)
            {
                trip.RowVersion = tripContract.RowVersion;
            }
            
            using (pskTravellingEntities db = new pskTravellingEntities())
            {
                try
                {
                    db.Entry(trip).State = EntityState.Modified;
                    db.SaveChanges();

                    Console.WriteLine("Student saved successfully.");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.Message);
                    answer.success = false;
                    answer.message = "Concurrency Exception Occurred.";
                    return answer;
                }
            }

            
            answer.success = true;
            answer.message = "Successfully updated!";
            return answer;
        }

        // DELETE: api/Trip/5
        public void Delete(int id)
        {
            database.DeleteTripById(id);
        }
    }
}
