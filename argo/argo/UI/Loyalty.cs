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

namespace argo.UI
{
    public partial class Loyalty : Form
    {
        SqlDataAdapter dataAdapter;

        public Loyalty()
        {
            InitializeComponent();
        }

        private void Loyalty_Load(object sender, EventArgs e)
        {
            try
            {

                dataAdapter = new LoyaltyList().ListLoyal();
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                LoyatyGridView.DataSource = dt;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
