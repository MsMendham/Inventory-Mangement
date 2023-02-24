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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private string uname;
        public AdminMenu(string username)
        {
            InitializeComponent();
            uname = username;   
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; // sets the result of the Dialog to true so main menu shows when this menu closes
            this.Close(); // closes menu
        }

        private void UserPressed(object sender, RoutedEventArgs e) // when user button is pressed 
        {
            string dropval = DropDown.Text; 
            switch (dropval) // switch for each different menu passing the user table
            {
                case "Add Data":
                    AddMenu add = new AddMenu(1, uname);
                    add.ShowDialog();
                    break;
                case "Delete Data":
                    DelMenu del = new DelMenu(1,uname);
                    del.ShowDialog();
                    break;
                case "Edit Data":
                    EditMenu edit = new EditMenu(1, uname);
                    edit.ShowDialog();
                    break;


            }
        }

        private void ItemPressed(object sender, RoutedEventArgs e) // when item button is pressed 
        {
            string dropval = DropDown.Text;
            switch (dropval) // switch for each different menu passing the item table
            {
                case "Add Data":
                    AddMenu add = new AddMenu(2,uname);
                    add.ShowDialog();
                    break;
                case "Delete Data":
                    DelMenu del = new DelMenu(2,uname);
                    del.ShowDialog();
                    break;
                case "Edit Data":
                    EditMenu edit = new EditMenu(2, uname);
                    edit.ShowDialog();
                    break;


            }
        }

        private void BatchPressed(object sender, RoutedEventArgs e) // when batches button is pressed 
        {
            string dropval = DropDown.Text;
            switch (dropval) // switch for each different menu passing the batches table
            {
                case "Add Data":
                    AddMenu add = new AddMenu(3, uname);
                    add.ShowDialog();
                    break;
                case "Delete Data":
                    DelMenu del = new DelMenu(3, uname);
                    del.ShowDialog();
                    break;
                case "Edit Data":
                    EditMenu edit = new EditMenu(3, uname);
                    edit.ShowDialog();
                    break;


            }
        }
    }
}
