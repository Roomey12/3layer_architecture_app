using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Epam5.ADODAL.ADO
{
    public abstract class Database
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\roomey\Desktop\c#\Epam5\Epam5.ADODAL")
            .AddJsonFile("appsettings.json")
            .Build();
        protected static string connectionString = configuration.GetConnectionString("connectionString");
        protected static SqlConnection connection = null;

        public virtual void OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public virtual void CloseConnection()
        {
            if (connection?.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
