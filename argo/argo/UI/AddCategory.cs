using argo.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using argo.UI.UIContent;

namespace argo.UI
{
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }
        
        public AddCategory(AddProduct addProduct)
        {
            InitializeComponent();
            this.addProduct = addProduct;
        }

        DataTable dataTable;
        Form window;
        DBConnection connection;
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        //Category category;

        string sqlQuery;
        private AddProduct addProduct;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PopulateDataGridView()
        {
            try
            {

                connection = new DBConnection();
                conn = connection.CreateConnection();
                conn.Open();

                dataAdapter = new SqlDataAdapter("SELECT * FROM [dbo].[CATEGORIES]", conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView.DataSource = dt;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loading Error : " + ex);
            }
        }

        public void comboLoad()
        {
            try
            {
                SqlDataAdapter adtp = getStatus();
                dataTable = new DataTable();
                adtp.Fill(dataTable);
                Status.ValueMember = "STATUS_ID";
                Status.DisplayMember = "STATUS";
                DataRow topItem = dataTable.NewRow();
                topItem[0] = 0;
                topItem[1] = "-Select-";
                dataTable.Rows.InsertAt(topItem, 0);
                Status.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("dataTable erro : " + ex);
            }
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

        private void AddCategory_Load(object sender, EventArgs e)
        {
            comboLoad();
            PopulateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CategoryText.Text == null || CategoryText.Text == "")
            {
                MessageBox.Show("Please Enter Category Name");
            }
            else
            {
                new CreateCategory().createNewCategory(CategoryText.Text);
                CategoryText.Text = null;
                comboLoad();
                PopulateDataGridView();
                addProduct.AutoComplete();
            }
            

            
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView.CurrentRow != null)
                {

                    connection = new DBConnection();
                    conn = connection.CreateConnection();
                    conn.Open();

                    DataGridViewRow dgvRow = dataGridView.CurrentRow;
                    command = new SqlCommand("EmployeeAddOrEdit", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (dgvRow.Cells["EMPLOYEE_ID"].Value == DBNull.Value)
                    {
                        command.Parameters.AddWithValue("@EmpID", 0);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EmpID", Convert.ToInt32(dgvRow.Cells["EMPLOYEE_ID"].Value));
                    }

                    command.Parameters.AddWithValue("@FirstName", dgvRow.Cells["firstName"].Value == DBNull.Value ? "" : dgvRow.Cells["firstName"].Value.ToString());
                    command.Parameters.AddWithValue("@LastName", dgvRow.Cells["lastName"].Value == DBNull.Value ? "" : dgvRow.Cells["lastName"].Value.ToString());
                    command.Parameters.AddWithValue("@EpfNo", dgvRow.Cells["epfNo"].Value == DBNull.Value ? "" : dgvRow.Cells["epfNo"].Value.ToString());
                    command.Parameters.AddWithValue("@shifId", Convert.ToInt32(dgvRow.Cells["shift"].Value == DBNull.Value ? "0" : dgvRow.Cells["shift"].Value.ToString()));
                    command.Parameters.AddWithValue("@statusId", Convert.ToInt32(dgvRow.Cells["status"].Value == DBNull.Value ? "0" : dgvRow.Cells["status"].Value.ToString()));
                    command.ExecuteNonQuery();

                }

            
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
    }
}
