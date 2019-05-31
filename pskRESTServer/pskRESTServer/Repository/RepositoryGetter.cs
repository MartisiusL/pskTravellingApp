using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pskRESTServer.Repository
{
    public static class RepositoryGetter
    {
        private static Database database;

        public static Database getDatabase()
        {
            if(database == null)
            {
                database = new AzureDatabase();
            }
            return database;
        }
    }
}