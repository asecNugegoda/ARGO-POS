using argo.BL;
using argo.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argos.DL
{
    class PurchaseItem
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        AutoCompleteStringCollection autoComplete;

        public AutoCompleteStringCollection getItemList() {

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

        public AutoCompleteStringCollection getItemCode()
        {

            autoComplete = new AutoCompleteStringCollection();
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT [ITEM_CODE] FROM [dbo].[STOCK]";

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

        public string getItem(string code)
        {
            string Name = "";

            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT pro.[PRODUCT_NAME] FROM [dbo].[STOCK] st, [dbo].[PRODUCT] pro, [dbo].[PRICE] pri WHERE st.[ITEM_CODE] =@itemCode AND st.[PRODUCT_ID] = pro.[PRODUCT_ID] AND st.[ST_ID] = pri.[ST_ID] AND pri.[PRICE_TYPE]='BUY' AND pri.[STATUS_ID]='1' ";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@itemCode", code));

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Name = dataReader.GetString(0);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return Name;
        }



        public void AddStockItem(ArrayList list)
        {
            try
            {

                int po_id = InsertPO(list);

                foreach (PurchasingItem item in list)
                {
                    int pro_id = GetProductKey(item.Item);
                    int stock_id = InsertStock(pro_id, item.Qnty, item.ItemCode);
                    InsertPrice(stock_id, item.BuyPrice, item.SellPrice);

                    decimal sub = item.Qnty * item.BuyPrice; 

                    insertPurchInfo(po_id, stock_id, item.Qnty, item.BuyPrice, sub, 1);
                }
                
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private void insertPurchInfo(int po_id, int stock_id, decimal qnty, decimal buy, decimal sub, int v)
        {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[PO_INFO] ([PO_ID],[ST_ID],[QNTY],[BUY_PRICE],[SUB_TOTAL],[STATUS_ID]) VALUES (@po, @st ,@qn, @by, @sub, @stat)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@po", po_id));
                command.Parameters.Add(new SqlParameter("@st", stock_id));
                command.Parameters.Add(new SqlParameter("@qn", qnty));
                command.Parameters.Add(new SqlParameter("@by", buy));
                command.Parameters.Add(new SqlParameter("@sub", sub));
                command.Parameters.Add(new SqlParameter("@stat", v));

                dataReader = command.ExecuteReader();

            }
            catch (Exception ee)
            {
                Console.WriteLine("Error eka enne PO Item Add weddi : "+ee);
            }
        }

        private int InsertPO(ArrayList list)
        {
            decimal sum = 0;
            int user_id = 0;
            string purch_no = "";
            DateTime dt = DateTime.Now;
            int po_id = 0;

            try
            {

                foreach (PurchasingItem item in list)
                {

                    decimal qnt = item.Qnty;
                    decimal buy = item.BuyPrice;
                    sum += qnt * buy;
                    user_id = item.User_id;
                    purch_no = item.Po_No;
                    dt = item.Po_date;
                }


                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT [UD_ID] FROM [dbo].[USER] WHERE [USER_ID]=@us_id";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@us_id", user_id));
                dataReader = command.ExecuteReader();
                
                while (dataReader.Read())
                {
                    user_id = dataReader.GetInt32(0);
                }
                dataReader.Close();
                command.Dispose();

                sqlQuery = "INSERT INTO [dbo].[PURCHASING] ([USER_ID],[DATE],[PO_PRICE],[STATUS_ID],[PURCHASE_NO]) OUTPUT Inserted.PO_ID VALUES (@user, @date ,@price, @status, @purch_no)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@user", user_id));
                command.Parameters.Add(new SqlParameter("@date", dt));
                command.Parameters.Add(new SqlParameter("@price", sum));
                command.Parameters.Add(new SqlParameter("@status", 1));
                command.Parameters.Add(new SqlParameter("@purch_no", purch_no));

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    po_id = dataReader.GetInt32(0);
                }

                command.Dispose();
                conn.Close();


            }
            catch (Exception ee)
            {
                Console.WriteLine("Error eka PO Number eka set weddi : " + ee);
            }
            return po_id;
        }

        public int GetProductKey(string product) {

            int id = 0;
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT [PRODUCT_ID] FROM [dbo].[PRODUCT] WHERE [PRODUCT_NAME]=@product";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@product", product));

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }

                command.Dispose();
                conn.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            return id;
        }

        private int InsertStock(int pro_id, decimal qnty, string item_code)
        {
            int stock_id = 0;
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT * FROM [dbo].[STOCK] WHERE [ITEM_CODE]=@code";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@code", item_code));
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    stock_id = dataReader.GetInt32(0);

                    dataReader.Close();
                    command.Dispose();

                    sqlQuery = "UPDATE [dbo].[STOCK] SET [QNTY] = ([QNTY]+ @val) WHERE [ST_ID]= @st_id";

                    command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.Add(new SqlParameter("@val", qnty));
                    command.Parameters.Add(new SqlParameter("@st_id", stock_id));
                    command.ExecuteNonQuery();

                }
                else
                {
                    dataReader.Close();
                    command.Dispose();

                    sqlQuery = "INSERT INTO [dbo].[STOCK] ([PRODUCT_ID],[STATUS_ID],[QNTY],[ITEM_CODE]) OUTPUT Inserted.ST_ID VALUES (@product,@status,@qnt,@item_code)";

                    command = new SqlCommand(sqlQuery, conn);
                    command.Parameters.Add(new SqlParameter("@product", pro_id));
                    command.Parameters.Add(new SqlParameter("@status", 1));
                    command.Parameters.Add(new SqlParameter("@qnt", qnty));
                    command.Parameters.Add(new SqlParameter("@item_code", item_code));
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        stock_id = dataReader.GetInt32(0);
                    }
                }

                command.Dispose();
                conn.Close();
            }
            catch (Exception ee)
            { 
            
                Console.WriteLine(ee);
            }

            return stock_id;
        }

        private void InsertPrice(int st_id, decimal buy, decimal sale)
        {
            connection = new DBConnection();
            conn = connection.CreateConnection();
            conn.Open();

            sqlQuery = "SELECT * FROM [dbo].[PRICE] WHERE [ST_ID]=@code AND [PRICE_TYPE]='BUY' ";
            command = new SqlCommand(sqlQuery, conn);
            command.Parameters.Add(new SqlParameter("@code", st_id));
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                dataReader.Close();
                command.Dispose();

                sqlQuery = "UPDATE [dbo].[PRICE] SET [PRICE] = @val WHERE [ST_ID]= @st_id AND [PRICE_TYPE]='BUY' ";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@val", buy));
                command.Parameters.Add(new SqlParameter("@st_id", st_id));
                command.ExecuteNonQuery();

                dataReader.Close();
                command.Dispose();

                sqlQuery = "UPDATE [dbo].[PRICE] SET [PRICE] = @val WHERE [ST_ID]= @st_id AND [PRICE_TYPE]='SELL' ";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@val", sale));
                command.Parameters.Add(new SqlParameter("@st_id", st_id));
                command.ExecuteNonQuery();

            }
            else
            {
                dataReader.Close();
                command.Dispose();

                sqlQuery = "INSERT INTO [dbo].[PRICE] ([ST_ID],[PRICE],[STATUS_ID],[PRICE_TYPE]) VALUES (@st_id, @price, @status, @type)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@st_id", st_id));
                command.Parameters.Add(new SqlParameter("@price", buy));
                command.Parameters.Add(new SqlParameter("@status", 1));
                command.Parameters.Add(new SqlParameter("@type", "BUY"));
                dataReader = command.ExecuteReader();

                dataReader.Close();
                command.Dispose();

                sqlQuery = "INSERT INTO [dbo].[PRICE] ([ST_ID],[PRICE],[STATUS_ID],[PRICE_TYPE]) VALUES (@st_id, @price, @status, @type)";

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@st_id", st_id));
                command.Parameters.Add(new SqlParameter("@price", sale));
                command.Parameters.Add(new SqlParameter("@status", 1));
                command.Parameters.Add(new SqlParameter("@type", "SELL"));
                dataReader = command.ExecuteReader();

            }

            command.Dispose();
            conn.Close();
        }



    }
}
