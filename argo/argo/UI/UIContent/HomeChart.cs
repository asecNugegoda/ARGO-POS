using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using argo.DL;
using System.Data.SqlClient;

namespace argo.UI.UIContent
{
    public partial class HomeChart : UserControl
    {
        public HomeChart()
        {
            InitializeComponent();
            loadData(DateTime.Now.Date, DateTime.Now.AddDays(-7));
        }

        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;
        string sqlQuery;


        private void HomeChart_Load(object sender, EventArgs e)
        {
            loadData(DateTime.Now.Date, DateTime.Now.AddDays(-7));
            chart1.Titles.Add("Daily Sales Chart");
        }

        private void loadData(DateTime begn, DateTime end)
        {
            
            try
            {
                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                sqlQuery = "SELECT SUM([INV_TOTAL]) AS TOTAL, [DATE] FROM [dbo].[INVOICE] WHERE [DATE] BETWEEN @began AND @end group by [DATE]";
                command = new SqlCommand(sqlQuery, conn);
                command.Parameters.Add(new SqlParameter("@began", begn));
                command.Parameters.Add(new SqlParameter("@end", end));

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    chart1.Series["Sales"].Points.AddXY(dataReader.GetDateTime(1).Date.ToString(), dataReader.GetDecimal(0).ToString());
                }
                chart1.Invalidate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            loadData(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            loadData(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
        }
    }
}
