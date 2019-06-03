using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Database
{
    public class DatabaseSession : IDisposable
    {
        static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ClassroomDatabase"].ConnectionString;

        public IDbConnection Connection { get; } = null;

        public DatabaseSession()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
