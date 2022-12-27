using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for InventoryMenu.xaml
    /// </summary>
    public partial class InventoryMenu : Window
    {
        private List<Item> items = new List<Item>();// defines lists that will hold the actual objects and lists that will hold the string versions that will be displayed
        private List<Batch> batches = new List<Batch>();
        private List<string> itemsplit = new List<string>();
        private List<string> batchsplit = new List<string>();
        int bacthoritem; // defines a variable to hold a value that tells us which data is being shown to the user
        public InventoryMenu(string name)
        {
            InitializeComponent();
            Username.Text = name;// sets the username textblock to the name passed when creating the object
            items = MainDbFuncs.getItems(); // gets the items and batches from the database and puts them into their respective lists
            batches = MainDbFuncs.getBatch(items);



            batchsplit = batchsplitting(batches);

            itemsplit = itemsplitting(items);

            LBox.ItemsSource = batchsplit; // sets the listbox source to the batchsplit list
            bacthoritem = 1;// sets the value for tracking which data is being shown to 1 for batches
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close(); // closes the window
        }

        private void ItemPress(object sender, RoutedEventArgs e)
        {
            LBox.ItemsSource = itemsplit; // sets the source to itemsplit and the traker to 0
            bacthoritem = 0;
            item1.Content = "Name";
            item2.Content = "Type";
            item3.Content = "ID";
            item4.Content = "";

        }

        private void Batchpressed(object sender, RoutedEventArgs e)
        {
            LBox.ItemsSource= batchsplit; // sets the source to batchsplit and the traker to 1
            bacthoritem = 1;
            item1.Content = "Batch Number";
            item2.Content = "Item";
            item3.Content = "Expiry Date";
            item4.Content = "Quantity";
        }

        private void searchbuttonpressed(object sender, RoutedEventArgs e)
        {
            
            List<string> Final = new List<string>(); // creates a string list for the searched values to go in
            string searchres = Search.Text.ToLower(); // gets the text from the textbox and makes it lowercase
            searchres = searchres.Replace(" ", "");
            if (searchres != "")
            {
                if (bacthoritem == 0) // if the items data is showing search the items list
                {
                    List<Item> result = items.FindAll(c => c.getName().ToLower() == searchres); // searches the list by name
                    List<Item> result2 = items.FindAll(c => c.getType().ToLower() == searchres); // searches the list by type
                    List<Item> finalres = result.Concat(result2).ToList(); // concatinates the 2 lists together
                    Final = itemsplitting(finalres);

                }
                else if (bacthoritem == 1) // if the batch data is showings search the batch list 
                {
                    List<Batch> result = batches.FindAll(c => c.getNumber().ToString() == searchres); // searches the list by id 
                    List<Batch> result2 = batches.FindAll(c => c.getItem().getName().ToLower() == searchres);// searches the list by item
                    List<Batch> finalres = result.Concat(result2).ToList(); // concatinates the lists
                    Final = batchsplitting(finalres);
                }

                if (Final.Count == 0)// checks if nothing is found 
                {
                    Final.Add("No result found"); // if so says so
                }

                LBox.ItemsSource = Final;// sets the source to the final list
            }
        }

        private void sortchanges(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private List<string> itemsplitting(List<Item> list)
        {
            List<string> outlist = new List<string>();
            foreach (Item j in list) // loops through each item in the list getting the data out and putting it into a string that can be displayed in the listbox
            {
                string itemname = j.getName();
                string id = j.getID().ToString();
                string type = j.getType();

                outlist.Add("ID: " + id + " Name: " + itemname + " Type: " + type);
            }
            return outlist;
        }
        private List<string> batchsplitting(List<Batch> list)
        {
            List<string> outlist = new List<string>();
            foreach (Batch i in list)// makes the list of objects a list of strings 
            {
                int id = i.getNumber();
                Item itemobj = i.getItem();
                string itemname = itemobj.getName();
                DateTime date = i.getDate();
                int quantity = i.getQuantity();

                outlist.Add("ID: " + id.ToString() + " Item: " + itemname + " Expiry Date: " + date.ToShortDateString() + " Quantity: " + quantity.ToString());

            }
            return outlist;
        }

        private void sortboxchange(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void combodropcls(object sender, EventArgs e)
        {
            string combovalue = sortbox.Text;
            List<string> Final = new List<string>();
            if (bacthoritem == 0)// items
            {
                List<Item> sorteditems = items;
                if (combovalue == "Name")
                {
                    sorteditems.Sort((x, y) => string.Compare(x.getName().ToLower(), y.getName().ToLower()));
                }
                else if (combovalue == "Type")
                {
                    sorteditems.Sort((x, y) => string.Compare(x.getType().ToLower(), y.getType().ToLower()));
                }
                else if (combovalue == "ID")
                {
                    sorteditems.Sort((x, y) => x.getID().CompareTo(y.getID()));
                }
                Final = itemsplitting(sorteditems);

            }
            else if (bacthoritem == 1)// batches
            {
                List<Batch> sortedbatches = batches;
                if (combovalue == "Batch Number")
                {
                    sortedbatches.Sort((x, y) => x.getNumber().CompareTo(y.getNumber()));
                }
                else if (combovalue == "Item")
                {
                    sortedbatches.Sort((x, y) => string.Compare(x.getItem().getName().ToLower(), y.getItem().getName().ToLower()));
                }
                else if (combovalue == "Expiry Date")
                {
                    sortedbatches.Sort((x, y) => DateTime.Compare(x.getDate(), y.getDate()));
                }
                else if (combovalue == "Quantity")
                {
                    sortedbatches.Sort((x, y) => x.getQuantity().CompareTo(y.getQuantity()));
                }
                Final = batchsplitting(sortedbatches);
            }
            LBox.ItemsSource = Final;
        }
    }
}
