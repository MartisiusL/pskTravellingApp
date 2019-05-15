using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Repository
{
    public interface Database
    {
        List<User> GetUserList();
        List<Office> GetOfficeList();
        List<Trip> GetTripsList();

        User GetUserById(int id);
        Trip GetTripById(int id);
        Account GetAccountByEmail(string email);
        Office GetOfficeById(int id);

        void AddUser(User user);
        void AddAccount(Account account);
        void AddTrip(Trip trip);
        void AddOffice(Office office);

        void DeleteUserById(int id);
        void DeleteAccountById(int id);
        void DeleteTripById(int id);
        void DeleteOfficeById(int id);

    }
}