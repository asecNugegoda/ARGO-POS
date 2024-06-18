using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using argo.DL;
using System.Threading;

namespace argo.UI.UIContent
{
    public partial class Transaction : UserControl
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            GetInvoice(DateTime.Now.Date, DateTime.Now.Date);
            GetPOs(DateTime.Now.Date, DateTime.Now.Date);
        }

        public void GetInvoice(DateTime began, DateTime end) {

            SqlDataAdapter adapter = new InvoiceTransaction().getInvoices(began, end);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            InvoiceGridView.DataSource = dt;
            decimal tota = new InvoiceTransaction().getInvoiceTotal(began, end);
            inv_total.Text = "Rs. " + tota;
        }

        public void GetPOs(DateTime began, DateTime end)
        {

            SqlDataAdapter adapter = new InvoiceTransaction().getPOs(began, end);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            POSGridView.DataSource = dt;
            decimal tota = new InvoiceTransaction().getPOTotal(began, end);
            po_tot.Text = "Rs. " + tota;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            GetInvoice(inv_from.Value.Date, inv_to.Value.Date);
        }

        private void inv_from_ValueChanged(object sender, EventArgs e)
        {
            GetInvoice(inv_from.Value.Date, inv_to.Value.Date);
        }

        private void po_from_ValueChanged(object sender, EventArgs e)
        {
            GetPOs(po_from.Value.Date, po_to.Value.Date);
        }

        private void po_to_ValueChanged(object sender, EventArgs e)
        {
            GetPOs(po_from.Value.Date, po_to.Value.Date);
        }

        private void inv_total_Click(object sender, EventArgs e)
        {

        }
    }
}
