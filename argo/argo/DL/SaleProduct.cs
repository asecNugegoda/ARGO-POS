using argo.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo.DL
{
    class SaleProduct
    {
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        AutoCompleteStringCollection coll;
        SqlDataAdapter dataAdapter;
        ProductDetail productDetail;
        User BillUser;


        public AutoCompleteStringCollection getProductList()
        {

            coll = new AutoCompleteStringCollection();
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT * FROM [dbo].[STOCK]";
                command = new SqlCommand(sqlQuery, conn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    coll.Add(dataReader.GetString(4));
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return coll;

        }

        public AutoCompleteStringCollection getCustomer()
        {
            coll = new AutoCompleteStringCollection();
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT * FROM [dbo].[USER_DETAILS] where [STATUS_ID] = '1' ";
                command = new SqlCommand(sqlQuery, conn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    coll.Add(dataReader.GetString(4));
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return coll;
        }

        public ProductDetail getProductInfo(string code)
        {

            productDetail = new ProductDetail();

            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT pro.[PRODUCT_NAME], st.[QNTY], pri.[PRICE], st.[ST_ID] FROM [dbo].[STOCK] st, [dbo].[PRODUCT] pro, [dbo].[PRICE] pri WHERE st.[ITEM_CODE] = @code AND st.[PRODUCT_ID] = pro.[PRODUCT_ID] AND pro.[STATUS_ID] = '1' AND st.[ST_ID] = pri.[ST_ID] AND pri.[STATUS_ID] = '1' AND pri.[PRICE_TYPE] = 'SELL' ";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@code", code));

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    productDetail.ProductName = dataReader.GetString(0);
                    productDetail.Qnty = dataReader.GetDecimal(1);
                    productDetail.SalePrice = dataReader.GetDecimal(2);
                    productDetail.Stock_id = dataReader.GetInt32(3);
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return productDetail;

        }


        public User getCustomerInfo(string code)
        {

            BillUser = new User();

            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT [UD_ID],[F_NAME],[L_NAME] FROM [dbo].[USER_DETAILS] WHERE [CONTACT]=@cont";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@cont", code));

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    BillUser.UserId = dataReader.GetInt32(0);
                    BillUser.FName = dataReader.GetString(1);
                    BillUser.LName = dataReader.GetString(2);
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return BillUser;

        }

    }
}
