using pskRESTServer.Models;
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
            return users.FirstOrDefault(x => x.ID == id);
        }

        public Trip GetTripById(int id)
        {
            return trips.FirstOrDefault(x => x.ID == id);
        }

        public Account GetAccountByEmail(string email)
        {
            return accounts.FirstOrDefault(x => x.email == email);
        }

        public Office GetOfficeById(int id)
        {
            return offices.FirstOrDefault(x => x.ID == id);
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
            users.RemoveAll(x => x.ID == id);
        }

        public void DeleteAccountById(int id)
        {
            accounts.RemoveAll(x => x.ID == id);
        }

        public void DeleteTripById(int id)
        {
            trips.RemoveAll(x => x.ID == id);
        }

        public void DeleteOfficeById(int id)
        {
            offices.RemoveAll(x => x.ID == id);
        }

        public void GenerateData()
        {
            User u = new User();
            Account a = new Account();
            Office o = new Office();
            Trip t = new Trip();

            o.ID = 201;
            o.officeName = "Vilnius";
            o.address = "Didlaukio 59";
            offices.Add(o);

            a.ID = 101;
            a.email = "test@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u.ID = 501;
            u.name = "Lukas";
            u.surname = "Martisius";
            u.phoneNumber = "+37066666666";
            u.office = o;
            u.account = a;
            u.admin = true;
            users.Add(u);

            a = new Account();
            a.ID = 102;
            a.email = "abc@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 502;
            u.name = "Liutauras";
            u.surname = "Butkinas";
            u.phoneNumber = "+37066666667";
            u.office = o;
            u.account = a;
            u.admin = true;
            users.Add(u);
            u = new User();

            a = new Account();
            a.ID = 103;
            a.email = "def@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 503;
            u.name = "Modestas";
            u.surname = "Dulevicius";
            u.phoneNumber = "+37066666668";
            u.office = o;
            u.account = a;
            u.admin = true;
            users.Add(u);          

            o = new Office();
            o.ID = 202;
            o.officeName = "Kaunas";
            o.address = "Savanoriu 42";
            offices.Add(o);

            a = new Account();
            a.ID = 104;
            a.email = "ghi@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 504;
            u.name = "Simonas";
            u.surname = "Butkus";
            u.phoneNumber = "+37066666669";
            u.office = o;
            u.account = a;
            u.admin = true;
            users.Add(u);

            a = new Account();
            a.ID = 105;
            a.email = "ghi@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 505;
            u.name = "Benas";
            u.surname = "Gudeliauskas";
            u.phoneNumber = "+37066666670";
            u.office = o;
            u.account = a;
            u.admin = true;
            users.Add(u);

            a = new Account();
            a.ID = 106;
            a.email = "jkl@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 506;
            u.name = "Tomas";
            u.surname = "Maironis";
            u.phoneNumber = "+37066666671";
            u.office = o;
            u.account = a;
            u.admin = false;
            users.Add(u);

            a = new Account();
            a.ID = 107;
            a.email = "mno@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 507;
            u.name = "Jonas";
            u.surname = "Skardzius";
            u.phoneNumber = "+37066666672";
            u.office = o;
            u.account = a;
            u.admin = false;
            users.Add(u);

            o = new Office();
            o.ID = 203;
            o.officeName = "Klaipeda";
            o.address = "Juros 12";
            offices.Add(o);

            a = new Account();
            a.ID = 108;
            a.email = "prs@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 508;
            u.name = "Paulius";
            u.surname = "Juozaitis";
            u.phoneNumber = "+37066666673";
            u.office = o;
            u.account = a;
            u.admin = false;
            users.Add(u);

            a = new Account();
            a.ID = 109;
            a.email = "tuv@gmail.com";
            a.password = "123456";
            accounts.Add(a);

            u = new User();
            u.ID = 509;
            u.name = "Rokas";
            u.surname = "Andrijauskas";
            u.phoneNumber = "+37066666674";
            u.office = o;
            u.account = a;
            u.admin = false;
            users.Add(u);

            t.ID = 401;
            t.name = "komandiruote 1";
            t.fromOffice = offices[0];
            t.toOffice = offices[1];
            t.peopleOfTheTrip.Add(users[0]);
            t.peopleAnswersForTheTrip.Add(false);
            t.peopleOfTheTrip.Add(users[2]);
            t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);

            t = new Trip();
            t.ID = 402;
            t.name = "komandiruote 2";
            t.fromOffice = offices[0];
            t.toOffice = offices[2];
            t.peopleOfTheTrip.Add(users[0]);
            t.peopleAnswersForTheTrip.Add(false);
            t.peopleOfTheTrip.Add(users[1]);
            t.peopleAnswersForTheTrip.Add(true);
            t.peopleOfTheTrip.Add(users[2]);
            t.peopleAnswersForTheTrip.Add(false);
            trips.Add(t);

            t = new Trip();
            t.ID = 403;
            t.name = "komandiruote 3";
            t.fromOffice = offices[1];
            t.toOffice = offices[2];
            t.peopleOfTheTrip.Add(users[3]);
            t.peopleAnswersForTheTrip.Add(false);
            t.peopleOfTheTrip.Add(users[4]);
            t.peopleAnswersForTheTrip.Add(true);
            t.peopleOfTheTrip.Add(users[5]);
            t.peopleAnswersForTheTrip.Add(false);
            t.peopleOfTheTrip.Add(users[6]);
            t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);

            t = new Trip();
            t.ID = 404;
            t.name = "komandiruote 4";
            t.fromOffice = offices[2];
            t.toOffice = offices[0];
            t.peopleOfTheTrip.Add(users[7]);
            t.peopleAnswersForTheTrip.Add(false);
            t.peopleOfTheTrip.Add(users[8]);
            t.peopleAnswersForTheTrip.Add(true);
            trips.Add(t);
        }
    }
}