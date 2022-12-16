using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_v1
{
    public class Batch // creates class
    {
        private int BatchNo;
        private object Item;
        private DateTime expiryDate;
        private int Quantity;
        public Batch(object item, int Number, DateTime Date, int Quant) // constructor method
        {
            BatchNo = Number;
            Item = item;
            expiryDate = Date;
            Quantity = Quant;
        }
        
        public int getNumber() // getter and setter methods
        {
            return BatchNo;
        }
        public object getItem()
        {
            return Item;
        }
        public DateTime getDate()
        {
            return expiryDate;

        }
        public int getQuantity()
        {
            return Quantity;
        }

        public void setItem(object item)
        {
            this.Item = item;
        }
        public void setDate(DateTime date)
        {
            this.expiryDate= date;
        }
        public void setQuantity(int quant)
        {
            this.Quantity = quant;
        }

    }
}
