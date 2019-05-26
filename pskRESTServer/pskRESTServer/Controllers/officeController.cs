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
    public class OfficeController : ApiController
    {
        private Database database = new AzureDatabase();

        // GET: api/office
        public IEnumerable<Office> Get()
        {
            return database.GetOfficeList();
        }

        // GET: api/office/5
        public Office Get(int id)
        {
            return database.GetOfficeById(id);
        }

        // POST: api/office
        public void Post([FromBody]Office office)
        {
            database.AddOffice(office);
        }

        // DELETE: api/office/5
        public void Delete(int id)
        {
            database.DeleteOfficeById(id);
        }
    }
}
