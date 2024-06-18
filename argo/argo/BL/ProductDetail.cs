using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.BL
{
    public class ProductDetail
    {
        private int stock_id;
        private string productName;
        private string productCode;
        private decimal buyPrice;
        private decimal salePrice;
        private decimal qnty;

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public string ProductCode
        {
            get
            {
                return productCode;
            }

            set
            {
                productCode = value;
            }
        }

        public decimal BuyPrice
        {
            get
            {
                return buyPrice;
            }

            set
            {
                buyPrice = value;
            }
        }

        public decimal SalePrice
        {
            get
            {
                return salePrice;
            }

            set
            {
                salePrice = value;
            }
        }

        public decimal Qnty
        {
            get
            {
                return qnty;
            }

            set
            {
                qnty = value;
            }
        }

        public int Stock_id
        {
            get
            {
                return stock_id;
            }

            set
            {
                stock_id = value;
            }
        }
    }
}
