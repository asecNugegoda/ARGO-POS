using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using argo.BL;
using argo.DL;
using System.Data.SqlClient;

namespace argo.UI.UIContent
{
    public partial class UserReg : UserControl
    {
        private User user;
        SqlDataAdapter dataAdapter;
        DataTable dataTable, dataTable2, dataTable3;
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;

        public UserReg(User user)
        {
            InitializeComponent();
            this.user = user;
            loadUserList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fname.Text == null || fname.Text == "")
            {
                MessageBox.Show("Please Fill First Name");
            }
            else if (lname.Text == null || lname.Text == "")
            {
                MessageBox.Show("Please Fill Last Name");
            }
            else if (cont.Text == null || cont.Text == "")
            {
                MessageBox.Show("Please Fill Contact");
            }
            else if (dateTime.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("Please Select Birthday");
            }
            else if (types.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Please Select User Type");
            }
            else
            {
                User user = new User();
                user.FName = fname.Text;
                user.LName = lname.Text;
                user.Contact = cont.Text;
                user.BDay = dateTime.Value.Date;
                user.Role = types.SelectedValue.ToString();
                Console.WriteLine(user.Role);
                int x = new CreateUser().SaveUser(user);
                if (x != 0)
                {
                    fname.Text = null;
                    lname.Text = null;
                    cont.Text = null;
                    dateTime.Value = dateTime.Value;
                    types.SelectedValue = 0;

                    loadUserList();
                    MessageBox.Show("User Details SuccessFully Submitted");

                    if (!types.SelectedValue.ToString().Equals("3"))
                    {
                        new CreateLogin(x.ToString(), "new").Show();
                    }

                }
                else
                {
                    MessageBox.Show("User Details Something went Wrong");
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvRow = dataGridView1.CurrentRow;
                

                if (dataGridView1.CurrentRow != null)
                {

                    connection = new DBConnection();
                    conn = connection.CreateConnection();
                    conn.Open();

                    if (!dgvRow.Cells["User_Role"].Value.ToString().Equals("3"))
                    {
                        Console.WriteLine(dgvRow.Cells["ud_id"].Value.ToString());
                        new CreateLogin(dgvRow.Cells["ud_id"].Value.ToString(), "update").Show();
                    }

                    command = new SqlCommand("AddEditUsers", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (dgvRow.Cells["UD_ID"].Value == DBNull.Value)
                    {
                        command.Parameters.AddWithValue("@ud_id", 0);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ud_id", Convert.ToInt32(dgvRow.Cells["UD_ID"].Value));
                    }

                    command.Parameters.AddWithValue("@role", Convert.ToInt32(dgvRow.Cells["User_Role"].Value == DBNull.Value ? "0" : dgvRow.Cells["User_Role"].Value.ToString()));
                    command.Parameters.AddWithValue("@fname", dgvRow.Cells["F_NAME"].Value == DBNull.Value ? "" : dgvRow.Cells["F_NAME"].Value.ToString());
                    command.Parameters.AddWithValue("@lname", dgvRow.Cells["L_NAME"].Value == DBNull.Value ? "" : dgvRow.Cells["L_NAME"].Value.ToString());
                    command.Parameters.AddWithValue("@contatc", dgvRow.Cells["CONTACT"].Value == DBNull.Value ? "" : dgvRow.Cells["CONTACT"].Value.ToString());
                    command.Parameters.AddWithValue("@bday", Convert.ToDateTime(dgvRow.Cells["BDAY"].Value == DBNull.Value ? "" : dgvRow.Cells["BDAY"].Value.ToString()));
                    command.Parameters.AddWithValue("@status", Convert.ToInt32(dgvRow.Cells["status"].Value == DBNull.Value ? "0" : dgvRow.Cells["status"].Value.ToString()));
                    
                    command.ExecuteNonQuery();
                    loadUserList();
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Loyalty loyal = null;
            if (loyal == null)
            {
                loyal = new Loyalty();
            }
            loyal.Show();
        }

        private void UserReg_Load(object sender, EventArgs e)
        {

        }

        private void loadUserList()
        {
            try
            {

                SqlDataAdapter dataAdapter = new CreateUser().LoadUserType(user);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                types.ValueMember = "ROLE_ID";
                types.DisplayMember = "USER_ROLE";
                DataRow topItem1 = dataTable.NewRow();
                topItem1[0] = 0;
                topItem1[1] = "-Select-";
                dataTable.Rows.InsertAt(topItem1, 0);
                types.DataSource = dataTable;

                SqlDataAdapter dataAdapter1 = new CreateUser().LoadUserType(user);
                dataTable2 = new DataTable();
                dataAdapter1.Fill(dataTable2);
                User_Role.ValueMember = "ROLE_ID";
                User_Role.DisplayMember = "USER_ROLE";
                DataRow topItem = dataTable2.NewRow();
                topItem[0] = 0;
                topItem[1] = "-Select-";
                dataTable2.Rows.InsertAt(topItem, 0);
                User_Role.DataSource = dataTable2;

                SqlDataAdapter adtp2 = new CreateUser().LoadStatus();
                dataTable3 = new DataTable();
                adtp2.Fill(dataTable3);
                STATUS.ValueMember = "STATUS_ID";
                STATUS.DisplayMember = "STATUS";
                DataRow topItem2 = dataTable3.NewRow();
                topItem2[0] = 0;
                topItem2[1] = "-Select-";
                dataTable3.Rows.InsertAt(topItem2, 0);
                STATUS.DataSource = dataTable3;


                dataAdapter = new CreateUser().getList(user);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
           
        }
    }
}
