using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConnectionDB
{
    class Connection
    {
        private readonly SqlConnection connection;

        public Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WebNet"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
