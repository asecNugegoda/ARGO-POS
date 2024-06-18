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
    public partial class StockView : UserControl
    {
        public StockView()
        {
            InitializeComponent();
            AutoComplete();
        }

        private void StockView_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new StockManage().GetStock();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            stockListView.DataSource = dt;
        }

        public void AutoComplete()
        {
            AutoCompleteStringCollection listCat = new StockManage().CategoryList();
            category.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            category.AutoCompleteSource = AutoCompleteSource.CustomSource;
            category.AutoCompleteCustomSource = listCat;

            AutoCompleteStringCollection listCat2 = new StockManage().ItemList();
            item.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            item.AutoCompleteSource = AutoCompleteSource.CustomSource;
            item.AutoCompleteCustomSource = listCat2;
        }

        public void ProductSearch() {
            
        }

        private void category_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new StockManage().CategorySearch(category.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                stockListView.DataSource = dt;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        private void item_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new StockManage().ItemCodeSearch(item.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                stockListView.DataSource = dt;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
    }
}
