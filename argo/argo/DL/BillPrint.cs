using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.DL
{
    class BillPrint
    {

        List<BL.PurchasingItem> dataList;
        ReportDocument RepDocument;

        public BillPrint(List<BL.PurchasingItem> dataList)
        {
            this.dataList = dataList;
        }

        public void makeInvoice()
        {
            RepDocument = new ReportDocument();

            try
            {

                RepDocument.Load("C:\\Users\\thilinath\\documents\\visual studio 2015\\Projects\\argo\\argo\\Invoice.rpt");

                ReportDocument reportDocument = new ReportDocument();
                ParameterField paramField = new ParameterField();
                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                //foreach (BL.PurchasingItem emp in dataList)
                //{
                //    paramDiscreteValue.Value = emp.Shift;
                //}
                //paramDiscreteValue.Value = "Day Shift";
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                RepDocument.SetDataSource(dataList);
                //crystalReportViewe.ParameterFieldInfo = paramFields;
                //crystalReportViewer1.ReportSource = RepDocument;
                //crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
        }

    }
}
