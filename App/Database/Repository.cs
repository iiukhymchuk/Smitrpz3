using Dapper;
using System.Collections.Generic;
using System.Data;

namespace App.Database
{
    public class Repository
    {
        protected IDbConnection connection = null;

        public Repository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<dynamic> Get(string query)
        {
            return connection?.Query(query);
        }
    }
}