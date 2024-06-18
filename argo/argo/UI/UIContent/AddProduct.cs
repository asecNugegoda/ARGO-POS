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
    public partial class AddProduct : UserControl
    {

        private User user;
        SqlDataAdapter dataAdapter, dataAdapter2, dataAdapter3;
        DataTable dataTable, dataTable2, dataTable3;
        DBConnection connection;
        SqlConnection conn;
        SqlDataReader dataReader;
        SqlCommand command;

        public AddProduct(User user)
        {
            InitializeComponent();
            this.user = user;
            productLoad();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            comboLoad();
            AutoComplete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCategory cat = new AddCategory(this);
            cat.Show();
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
                    command = new SqlCommand("AddEditProduct", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (dgvRow.Cells["PRODUCT_ID"].Value == DBNull.Value)
                    {
                        command.Parameters.AddWithValue("@prod", 0);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@prod", Convert.ToInt32(dgvRow.Cells["PRODUCT_ID"].Value));
                    }

                    command.Parameters.AddWithValue("@category", dgvRow.Cells["txtCategory"].Value == DBNull.Value ? "0" : dgvRow.Cells["txtCategory"].Value.ToString());
                    command.Parameters.AddWithValue("@product", dgvRow.Cells["txtProduct"].Value == DBNull.Value ? "" : dgvRow.Cells["txtProduct"].Value.ToString());
                    command.Parameters.AddWithValue("@status", dgvRow.Cells["STATUS"].Value == DBNull.Value ? "0" : dgvRow.Cells["STATUS"].Value.ToString());
                    
                    command.ExecuteNonQuery();

                }

            }

            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        private void Item_MouseLeave(object sender, EventArgs e)
        {
            comboLoad();
            AutoComplete();
            AddProduct add = new AddProduct(user);
            add.Show();
        }

        private void categoryName_MouseLeave(object sender, EventArgs e)
        {
            comboLoad();
            AutoComplete();
            AddProduct add = new AddProduct(user);
            add.Show();
        }

        public void AutoComplete()
        {
            AutoCompleteStringCollection listCat = new createProduct().listOfCategories();
            categoryName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            categoryName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryName.AutoCompleteCustomSource = listCat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            comboLoad();
            AutoComplete();

            if (Item.Text == null || Item.Text == "")
            {
                MessageBox.Show("Please Enter Item.");
            }
            else if (categoryName.Text == null || categoryName.Text == "")
            {
                MessageBox.Show("Please Select Category.");
            }
            else
            {

                new createProduct().AddProduct(Item.Text, categoryName.Text);
                categoryName.Text = "";
                Item.Text = "";
                productLoad();
            }
        }

        private void productLoad()
        {
            try
            {
                comboLoad();
                dataAdapter2 = new createProduct().ProductList();
                dataTable2 = new DataTable();
                dataAdapter2.Fill(dataTable2);
                dataGridView.DataSource = dataTable2;
                
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        public void comboLoad()
        {
            try
            {
                dataAdapter = new createProduct().CategoriesList();
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                txtCategory.ValueMember = "CAT_ID";
                txtCategory.DisplayMember = "CATGORY";
                DataRow topItem = dataTable.NewRow();
                topItem[0] = 0;
                topItem[1] = "-Select-";
                dataTable.Rows.InsertAt(topItem, 0);
                txtCategory.DataSource = dataTable;

                dataAdapter3 = new createProduct().getStatus();
                dataTable3 = new DataTable();
                dataAdapter3.Fill(dataTable3);
                STATUS.ValueMember = "STATUS_ID";
                STATUS.DisplayMember = "STATUS";
                DataRow topItem1 = dataTable3.NewRow();
                topItem1[0] = 0;
                topItem1[1] = "-Select-";
                dataTable3.Rows.InsertAt(topItem1, 0);
                STATUS.DataSource = dataTable3;

            }
            catch (Exception ex)
            {
                Console.WriteLine("dataTable erro : " + ex);
            }
        }
    }
}
