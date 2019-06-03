using pskRESTServer.Models;
using pskRESTServer.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private List<Availability> availabilities = new List<Availability>();
        private List<UserTrip> userTrips = new List<UserTrip>();
        private pskTravellingEntities entities = new pskTravellingEntities();

        public AzureDatabase()
        {
            users = entities.Users.ToList();
            accounts = entities.Accounts.ToList();
            offices = entities.Offices.ToList();
            trips = entities.Trips.ToList();
            availabilities = entities.Availabilities.ToList();
            userTrips = entities.UserTrips.ToList();
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

        public List<TripWithConfirmation> GetTripsListByUserId(int id)
        {
            return entities.Users.First(user => user.Id == id).
                UserTrips.Select(ut => new TripWithConfirmation(ut.Trip)
                { confirmed = ut.Confirmed, UserTripId = ut.Id }).ToList();
        }

        public List<Trip> GetTripsListByOrganizerId(int id)
        {
            return entities.Trips.Where(trip => trip.OrganizerId == id).ToList();
        }

        public Trip GetTripByIdForOrganizer(int id)
        {
            return entities.Trips.Where(x => x.Id == id).ToList()
                .Select(x => new TripWithUserTrips(x) {
                    UserTrips = entities.UserTrips.Where(y => y.TripId == id).ToList()
                }).First();
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByAccountId(int accountId)
        {
            return users.FirstOrDefault(x => x.AccountId == accountId);
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
            entities.SaveChanges();
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
            oldTrip.TripStartDate = trip.TripStartDate;
            oldTrip.ToOfficeId = trip.ToOfficeId;
            oldTrip.FromOfficeId = trip.FromOfficeId;
            entities.SaveChanges();
        }

        public void PutUserTrip(int userTripId, bool answer) {
            var oldUserTrip = entities.UserTrips.Where(ut => ut.Id == userTripId).FirstOrDefault();
            oldUserTrip.Confirmed = answer;
            entities.SaveChanges();
        }

        public void AddUserTrip(UserTrip userTrip)
        {
            entities.UserTrips.Add(userTrip);
            entities.SaveChanges();
        }

        public void AddTripByContract(TripContract tripContract)
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
            trip.OrganizerId = tripContract.organizerId;
            try
            {
                trip.Id = entities.Trips.Max(record => record.Id) + 1;
            }
            catch
            {
                trip.Id = 0;
            }

            RepositoryGetter.getDatabase().AddTrip(trip);

            foreach (selectedItems employee in tripContract.selectedItems)
            {
                UserTrip userTrip = new UserTrip();
                userTrip.TripId = trip.Id;
                userTrip.UserId = employee.id;
                userTrip.Confirmed = false;
                try
                {
                    userTrip.Id = entities.UserTrips.Max(record => record.Id) + 1;
                }
                catch
                {
                    userTrip.Id = 0;
                }
                RepositoryGetter.getDatabase().AddUserTrip(userTrip);
            }
        }

        public bool PutTripName(UpdateTripNameContract tripContract)
        {

            Trip trip = entities.Trips.FirstOrDefault(x => x.Id == tripContract.CurrentTripId);

            trip.TripName = tripContract.TripName;
            if (!tripContract.Force)
            {
                trip.RowVersion = tripContract.RowVersion;
            }

            try
            {
                entities.Entry(trip).State = EntityState.Modified;
                entities.SaveChanges();

                Console.WriteLine("Student saved successfully.");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public int AddUserByContract(NewUser newUser)
        {
            Account account = new Account();
            account.Email = newUser.Username;
            account.Password = newUser.Password;
            try
            {
                account.Id = entities.Accounts.Max(record => record.Id) + 1;
            }
            catch
            {
                account.Id = 0;
            }
            entities.Accounts.Add(account);
            accounts.Add(account);

            User user = new User();
            user.IsAdmin = false;
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            user.PhoneNumber = newUser.Phone;
            user.AccountId = account.Id;
            try
            {
                user.Id = entities.Users.Max(record => record.Id) + 1;
            }
            catch
            {
                user.Id = 0;
            }

            entities.Users.Add(user);
            entities.SaveChanges();
            users.Add(user);
            return user.Id;
        }

        public List<Availability> GetAvailabilitiesById(int id)
        {
            return availabilities.FindAll(x => x.UserId == id);
        }

        public void AddAvailability(AvailabilityContract availabilityContract)
        {
            Availability availability = new Availability();
            availability.Title = availabilityContract.Title;
            availability.BusyFrom = availabilityContract.BusyFrom;
            availability.BusyTo = availabilityContract.BusyTo;
            availability.UserId = availabilityContract.UserId;

            availabilities.Add(availability);
            entities.Availabilities.Add(availability);
            entities.SaveChanges();
        }

        public void AddAvailabilityTrip(int userTripId)
        {
            UserTrip userTrip = GetUserTripById(userTripId);
            Trip trip = GetTripById(userTrip.TripId);
            Availability availability = new Availability();
            availability.Title = trip.TripName;
            availability.BusyFrom = trip.TripStartDate;
            availability.BusyTo = trip.TripEndDate;
            availability.UserId = GetUserTripById(userTripId).UserId;
            availabilities.Add(availability);
            entities.Availabilities.Add(availability);
            entities.SaveChanges();
        }

        public void DeleteAvailabilityTrip(int userTripId)
        {
            List<Availability> myAvailabilites = availabilities.FindAll(x => x.UserId == GetUserTripById(userTripId).UserId);
            Trip trip = trips.FirstOrDefault(x => x.Id == GetUserTripById(userTripId).TripId);
            Availability a = availabilities.FirstOrDefault(x => x.BusyFrom == trip.TripStartDate && x.BusyTo == trip.TripEndDate && x.Title == trip.TripName);
            availabilities.Remove(a);
            entities.Availabilities.Remove(a);
            entities.SaveChanges();
        }

        public UserTrip GetUserTripById(int id)
        {
            return entities.UserTrips.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteAvailability(int availabilityId)
        {
            Availability availability = availabilities.FirstOrDefault(x => x.Id == availabilityId);
            availabilities.Remove(availability);
            entities.Availabilities.Remove(availability);
            entities.SaveChanges();
        }
    }
}