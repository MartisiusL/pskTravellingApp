using pskRESTServer.Models.RestModels;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    public class UserController : ApiController
    {
        private Database database = new MockDatabase();

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
        public bool Post([FromBody]NewUser newUser)
        {
            using (pskTravellingEntities db = new pskTravellingEntities())
            {
                //try
                //{
                Account account = new Account();
                account.Email = newUser.Username;
                account.Password = newUser.Password;
                try
                {
                    account.Id = db.Accounts.Max(record => record.Id) + 1;
                }
                catch
                {
                    account.Id = 0;
                }
                db.Accounts.Add(account);

                User user = new User();
                user.IsAdmin = false;
                user.Name = newUser.Name;
                user.Surname = newUser.Surname;
                user.PhoneNumber = newUser.Phone;
                user.AccountId = account.Id;
                try
                {
                    user.Id = db.Users.Max(record => record.Id) + 1;
                } catch
                {
                    user.Id = 0;
                }
                
                db.Users.Add(user);
                db.SaveChanges();
                return true;
                //}
                //catch(Exception ex)
                //{
                //    return false;
                //}

            }
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            database.DeleteUserById(id);
        }
    }
}
