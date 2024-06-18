using argo.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class loginCheck
    {
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;
        User user;

        public User loginValidation(User usr)
        {

            try
            {
                int ud_id = 0;
                user = new User();
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();
                sqlQuery = "SELECT usr.USER_ID ,usr.USER_NAME, usr.PASWRD, usr.STATUS_ID, detail.F_NAME, detail.L_NAME, detail.CONTACT, detail.BDAY, role.USER_ROLE FROM [dbo].[USER] usr, [dbo].[USER_DETAILS] detail, [dbo].[ROLE] role WHERE usr.USER_NAME=@userName AND usr.PASWRD=@password" +
                    " and usr.UD_ID = detail.UD_ID and role.ROLE_ID = detail.ROLE_ID";
                command = new SqlCommand(sqlQuery, conn);

                command.Parameters.Add(new SqlParameter("@userName", usr.UserName));
                command.Parameters.Add(new SqlParameter("@password", usr.Password));
                
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (!dataReader["USER_ROLE"].ToString().Equals("CUSTOMER"))
                    {

                        user.UserId = Convert.ToInt32(dataReader["USER_ID"]);
                        user.UserName = dataReader["USER_NAME"].ToString();
                        user.Password = dataReader["PASWRD"].ToString();
                        user.FName = dataReader["F_NAME"].ToString();
                        user.LName = dataReader["L_NAME"].ToString();
                        user.Contact = dataReader["CONTACT"].ToString();
                        //if (dataReader["BDAY"] != null) {
                        //    usr.BDay = Convert.ToDateTime(dataReader["BDAY"]);
                        //}
                        user.Role = dataReader["USER_ROLE"].ToString();
                        user.Status = Convert.ToInt32(dataReader["STATUS_ID"]);

                        user.Flag = true;

                    }
                    else
                    {
                        user.Flag = false;
                    }
                    
                }
                else
                {
                    user.Flag = false;
                }
           
                conn.Close();
                command.Dispose();
                dataReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Login check error: " + e);
            }

            return user;
        }

    }
}
