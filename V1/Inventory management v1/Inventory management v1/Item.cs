using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_v1 
{
    public class Item // creates the item class
    {
        private int itemID; // defines the attributes
        private string itemName;
        private string itemType;
        public Item(int ID, string Name, string Type) // constructor method for object creation
        {
            itemID = ID;
            itemName = Name;
            itemType = Type;
        }

        public int getID() // get and setter methods for attribute access and changing 
        {
            return itemID;
        }
        public string getName()
        {
            return itemName;
        }
        public string getType()
        {
            return itemType;
        }
        public void setName(string Name)
        {
            itemName = Name;
        }
        public void setType(string Type)
        {
            itemType = Type;
        }
    }
}
