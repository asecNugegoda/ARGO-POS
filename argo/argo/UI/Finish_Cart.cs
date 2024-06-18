using argo.BL;
using argo.DL;
using argo.UI.UIContent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo.UI
{
    public partial class Finish_Cart : Form
    {
        private ListView saleList;
        private List<ProductDetail> itemList;
        private string TextValue;
        private string[] token;
        private BL.User user;
        public User Cashier;
        private InvoiceInfo invoiceInfo;
        SaleItems form;


        public Finish_Cart(ListView saleList, User usr, string text, List<ProductDetail> list, SaleItems it)
        {
            InitializeComponent();
            AutoComplete();
            this.saleList = saleList;
            this.itemList = list;
            this.Cashier = usr;
            this.user = usr;
            TextValue = text;
            netAmount.Text = text;
            totalAmount.Text = text;
            token = TextValue.Split(' ');
            form = it;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            invoiceInfo = new InvoiceInfo();
            invoiceInfo.Date = DateTime.Now;
            invoiceInfo.CashierInfo = Cashier;
            invoiceInfo.InvoiceTotal = Convert.ToDecimal(token[1]);

            if (discount.Text == null || discount.Text == "") {
                invoiceInfo.Discount = Convert.ToDecimal(0);
            }
            else
            {
                invoiceInfo.Discount = Convert.ToDecimal(discount.Text);
            }

            if (customerContact.Text == null || customerContact.Text == "")
            {
                invoiceInfo.UserInfo = null;
            }
            else
            {
                invoiceInfo.UserInfo = user;
            }

            InvoiceLoyal ss = new AddInvoice().CreateInvoice(itemList, invoiceInfo);
            if (ss.Success == 1)
            {
                new reportView(itemList, invoiceInfo, ss).Show();
                form.ClearAll();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("There is Somthing went wrong!");
            }

}

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        decimal total;
        private void discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal disc = Convert.ToDecimal(discount.Text);
                decimal price = Convert.ToDecimal(token[1]);
                decimal discPrice = (disc / 100) * price;
                total = price - discPrice;
                totalAmount.Text = "Rs. " + total + ".00";
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        private void customerContact_KeyDown(object sender, KeyEventArgs e)
        {
            int x;
            if (e.KeyCode == Keys.Enter)
            {
                
                    user = new DL.SaleProduct().getCustomerInfo(customerContact.Text);
                    custName.Text = user.FName+" "+user.LName;
                                   
            }
        }

        public void AutoComplete()
        {
            AutoCompleteStringCollection listCat = new SaleProduct().getCustomer();
            customerContact.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerContact.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerContact.AutoCompleteCustomSource = listCat;
        }

    }
}
