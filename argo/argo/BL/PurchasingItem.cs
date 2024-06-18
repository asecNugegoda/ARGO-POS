using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace argo.BL
{
    public class PurchasingItem
    {

        string po_No;
        int user_id;
        DateTime po_date;
        string itemCode;
        string item;
        decimal buyPrice;
        decimal sellPrice;
        decimal qnty;

        public PurchasingItem(string po_No, int user_id, DateTime date, string itemCode, string item, decimal buyPrice, decimal sellPrice, decimal qnty)
        {
            this.po_No = po_No;
            this.user_id = user_id;
            this.po_date = date;
            this.itemCode = itemCode;
            this.item = item;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.qnty = qnty;
        }

        public PurchasingItem()
        { }


        public string Po_No
        {
            get
            {
                return po_No;
            }

            set
            {
                po_No = value;
            }
        }

        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        
        public string ItemCode
        {
            get
            {
                return itemCode;
            }

            set
            {
                itemCode = value;
            }
        }

        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
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

        public decimal SellPrice
        {
            get
            {
                return sellPrice;
            }

            set
            {
                sellPrice = value;
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

        public DateTime Po_date
        {
            get
            {
                return po_date;
            }

            set
            {
                po_date = value;
            }
        }
    }
}
