using pskRESTServer.Filters;
using pskRESTServer.Models.RestModels;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    [LogInvocationsFilters]
    public class UserController : ApiController
    {
        //private Database database = new AzureDatabase();

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return RepositoryGetter.getDatabase().GetUserList();
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return RepositoryGetter.getDatabase().GetUserById(id);
        }

        [Route("api/username/{id}")]
        public string GetUserName(int id)
        {
            try
            {
                return RepositoryGetter.getDatabase().GetUserById(id).Name;
            }
            catch
            {
                return "Not set";
            }
            
        }

        // POST: api/User
        public AnswerForRegistration Post([FromBody]NewUser newUser)
        {            
            AnswerForRegistration answerForRegistration = new AnswerForRegistration();
            answerForRegistration.success = true;
            answerForRegistration.userId = RepositoryGetter.getDatabase().AddUserByContract(newUser);
            return answerForRegistration;          
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            RepositoryGetter.getDatabase().DeleteUserById(id);
        }
    }
}
