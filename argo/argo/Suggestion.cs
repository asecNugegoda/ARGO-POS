using argo.DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo
{
    class Suggestion
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        AutoCompleteStringCollection autoComplete;

        public AutoCompleteStringCollection getItemList()
        {

            autoComplete = new AutoCompleteStringCollection();
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT [PRODUCT_NAME] FROM [dbo].[PRODUCT]";

                command = new SqlCommand(sqlQuery, conn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    autoComplete.Add(dataReader.GetString(0));
                    Console.WriteLine(dataReader.GetString(0));
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return autoComplete;
        }


    }
}
