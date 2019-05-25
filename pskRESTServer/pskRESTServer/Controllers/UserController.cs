using pskRESTServer.Models;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    public class UserController : ApiController
    {
        private Database database = new AzureDatabase();

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return database.GetUserList();
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return database.GetUserById(id);
        }

        // POST: api/User
        public void Post([FromBody]User user)
        {
            database.AddUser(user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            database.DeleteUserById(id);
        }
    }
}
