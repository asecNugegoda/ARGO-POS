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


namespace argo.UI.UIContent
{
    public partial class SaleItems : UserControl
    {
        private User user;
        static decimal avalQnty = 0;
        private ProductDetail product;
        List<ProductDetail> itemList;
        ListViewItem listView;
        private static decimal sum = 0;
        private int stock_id;

        public SaleItems(User user)
        {
            InitializeComponent();
            AutoComplete();
            this.user = user;
            itemList = new List<ProductDetail>();
        }

        public void AutoComplete()
        {
            AutoCompleteStringCollection listCat = new SaleProduct().getProductList();
            itemCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            itemCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemCode.AutoCompleteCustomSource = listCat;
        }

        private void itemCode_KeyDown(object sender, KeyEventArgs e)
        {
            int x;
            if (e.KeyCode == Keys.Enter)
            {
                if (itemCode.Text == null || itemCode.Text == "")
                {

                    MessageBox.Show("Please Enter valid Item Code");
                }
                else
                {
                    BL.ProductDetail product = new DL.SaleProduct().getProductInfo(itemCode.Text);

                    itemName.Text = product.ProductName;
                    price.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:c}", product.SalePrice.ToString());    
                    avalQnty = product.Qnty;
                    stock_id = product.Stock_id;
                    if (avalQnty == 0)
                    {
                        MessageBox.Show("Stock Not Available, Its 0 Now.");
                        itemCode.Text = null;
                        itemName.Text = null;
                        price.Text = null;
                    }
                    else if (avalQnty < 5)
                    {
                        MessageBox.Show("Stock Running Low, Its Less Than 5 Quantity.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (itemCode.Text == null || itemCode.Text == "")
            {
                MessageBox.Show("Please Enter Item Code!");
            }
            else if (qnty.Text == null || qnty.Text == "")
            {
                MessageBox.Show("Please Enter Quantity");
            }
            else if (Convert.ToDecimal(qnty.Text) > avalQnty)
            {
                MessageBox.Show("Available Quantity is : "+avalQnty);
            }
            else
            {

                product = new ProductDetail();
                product.ProductCode = itemCode.Text;
                product.ProductName = itemName.Text;
                product.Qnty = Convert.ToDecimal(qnty.Text);
                product.SalePrice = Convert.ToDecimal(price.Text);
                product.Stock_id = stock_id;
                product.BuyPrice = (product.Qnty * product.SalePrice);
                itemList.Add(product);

                string[] arr = new string[4];
                arr[3] = itemCode.Text;
                arr[0] = itemName.Text;
                arr[1] = qnty.Text;
                decimal sub = product.Qnty*product.SalePrice;
                arr[2] = sub.ToString();
                listView = new ListViewItem(arr);
                saleList.Items.Add(listView);
                CalcuateTotal(sub);

                itemCode.Text = null;
                itemName.Text = null;
                price.Text = null;
                qnty.Text = null;

            }
            
        }



        private void CalcuateTotal(decimal Price)
        {

            try
            {
                sum += Price;
                if (sum != 0)
                {
                    total.Text = "Rs. " + sum + ".00";
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }

        }

        Finish_Cart fn_cart;
        private void button7_Click(object sender, EventArgs e)
        {
            fn_cart = new Finish_Cart(saleList, user, total.Text, itemList, this);
            fn_cart.Show();
        }

        public void ClearAll() {
            saleList.Items.Clear();
            itemList.Clear();
            total.Text = "Rs. 0000.00";
            sum = 0;
        }
    }
}
