using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class LoyaltyList
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        string sqlQuery;

        public SqlDataAdapter ListLoyal()
        {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "select ud.[F_NAME], ud.[L_NAME], ud.[CONTACT], SUM(ly.[REWORDS]) AS TOTAL_LOYAL "+
                    "FROM [dbo].[LOYALTY] ly, [dbo].[USER_DETAILS] ud WHERE ly.[UD_ID] = ud.[UD_ID] "+
                    "GROUP BY ud.UD_ID,ud.[F_NAME], ud.[L_NAME], ud.[CONTACT] ORDER BY TOTAL_LOYAL DESC";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

            return dataAdapter;
        }

    }
}
