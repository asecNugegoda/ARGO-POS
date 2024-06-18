using argo.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo.DL
{
    class StockManage
    {

        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        ProductDetail productDetail;
        AutoCompleteStringCollection coll;

        public SqlDataAdapter GetStock()
        {
            
            try
            {

                productDetail = new ProductDetail();
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT cate.[CATGORY], st.[ITEM_CODE], pro.[PRODUCT_NAME], st.[QNTY], pri.[PRICE] FROM [dbo].[STOCK] st, [dbo].[PRODUCT] pro, [dbo].[PRICE] pri, [dbo].[CATEGORIES] cate WHERE st.[PRODUCT_ID] = pro.[PRODUCT_ID] AND pro.[STATUS_ID] = '1' AND st.[ST_ID] = pri.[ST_ID] AND pri.[STATUS_ID] = '1' AND pri.[PRICE_TYPE] = 'SELL' AND cate.[CAT_ID] = pro.[CAT_ID]";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);    

            }
            catch (Exception ee)
            {
                Console.WriteLine();
            }
            return dataAdapter;
        }

        public AutoCompleteStringCollection CategoryList()
        {
            coll = new AutoCompleteStringCollection();
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT * FROM [dbo].[CATEGORIES]";
                command = new SqlCommand(sqlQuery, conn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    coll.Add(dataReader.GetString(1));
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return coll;
        }

        public AutoCompleteStringCollection ItemList()
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


        public SqlDataAdapter CategorySearch(string cate)
        {

            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT cate.[CATGORY], st.[ITEM_CODE], pro.[PRODUCT_NAME], st.[QNTY], pri.[PRICE] FROM [dbo].[STOCK] st, [dbo].[PRODUCT] pro, [dbo].[PRICE] pri, [dbo].[CATEGORIES] cate WHERE cate.[CATGORY] LIKE @cat_name AND st.[PRODUCT_ID] = pro.[PRODUCT_ID] AND pro.[STATUS_ID] = '1' AND st.[ST_ID] = pri.[ST_ID] AND pri.[STATUS_ID] = '1' AND pri.[PRICE_TYPE] = 'SELL' AND cate.[CAT_ID] = pro.[CAT_ID]";

                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@cat_name", "%" + cate + "%");


            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return dataAdapter;
        }

        public SqlDataAdapter ItemCodeSearch(string code)
        {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT cate.[CATGORY], st.[ITEM_CODE], pro.[PRODUCT_NAME], st.[QNTY], pri.[PRICE] FROM [dbo].[STOCK] st, [dbo].[PRODUCT] pro, [dbo].[PRICE] pri, [dbo].[CATEGORIES] cate WHERE st.[ITEM_CODE] LIKE @item_code AND st.[PRODUCT_ID] = pro.[PRODUCT_ID] AND pro.[STATUS_ID] = '1' AND st.[ST_ID] = pri.[ST_ID] AND pri.[STATUS_ID] = '1' AND pri.[PRICE_TYPE] = 'SELL' AND cate.[CAT_ID] = pro.[CAT_ID]";

                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@item_code", "%" + code + "%");


            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return dataAdapter;
        }

    }
}
