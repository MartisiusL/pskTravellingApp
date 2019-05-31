using pskRESTServer.Filters;
using pskRESTServer.Models;
using pskRESTServer.Models.RestModels;
using pskRESTServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pskRESTServer.Controllers
{
    [LogInvocationsFilters]
    public class AuthorizationController : ApiController
    {
        [Route("api/authorization/{email}/{password}")]
        public int Get(String email, String password)
        {
            Account a = RepositoryGetter.getDatabase().GetAccountByEmail(email);
            //if (a != null && database.GetAccountByEmail(email).password == password)
            //    return a.ID;
            //else
            //    return -1;
            return 0;
        }

        public AnswerForAuth Post([FromBody]AuthorizationBody value)
        {
            AnswerForAuth answer = new AnswerForAuth();       
            Account account = RepositoryGetter.getDatabase().GetAccountByEmail(value.Username);
            try
            {
                if (account.Password != value.Password)
                {
                    answer.success = false;
                    answer.message = "Invalid username or password";
                    return answer;
                }
                else
                {
                    answer.success = true;
                    answer.message = "Successfully authenticated";
                    User user = RepositoryGetter.getDatabase().GetUserByAccountId(account.Id);
                    answer.userId = user.Id;
                    answer.admin = user.IsAdmin;
                }
                return answer;
            }
            catch
            {
                answer.success = false;
                answer.message = "Something went wrong";
                return answer;
            }
                 
           
        }
    }
}
