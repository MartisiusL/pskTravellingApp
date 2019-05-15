﻿using pskRESTServer.Models;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    public class AuthorizationController : ApiController
    {
        private Database database = new MockDatabase();

        [Route("api/authorization/{email}/{password}")]
        public int Get(String email, String password)
        {
            Account a = database.GetAccountByEmail(email);
            if (a != null && database.GetAccountByEmail(email).password == password)
                return a.ID;
            else
                return -1;
        }
    }
}
