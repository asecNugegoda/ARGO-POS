using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class CreateCategory
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;

        public void createNewCategory(string categry)
        {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO CATEGORIES([CATGORY],[STATUS_ID]) VALUES(@category, @status)";

                SqlParameter p1 = new SqlParameter("@category", categry);
                SqlParameter p2 = new SqlParameter("@status", 1);

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();
                conn.Close();
                command.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
