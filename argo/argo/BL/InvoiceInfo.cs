using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.BL
{
    public class InvoiceInfo
    {

        DateTime date;
        decimal invoiceTotal;
        decimal discount;
        User userInfo;
        User cashierInfo;

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public decimal InvoiceTotal
        {
            get
            {
                return invoiceTotal;
            }

            set
            {
                invoiceTotal = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public User UserInfo
        {
            get
            {
                return userInfo;
            }

            set
            {
                userInfo = value;
            }
        }

        public User CashierInfo
        {
            get
            {
                return cashierInfo;
            }

            set
            {
                cashierInfo = value;
            }
        }
    }
}
