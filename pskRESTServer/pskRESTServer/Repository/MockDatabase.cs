﻿using pskRESTServer.Models;
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
            u.AccountId = a.Id;
            u.IsAdmin = false;
            users.Add(u);

            t.Id = 401;
            t.TripName = "komandiruote 1";
            t.FromOfficeId = offices[0].Id;
            t.ToOfficeId = offices[1].Id;
            trips.Add(t);

            t = new Trip();
            t.Id = 402;
            t.TripName = "komandiruote 2";
            t.FromOfficeId = offices[0].Id;
            t.ToOfficeId = offices[2].Id;
            trips.Add(t);

            t = new Trip();
            t.Id = 403;
            t.TripName = "komandiruote 3";
            t.FromOfficeId = offices[1].Id;
            t.ToOfficeId = offices[2].Id;
            trips.Add(t);

            t = new Trip();
            t.Id = 404;
            t.TripName = "komandiruote 4";
            t.FromOfficeId = offices[2].Id;
            t.ToOfficeId = offices[0].Id;
           
            trips.Add(t);
        }
    }
}