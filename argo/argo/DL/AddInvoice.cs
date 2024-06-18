using argo.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class AddInvoice
    {
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        InvoiceLoyal loyal;

        public InvoiceLoyal CreateInvoice(List<ProductDetail> list, InvoiceInfo invoice)
        {
            int success = 0;
            decimal loyalty = 0;
            try
            {

                int inv_id = InsertInvoice(invoice);

                if (invoice.UserInfo != null)
                {
                    loyalty = UpdateLoyalty(invoice, inv_id);
                }

                foreach (ProductDetail product in list)
                {
                    InsertInvInfo(product, inv_id);
                    updateStock(product);
                    success = 1;
                }

                loyal = new InvoiceLoyal();
                loyal.InvoiceNo = inv_id;
                loyal.Loyal = loyalty;
                loyal.Success = success;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return loyal;
        }

        private decimal UpdateLoyalty(InvoiceInfo invoice, int inv_id)
        {
            decimal loyalty = 0;
            try
            {

                loyalty = Convert.ToDecimal(0.01) * invoice.InvoiceTotal;

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[LOYALTY] ([UD_ID],[INV_ID],[REWORDS],[STATUS_ID]) VALUES (@ud_id, @inv_id ,@reword, @status)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@ud_id", invoice.UserInfo.UserId));
                command.Parameters.Add(new SqlParameter("@inv_id", inv_id));
                command.Parameters.Add(new SqlParameter("@reword", loyalty));
                command.Parameters.Add(new SqlParameter("@status", 1));

                command.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return loyalty;
        }

        private void updateStock(ProductDetail product)
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "UPDATE [dbo].[STOCK] SET [QNTY] = ([QNTY]- @val) WHERE [ST_ID]= @st_id";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@val", product.Qnty));
                command.Parameters.Add(new SqlParameter("@st_id", product.Stock_id));

                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private void InsertInvInfo(ProductDetail product, int inv_id)
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[INV_INFO] ([INV_ID],[ST_ID],[QNTY],[SUB_TOTAL],[STATUS_ID]) VALUES (@inv_id, @st_id ,@qnty, @sub, @status)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@inv_id", inv_id));
                command.Parameters.Add(new SqlParameter("@st_id", product.Stock_id));
                command.Parameters.Add(new SqlParameter("@qnty", product.Qnty));
                command.Parameters.Add(new SqlParameter("@sub", (product.Qnty * product.SalePrice)));
                command.Parameters.Add(new SqlParameter("@status", 1));

                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

        }

        private int InsertInvoice(InvoiceInfo invoice)
        {
            int inv_id = 0;
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[INVOICE] ([UD_ID],[USER_ID],[DATE],[INV_TOTAL],[STATUS_ID],[DISCOUNT]) OUTPUT Inserted.INV_ID VALUES (@cust, @cashier ,@date, @invtt, @status, @discount)";

                command = new SqlCommand(sqlQuery, conn);
                if (invoice.UserInfo == null)
                {
                    command.Parameters.Add(new SqlParameter("@cust", 1));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@cust", invoice.UserInfo.UserId));
                }
                
                command.Parameters.Add(new SqlParameter("@cashier", invoice.CashierInfo.UserId));
                command.Parameters.Add(new SqlParameter("@date", invoice.Date));
                command.Parameters.Add(new SqlParameter("@invtt", invoice.InvoiceTotal));
                command.Parameters.Add(new SqlParameter("@status", 1));
                command.Parameters.Add(new SqlParameter("@discount", invoice.Discount));

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inv_id = dataReader.GetInt32(0);
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return inv_id;
        }
    }
}
