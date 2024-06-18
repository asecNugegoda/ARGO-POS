using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class InvoiceTransaction
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        SqlDataAdapter dataAdapter;

        public SqlDataAdapter getInvoices(DateTime begn, DateTime end)
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT inv.[DATE], inv.INV_ID, COUNT(inf.ST_ID) AS ITEM_COUNT, inv.INV_TOTAL "+
                    "FROM [dbo].[INVOICE] inv, [dbo].[INV_INFO] inf WHERE inf.INV_ID=inv.INV_ID AND inv.[DATE] "+
                    "BETWEEN @began AND @end GROUP BY inv.INV_ID, inv.INV_TOTAL, inv.[DATE] ORDER BY inv.[DATE]";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@began",  begn );
                dataAdapter.SelectCommand.Parameters.AddWithValue("@end", end);

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

            return dataAdapter;
        }

        public SqlDataAdapter getPOs(DateTime begn, DateTime end)
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "  SELECT pur.[DATE], pur.PURCHASE_NO, COUNT(inf.ST_ID) AS ITEM_COUNT, pur.PO_PRICE "+
                    "FROM [dbo].[PURCHASING] pur, [dbo].[PO_INFO] inf WHERE inf.PO_ID=pur.PO_ID AND pur.[DATE] "+
                    "BETWEEN @began AND @end GROUP BY pur.PO_ID, pur.PO_PRICE, pur.PURCHASE_NO, pur.[DATE] ORDER BY pur.[DATE]";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@began", begn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@end", end);

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

            return dataAdapter;
        }

        public decimal getInvoiceTotal(DateTime begn, DateTime end)
        {
            decimal total = 0;
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT SUM([INV_TOTAL]) AS TOTAL FROM [dbo].[INVOICE]  WHERE [DATE] BETWEEN @began AND @end ";           
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@began", begn));
                command.Parameters.Add(new SqlParameter("@end", end));

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    total = dataReader.GetDecimal(0);
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return total;
        }

        public decimal getPOTotal(DateTime begn, DateTime end)
        {
            decimal total = 0;
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT SUM(pur.PO_PRICE) AS TOTAL FROM [dbo].[PURCHASING] pur WHERE pur.[DATE] BETWEEN @began AND @end ";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@began", begn));
                command.Parameters.Add(new SqlParameter("@end", end));

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    total = dataReader.GetDecimal(0);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return total;
        }

    }
}
