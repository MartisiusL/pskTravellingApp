using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Repository
{
    public class AzureDatabase : Database
    {

        private List<User> users = new List<User>();
        private List<Account> accounts = new List<Account>();
        private List<Office> offices = new List<Office>();
        private List<Trip> trips = new List<Trip>();
        private pskTravellingEntities entities = new pskTravellingEntities();

        public AzureDatabase()
        {
            users = entities.Users.ToList();
            accounts = entities.Accounts.ToList();
            offices = entities.Offices.ToList();
            trips = entities.Trips.ToList();
        }

        public List<User> GetUserList()
        {
            return users;
        }

        public List<Office> GetOfficeList()
        {
            return offices;
        }

        public List<Trip> GetTripsList()
        {
            return entities.Trips.Select(trip => trip).ToList();
            //return trips;
        }

        public List<TripWithConfirmation> GetTripsListByUserId(int id) {
            return entities.Users.First(user => user.Id == id).UserTrips.Select(ut => new TripWithConfirmation(ut.Trip) {confirmed = ut.Confirmed }).ToList();
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public Trip GetTripById(int id)
        {
            return trips.FirstOrDefault(x => x.Id == id);
        }

        public Account GetAccountByEmail(string email)
        {
            return accounts.FirstOrDefault(x => x.Email == email);
        }

        public Account GetAccountById(int id)
        {
            return accounts.FirstOrDefault(x => x.Id == id);
        }

        public Office GetOfficeById(int id)
        {
            return offices.FirstOrDefault(x => x.Id == id);
        }

        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
            entities.Trips.Add(trip);
            entities.SaveChangesAsync();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            entities.Accounts.Add(account);
            entities.SaveChangesAsync();
        }

        public void AddOffice(Office office)
        {
            offices.Add(office);
            entities.Offices.Add(office);
            entities.SaveChangesAsync();
        }

        public void AddUser(User user)
        {
            users.Add(user);
            entities.Users.Add(user);
            entities.SaveChangesAsync();
        }


        public void DeleteUserById(int id)
        {
            User toDelete = this.GetUserById(id);
            entities.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChangesAsync();
            users.RemoveAll(x => x.Id == id);
        }

        public void DeleteAccountById(int id)
        {
            Account toDelete = this.GetAccountById(id);
            entities.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChangesAsync();
            accounts.RemoveAll(x => x.Id == id);
        }

        public void DeleteTripById(int id)
        { 
            Trip toDelete = this.GetTripById(id);
            entities.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChangesAsync();
            trips.RemoveAll(x => x.Id == id);
        }

        public void DeleteOfficeById(int id)
        {
            Office toDelete = this.GetOfficeById(id);
            entities.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
            entities.SaveChangesAsync();
            offices.RemoveAll(x => x.Id == id);
        }

        public void PutTrip(int id, Trip trip) {
            var oldTrip = GetTripById(id);
            oldTrip.TripName = trip.TripName;
            oldTrip.TripDate = trip.TripDate;
            oldTrip.ToOfficeId = trip.ToOfficeId;
            oldTrip.FromOfficeId = trip.FromOfficeId;
        }

        public void PutUserTrip(int tripId, int userId, bool answer) {
            var oldUserTrip = GetTripById(tripId).UserTrips
                .Where(ut => ut.TripId == tripId && ut.UserId == userId).FirstOrDefault();
            oldUserTrip.Confirmed = answer;
        }
    }
}