using pskRESTServer.Models;
using pskRESTServer.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Repository
{
    public class MockDatabase : Database
    {
        private List<User> users = new List<User>();
        private List<Account> accounts = new List<Account>();
        private List<Office> offices = new List<Office>();
        private List<Trip> trips = new List<Trip>();
        private List<TripWithConfirmation> tripWithConfirmations = new List<TripWithConfirmation>();
        private List<UserTrip> userTrips = new List<UserTrip>();

        public MockDatabase()
        {
            GenerateData();
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
            return trips;
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

        public Office GetOfficeById(int id)
        {
            return offices.FirstOrDefault(x => x.Id == id);
        }

        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void AddOffice(Office office)
        {
            offices.Add(office);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }


        public void DeleteUserById(int id)
        {
            users.RemoveAll(x => x.Id == id);
        }

        public void DeleteAccountById(int id)
        {
            accounts.RemoveAll(x => x.Id == id);
        }

        public void DeleteTripById(int id)
        {
            trips.RemoveAll(x => x.Id == id);
        }

        public void DeleteOfficeById(int id)
        {
            offices.RemoveAll(x => x.Id == id);
        }

        public void GenerateData()
        {
            User u = new User();
            Account a = new Account();
            Office o = new Office();
            Trip t = new Trip();

            o.Id = 201;
            o.OfficeName = "Vilnius";
            o.OfficeAddress = "Didlaukio 59";
            offices.Add(o);

            a.Id = 101;
            a.Email = "test@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u.Id = 501;
            u.Name = "Lukas";
            u.Surname = "Martisius";
            u.PhoneNumber = "+37066666666";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = true;
            users.Add(u);

            a = new Account();
            a.Id = 102;
            a.Email = "abc@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 502;
            u.Name = "Liutauras";
            u.Surname = "Butkinas";
            u.PhoneNumber = "+37066666667";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = true;
            users.Add(u);
            u = new User();

            a = new Account();
            a.Id = 103;
            a.Email = "def@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 503;
            u.Name = "Modestas";
            u.Surname = "Dulevicius";
            u.PhoneNumber = "+37066666668";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = true;
            users.Add(u);          

            o = new Office();
            o.Id = 202;
            o.OfficeName = "Kaunas";
            o.OfficeAddress = "Savanoriu 42";
            offices.Add(o);

            a = new Account();
            a.Id = 104;
            a.Email = "ghi@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 504;
            u.Name = "Simonas";
            u.Surname = "Butkus";
            u.PhoneNumber = "+37066666669";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = true;
            users.Add(u);

            a = new Account();
            a.Id = 105;
            a.Email = "ghi@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 505;
            u.Name = "Benas";
            u.Surname = "Gudeliauskas";
            u.PhoneNumber = "+37066666670";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = true;
            users.Add(u);

            a = new Account();
            a.Id = 106;
            a.Email = "jkl@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 506;
            u.Name = "Tomas";
            u.Surname = "Maironis";
            u.PhoneNumber = "+37066666671";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = false;
            users.Add(u);

            a = new Account();
            a.Id = 107;
            a.Email = "mno@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 507;
            u.Name = "Jonas";
            u.Surname = "Skardzius";
            u.PhoneNumber = "+37066666672";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = false;
            users.Add(u);

            o = new Office();
            o.Id = 203;
            o.OfficeName = "Klaipeda";
            o.OfficeAddress = "Juros 12";
            offices.Add(o);

            a = new Account();
            a.Id = 108;
            a.Email = "prs@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 508;
            u.Name = "Paulius";
            u.Surname = "Juozaitis";
            u.PhoneNumber = "+37066666673";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = false;
            users.Add(u);

            a = new Account();
            a.Id = 109;
            a.Email = "tuv@gmail.com";
            a.Password = "123456";
            accounts.Add(a);

            u = new User();
            u.Id = 509;
            u.Name = "Rokas";
            u.Surname = "Andrijauskas";
            u.PhoneNumber = "+37066666674";
            //u.OfficeId = o.Id;
            u.AccountId = a.Id;
            u.IsAdmin = false;
            users.Add(u);

            t.Id = 401;
            t.TripName = "komandiruote 1";
            t.FromOfficeId = offices[0].Id;
            t.ToOfficeId = offices[1].Id;
            //t.peopleOfTheTrip.Add(users[0]);
            //t.peopleAnswersForTheTrip.Add(false);
            //t.peopleOfTheTrip.Add(users[2]);
            //t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);

            t = new Trip();
            t.Id = 402;
            t.TripName = "komandiruote 2";
            t.FromOfficeId = offices[0].Id;
            t.ToOfficeId = offices[2].Id;
            //t.peopleOfTheTrip.Add(users[0]);
            //t.peopleAnswersForTheTrip.Add(false);
            //t.peopleOfTheTrip.Add(users[1]);
            //t.peopleAnswersForTheTrip.Add(true);
            //t.peopleOfTheTrip.Add(users[2]);
            //t.peopleAnswersForTheTrip.Add(false);
            trips.Add(t);

            t = new Trip();
            t.Id = 403;
            t.TripName = "komandiruote 3";
            t.FromOfficeId = offices[1].Id;
            t.ToOfficeId = offices[2].Id;
            //t.peopleOfTheTrip.Add(users[3]);
            //t.peopleAnswersForTheTrip.Add(false);
            //t.peopleOfTheTrip.Add(users[4]);
            //t.peopleAnswersForTheTrip.Add(true);
            //t.peopleOfTheTrip.Add(users[5]);
            //t.peopleAnswersForTheTrip.Add(false);
            //t.peopleOfTheTrip.Add(users[6]);
            //t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);

            t = new Trip();
            t.Id = 404;
            t.TripName = "komandiruote 4";
            t.FromOfficeId = offices[2].Id;
            t.ToOfficeId = offices[0].Id;
            //t.peopleOfTheTrip.Add(users[7]);
            //t.peopleAnswersForTheTrip.Add(false);
            //t.peopleOfTheTrip.Add(users[8]);
            //t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);
        }

        public List<TripWithConfirmation> GetTripsListByUserId(int id)
        {
            //return tripWithConfirmations.FindAll(x => x.UserTripId == id);
            //return users.First(user => user.Id == id).
            //    UserTrips.Select(ut => new TripWithConfirmation(ut.Trip)
            //    { confirmed = ut.Confirmed, UserTripId = ut.Id }).ToList();
            List<UserTrip> u = userTrips.FindAll(trip => trip.UserId == id);
            List<TripWithConfirmation> t = new List<TripWithConfirmation>();
            foreach (UserTrip userTrip in u)
            {
                t.Add(new TripWithConfirmation(GetTripById(userTrip.TripId))
                { confirmed = userTrip.Confirmed, UserTripId = userTrip.Id });
            }

            return t;
        }

        public List<Trip> GetTripsListByOrganizerId(int id)
        {
            return trips.Where(x => x.OrganizerId == id).ToList();
        }

        public Trip GetTripByIdForOrganizer(int id)
        {
            return trips.Where(x => x.Id == id).Select(x => new TripWithUserTrips(x)).First();
        }

        public void AddUserTrip(UserTrip userTrip)
        {
            userTrips.Add(userTrip);
        }

        public void PutTrip(int id, Trip trip)
        {
            trips.Remove(trips.FirstOrDefault(x => x.Id == id));
            trips.Add(trip);
        }

        public void PutUserTrip(int id, bool confirmed)
        {
            userTrips.FirstOrDefault(x => x.Id == id).Confirmed = confirmed;
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
                trip.Id = trips.Max(record => record.Id) + 1;
            }
            catch
            {
                trip.Id = 0;
            }

            trips.Add(trip);

            foreach (selectedItems employee in tripContract.selectedItems)
            {
                UserTrip userTrip = new UserTrip();
                userTrip.TripId = trip.Id;
                userTrip.UserId = employee.id;
                userTrip.Confirmed = false;
                try
                {
                    userTrip.Id = userTrips.Max(record => record.Id) + 1;
                }
                catch
                {
                    userTrip.Id = 0;
                }
                userTrips.Add(userTrip);
            }
        }

        public int AddUserByContract(NewUser newUser)
        {
            Account account = new Account();
            account.Email = newUser.Username;
            account.Password = newUser.Password;
            try
            {
                account.Id = accounts.Max(record => record.Id) + 1;
            }
            catch
            {
                account.Id = 0;
            }
            accounts.Add(account);

            User user = new User();
            user.IsAdmin = false;
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            user.PhoneNumber = newUser.Phone;
            user.AccountId = account.Id;
            try
            {
                user.Id = users.Max(record => record.Id) + 1;
            }
            catch
            {
                user.Id = 0;
            }

            users.Add(user);
            return user.Id;
        }

        public bool PutTripName(UpdateTripNameContract tripContract)
        {
            trips.FirstOrDefault(x => x.Id == tripContract.CurrentTripId).TripName = tripContract.TripName;
            return true;
        }

        
    }
}