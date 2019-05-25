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
            return trips;
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
            users.RemoveAll(x => x.Id == id);
            User toDelete = new User() { Id = id };
            entities.Users.Attach(toDelete);
            entities.Users.Remove(toDelete);
            entities.SaveChangesAsync();
        }

        public void DeleteAccountById(int id)
        {
            accounts.RemoveAll(x => x.Id == id);
            Account toDelete = new Account() { Id = id };
            entities.Accounts.Attach(toDelete);
            entities.Accounts.Remove(toDelete);
            entities.SaveChangesAsync();
        }

        public void DeleteTripById(int id)
        {
            trips.RemoveAll(x => x.Id == id);
            Trip toDelete = new Trip() { Id = id };
            entities.Trips.Attach(toDelete);
            entities.Trips.Remove(toDelete);
            entities.SaveChangesAsync();
        }

        public void DeleteOfficeById(int id)
        {
            offices.RemoveAll(x => x.Id == id);
            Office toDelete = new Office() { Id = id };
            entities.Offices.Attach(toDelete);
            entities.Offices.Remove(toDelete);
            entities.SaveChangesAsync();
        }
    }
}