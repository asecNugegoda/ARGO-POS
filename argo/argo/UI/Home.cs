using argo.BL;
using argo.UI.UIContent;
using System;
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
    public partial class login : Form
    {
        Form frm;
        User user;

        public login(Form form, User usr)
        {
            InitializeComponent();
            timer1.Start();
            this.frm = form; 
            this.user = usr;
            userName.Text = user.FName + " " + user.LName;
            role.Text = user.Role;
        }

        

        private void Home_Load(object sender, EventArgs e)
        {
            moveSidePanel(homeBtn);
            HomeChart sale = new HomeChart();
            AddControlstoPanels(sale);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            clockLabel.Text = dt.ToString("HH:MM:ss");
        }

        public void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            moveSidePanel(homeBtn);
            HomeChart sale = new HomeChart();
            AddControlstoPanels(sale);
        }

        private void saleBtn_Click(object sender, EventArgs e)
        {
            moveSidePanel(saleBtn);
            SaleItems sale = new SaleItems(user);
            AddControlstoPanels(sale);
        }

        private void puchaseBtn_Click(object sender, EventArgs e)
        {
            if (user.Role.Equals("ADMIN"))
            {
                moveSidePanel(puchaseBtn);
                Purchasing pur = new Purchasing(user);
                AddControlstoPanels(pur);
            }
            else
            {
                MessageBox.Show("You Havn't Permission, Please Contact Admin");
            }

            //if (!panelControl.Controls.Contains(Purchasing.Instance))
            //{
            //    panelControl.Controls.Add(Purchasing.Instance);
            //    Purchasing.Instance.Dock = DockStyle.Fill;
            //    Purchasing.Instance.BringToFront();
            //}
            //else
            //{
            //    Purchasing.Instance.BringToFront();
            //}
        }

        private void expenseBtn_Click(object sender, EventArgs e)
        {
            if (user.Role.Equals("ADMIN"))
            {
                moveSidePanel(expenseBtn);
                AddProduct product = new AddProduct(user);
                AddControlstoPanels(product);
            }
            else
            {
                MessageBox.Show("You Havn't Permission, Please Contact Admin");
            }
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            moveSidePanel(userBtn);
            UserReg reg = new UserReg(user);
            AddControlstoPanels(reg);
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            moveSidePanel(reportBtn);
            StockView st_view = new StockView();
            AddControlstoPanels(st_view);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void AddControlstoPanels(Control c)
        {
            try
            {
                c.Dock = DockStyle.Fill;
                panelControl.Controls.Clear();
                panelControl.Controls.Add(c);

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Role.Equals("ADMIN"))
            {
                moveSidePanel(button1);
                Transaction trans = new Transaction();
                AddControlstoPanels(trans);
            }
            else
            {
                MessageBox.Show("You Havn't Permission, Please Contact Admin");
            }
        }
    }
}
