using pskRESTServer.Filters;
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
    [LogInvocationsFilters]
    public class OfficeController : ApiController
    {

        // GET: api/office
        public IEnumerable<Office> Get()
        {
            return RepositoryGetter.getDatabase().GetOfficeList();
        }

        // GET: api/office/5
        public Office Get(int id)
        {
            return RepositoryGetter.getDatabase().GetOfficeById(id);
        }

        // POST: api/office
        public void Post([FromBody]Office office)
        {
            RepositoryGetter.getDatabase().AddOffice(office);
        }

        // DELETE: api/office/5
        public void Delete(int id)
        {
            RepositoryGetter.getDatabase().DeleteOfficeById(id);
        }
    }
}
