using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using argos.DL;
using argo.BL;
using System.Collections;

namespace argo.UI
{
    public partial class Purchasing : UserControl
    {
        User usr;
        public Purchasing(User usr)
        {
            InitializeComponent();
            itemList = new ArrayList();
            this.usr = usr;
        }
        public Purchasing() {
            InitializeComponent();
            //itemList = new ArrayList();
            
        }
       
        ListViewItem listView;
        ArrayList itemList;
        PurchasingItem pur_item;
        private static decimal sum = 0;
        //private static Purchasing _instance;

        //public static Purchasing Instance

        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new Purchasing();
        //        }
        //        return _instance;
        //    }
        //}

        private void Purchasing_Load(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection collection = new PurchaseItem().getItemList();
                ItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ItemName.AutoCompleteCustomSource = collection;

                AutoCompleteStringCollection collection2 = new PurchaseItem().getItemCode();
                ItemCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ItemCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ItemCode.AutoCompleteCustomSource = collection2;
            }
            catch (Exception ee)
            {
                Console.WriteLine("digti bidis");
                Console.WriteLine(ee);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!purchasingList.Size.Equals(0)) {
                PONo.ReadOnly = true;
            }

            if (PONo.Text == null || PONo.Text == "")
            {
                MessageBox.Show("Please Enter PO Number!");
            }
            else if (ItemCode.Text == null || ItemCode.Text == "")
            {
                MessageBox.Show("Please Enter Item Code!");
            }
            else if (ItemName.Text == null || ItemName.Text == "")
            {
                MessageBox.Show("Please Enter Item Name!");
            }
            else if (BuyPrice.Text == null || BuyPrice.Text == "")
            {
                MessageBox.Show("Please Enter Buy Price!");
            }
            else if (MRP.Text == null || MRP.Text == "")
            {
                MessageBox.Show("Please Enter Sale Price!");
            }
            else if (Qnty.Text == null || Qnty.Text == "")
            {
                MessageBox.Show("Please Enter Quantity!");
            }
            else
            {

                string poNo = PONo.Text;
                string itemCode = ItemCode.Text;
                string item = ItemName.Text;
                string buy_price = BuyPrice.Text;
                string sale_price = MRP.Text;
                string qnty = Qnty.Text;

                try
                {

                    pur_item = new PurchasingItem();
                    pur_item.Po_No = poNo;
                    pur_item.User_id = usr.UserId;
                    pur_item.Po_date = DateTime.Now;
                    pur_item.ItemCode = itemCode;
                    pur_item.Item = item;
                    pur_item.BuyPrice = Convert.ToDecimal(buy_price);
                    pur_item.SellPrice = Convert.ToDecimal(sale_price);
                    pur_item.Qnty = Convert.ToDecimal(qnty);
                    itemList.Add(pur_item);

                    string[] arr = new string[5];
                    arr[0] = itemCode;
                    arr[1] = item;
                    arr[2] = buy_price;
                    arr[3] = sale_price;
                    arr[4] = qnty;
                    listView = new ListViewItem(arr);
                    purchasingList.Items.Add(listView);

                    CalcuateTotal(pur_item.BuyPrice, pur_item.Qnty);
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee);
                }

                //PONo.Text = null;
                ItemCode.Text = null;
                ItemName.Text = null;
                BuyPrice.Text = null;
                MRP.Text = null;
                Qnty.Text = null;
            }
        }

        private void CalcuateTotal(decimal buyPrice, decimal qnt)
        {
            
            try
            {
                decimal cal = buyPrice* qnt;
                sum += cal;
                if (sum != 0) {
                    total.Text = "Rs. " + sum + ".00";
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new PurchaseItem().AddStockItem(itemList);
            purchasingList.Items.Clear();
            total.Text = "Rs. 0000.00";
            PONo.ReadOnly = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            itemList.Clear();
            purchasingList.Items.Clear();
        }

        private void ItemCode_TextChanged(object sender, EventArgs e)
        {
            string nn = new PurchaseItem().getItem(ItemCode.Text);
            ItemName.Text = nn;
        }
    }
}
