using argo.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class CreateUser
    {

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        string sqlQuery;

        public SqlDataAdapter LoadUserType(User usr)
        {

            connection = new DBConnection();
            conn = connection.CreateConnection();
            conn.Open();
            if (usr.Role.Equals("ADMIN"))
            {
                sqlQuery = "select * from [dbo].[ROLE]";
            }
            else
            {
                sqlQuery = "select * from [dbo].[ROLE] WHERE [ROLE_ID]='3' ";
            }
            dataAdapter = new SqlDataAdapter(sqlQuery, conn);

            return dataAdapter;

        }

        public SqlDataAdapter LoadStatus()
        {

            connection = new DBConnection();
            conn = connection.CreateConnection();
            conn.Open();

            sqlQuery = "select * from [dbo].[STATUS]";

            dataAdapter = new SqlDataAdapter(sqlQuery, conn);

            return dataAdapter;

        }

        public SqlDataAdapter CustomerType() {

            connection = new DBConnection();
            conn = connection.CreateConnection();
            conn.Open();

            sqlQuery = "select * from [dbo].[ROLE] where [USER_ROLE]=@user";
            SqlParameter p1 = new SqlParameter("@user", "CUSTOMER");

            dataAdapter = new SqlDataAdapter(sqlQuery, conn);
            command.Parameters.Add(p1);
            return dataAdapter;

        }

        public int SaveUser(User usr) {
            int success = 0;
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[USER_DETAILS] (ROLE_ID,F_NAME,L_NAME,CONTACT,BDAY,STATUS_ID) OUTPUT Inserted.UD_ID VALUES(@role, @fname, @lname, @contact, @bday, @status)";
                SqlParameter p1 = new SqlParameter("@role", Convert.ToInt32(usr.Role));
                SqlParameter p2 = new SqlParameter("@fname", usr.FName);
                SqlParameter p3 = new SqlParameter("@lname", usr.LName);
                SqlParameter p4 = new SqlParameter("@contact", usr.Contact);
                SqlParameter p5 = new SqlParameter("@bday", usr.BDay.Date);
                SqlParameter p6 = new SqlParameter("@status", 1);

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.Parameters.Add(p4);
                command.Parameters.Add(p5);
                command.Parameters.Add(p6);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    success = dataReader.GetInt32(0);
                }

                
            }
            catch (Exception ee)
            {
                Console.WriteLine("Customer Saving : "+ee);
            }
            return success;
        }

        public SqlDataAdapter getList(User usr) {
            
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();
                if (usr.Role.Equals("ADMIN"))
                {
                    dataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[USER_DETAILS]", conn);
                }
                else
                {
                    dataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[USER_DETAILS] WHERE [ROLE_ID]='3' ", conn);
                }
                
                
            }
            catch (Exception ee)
            {
                Console.WriteLine("List of data : "+ee);
            }
            return dataAdapter;
        }

        public void SetLogin(User usr, string id) {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "INSERT INTO [dbo].[USER] ([UD_ID],[USER_NAME],[PASWRD],[STATUS_ID]) VALUES (@ud_id, @us_name, @paswrd, @status)";
                SqlParameter p1 = new SqlParameter("@ud_id", Convert.ToInt32(id));
                SqlParameter p2 = new SqlParameter("@us_name", usr.UserName);
                SqlParameter p3 = new SqlParameter("@paswrd", usr.Password);
                SqlParameter p4 = new SqlParameter("@status", 1);

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.Parameters.Add(p4);

                command.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        public void UpdateLogin(User usr, string id)
        {

            

            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "UPDATE [dbo].[USER] SET [USER_NAME] = @us_name, [PASWRD] = @paswrd, [STATUS_ID] = @status WHERE [UD_ID] = @ud_id";
                SqlParameter p1 = new SqlParameter("@ud_id", Convert.ToInt32(id));
                SqlParameter p2 = new SqlParameter("@us_name", usr.UserName);
                SqlParameter p3 = new SqlParameter("@paswrd", usr.Password);
                SqlParameter p4 = new SqlParameter("@status", 1);

                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.Parameters.Add(p4);

                command.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

        }


        public void checkAvailable(User user, string id)
        {
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT * FROM [dbo].[USER] WHERE [UD_ID] = @ud_id";
                SqlParameter p1 = new SqlParameter("@ud_id", Convert.ToInt32(id));
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(p1);
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    UpdateLogin(user,id);
                }
                else
                {
                    SetLogin(user, id);
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

    }
}
