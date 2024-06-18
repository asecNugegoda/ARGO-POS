using argo.BL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class reportView : Form
    {
        public reportView(List<ProductDetail> dataList, InvoiceInfo info, InvoiceLoyal inv)
        {
            InitializeComponent();
            this.dataList = dataList;
            this.info = info;
            this.inv_no = inv;
            makeInvoice();
        }

        List<ProductDetail> dataList;
        ReportDocument RepDocument;
        InvoiceInfo info;
        InvoiceLoyal inv_no;

        public void makeInvoice()
        {
            RepDocument = new ReportDocument();

            try
            {

                RepDocument.Load("C:\\Users\\thilinath\\documents\\visual studio 2015\\Projects\\argo\\argo\\Invoice.rpt");

                ReportDocument reportDocument = new ReportDocument();
                ParameterField paramField = new ParameterField();
                ParameterFields paramFields = new ParameterFields();

                //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                //paramField.Name = "eBillNo";
                //paramDiscreteValue.Value = inv_no;

                //paramField.CurrentValues.Add(paramDiscreteValue);
                //paramFields.Add(paramField);

                RepDocument.SetDataSource(dataList);

                RepDocument.SetParameterValue("eBillNo", inv_no.InvoiceNo);
                RepDocument.SetParameterValue("eCashier", info.CashierInfo.FName);
                RepDocument.SetParameterValue("eDate", info.Date);
                if (info.UserInfo != null)
                {
                    RepDocument.SetParameterValue("eCust", info.UserInfo.FName + " " + info.UserInfo.LName);
                }
                else
                {
                    RepDocument.SetParameterValue("eCust", "");
                }

                RepDocument.SetParameterValue("eNetTotal", info.InvoiceTotal);
                if (info.Discount != 0)
                {
                    RepDocument.SetParameterValue("eDiscount", info.Discount);
                }
                else
                {
                    RepDocument.SetParameterValue("eDiscount", 0);
                }
                
                RepDocument.SetParameterValue("eTotal", info.InvoiceTotal);
                if (inv_no.Loyal != 0)
                {
                    RepDocument.SetParameterValue("eLoyal", inv_no.Loyal);
                }
                else
                {
                    RepDocument.SetParameterValue("eLoyal", inv_no.Loyal);
                }

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.ReportSource = RepDocument;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
        }
    }
}
