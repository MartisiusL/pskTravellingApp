using pskRESTServer.Repository;
using pskRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pskRESTServer.Filters;

namespace pskRESTServer.Controllers
{
    [LogInvocationsFilters]
    public class AccountController : ApiController
    {
        private Database database = new AzureDatabase();

        // POST: api/account
        public void Post([FromBody]Account account)
        {
            database.AddAccount(account);
        }

        // DELETE: api/account/5
        public void Delete(int id)
        {
            database.DeleteAccountById(id);
        }
    }
}
