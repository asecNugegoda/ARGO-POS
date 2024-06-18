using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class DBConnection
    {

        string connectionString = Setting.Default.ConnectionString;
        public SqlConnection connection;

        public SqlConnection CreateConnection()
        {

            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception)
            {
                Console.WriteLine("Conection Open fail!");
            }

            return connection;

        }

    }
}
