using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo.DL
{
    class createProduct
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        AutoCompleteStringCollection coll;
        SqlDataAdapter dataAdapter;

        public void AddProduct(string product, string category)
        {
            try
            {
                int categry = categoryID(category);

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[PRODUCT] ([CAT_ID],[PRODUCT_NAME],[STATUS_ID]) VALUES(@category, @product, @status)";

                SqlParameter p1 = new SqlParameter("@category", categry);
                SqlParameter p2 = new SqlParameter("@product", product);
                SqlParameter p3 = new SqlParameter("@status", 1);

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);

                command.ExecuteNonQuery();
                conn.Close();
                command.Dispose();

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private int categoryID(string category)
        {
            int id = 0;
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT [CAT_ID] FROM [dbo].[CATEGORIES] WHERE [CATGORY]=@categoty";
                SqlParameter p1 = new SqlParameter("@categoty", category);
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);

                dataReader = command.ExecuteReader();
                if (dataReader.Read()) {
                    id = dataReader.GetInt32(0);
                }
                dataReader.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return id;
        }

        public AutoCompleteStringCollection listOfCategories()
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

        public SqlDataAdapter CategoriesList()
        {
            
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT * FROM [dbo].[CATEGORIES]";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return dataAdapter;
        }

        public SqlDataAdapter getStatus()
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT * FROM STATUS";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return dataAdapter;
        }


        public SqlDataAdapter ProductList()
        {

            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();


                sqlQuery = "SELECT * FROM [dbo].[PRODUCT]";
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
