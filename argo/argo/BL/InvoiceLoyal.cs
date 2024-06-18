using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.BL
{
    public class InvoiceLoyal
    {

        int invoiceNo;
        decimal loyal;
        int success;

        public int InvoiceNo
        {
            get
            {
                return invoiceNo;
            }

            set
            {
                invoiceNo = value;
            }
        }

        public decimal Loyal
        {
            get
            {
                return loyal;
            }

            set
            {
                loyal = value;
            }
        }

        public int Success
        {
            get
            {
                return success;
            }

            set
            {
                success = value;
            }
        }
    }
}
