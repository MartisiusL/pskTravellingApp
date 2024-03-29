﻿using pskRESTServer.Models;
using pskRESTServer.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Repository
{

    /*
     Models we need:

        --> First and the most important make it accessible to for anyone somehow or ask the
        IPs or whatever needed to add everyone so everyone can at least use the program 
        without mock database

        Models to add modify
        --> UserTrip    - which holds user and trip id also boolean whether it is confirmed
        possibly will hold plane id, car id and hotel id if we can rush to make these models
        implemented somewhere, it should be like a binding model to connect all the arrays
        also I believe this is gonna be a place where we add our optimistic lock, so probably
        instantiate the field opt_lock_version which would always start at 0 on create and
        later would increase by one, im not sure how these things work in database maybe it
        has to be set manually, but if not then it should be automatic increase on each push

        --> for the trip, modify so it has start and end date not only single date

        --> for the office it doesnt need to hold the string accounts, the user itself will have it

        --> for the user make it have the accountId and officeId ints 

        Most likely add these:

        --> Plane  which has ticketNumber, Id, maybe price
        --> Car    which has its licence plate number, Id, price for day
        --> Hotel/Room   which has roomNumber, Id, address, price for night

        maybe i forgot something, so just try to make it logical, so we dont keep excessive information
        change the data through ids. We will discuss this later if any more questions appears.
         */
    public interface Database
    {
        List<User> GetUserList();
        List<Office> GetOfficeList();
        List<Trip> GetTripsList();
        List<TripWithConfirmation> GetTripsListByUserId(int id);
        List<Availability> GetAvailabilitiesById(int id);

        List<Trip> GetTripsListByOrganizerId(int id);
        Trip GetTripByIdForOrganizer(int id);

        User GetUserById(int id);
        User GetUserByAccountId(int accountId);
        Trip GetTripById(int id);
        Account GetAccountByEmail(string email);
        Office GetOfficeById(int id);
        UserTrip GetUserTripById(int id);

        void AddUser(User user);
        void AddAccount(Account account);
        void AddTrip(Trip trip);
        void AddOffice(Office office);
        void AddUserTrip(UserTrip userTrip);

        void MergeTrips(int firstTripId, int secondTripId);

        void AddTripByContract(TripContract tripContract);
        void AddAvailability(AvailabilityContract availability);
        int AddUserByContract(NewUser user);
        void AddAvailabilityTrip(int userTripId);

        void DeleteUserById(int id);
        void DeleteAccountById(int id);
        void DeleteTripById(int id);
        void DeleteOfficeById(int id);
        void DeleteAvailabilityTrip(int userTripId);
        void DeleteAvailability(int availabilityId);

        void PutTrip(int id, Trip trip);
        void PutUserTrip(int id, bool confirmed);
        bool PutTripName(UpdateTripNameContract tripContract);


    }
}