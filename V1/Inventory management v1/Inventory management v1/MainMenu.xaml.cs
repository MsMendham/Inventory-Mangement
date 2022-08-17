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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu(int userID)
        {
            InitializeComponent();
            string uname = DBfuncs.getUsername(userID); // gets usersname
            int perms = DBfuncs.getPerms(userID); // gets permissions
            User.Text = uname; // changes user text block to the username
            if (perms != 1)// checks if not an admin
            {
                Admin.Visibility = Visibility.Hidden; // if so hides admin button
            }
            
           
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();// closes the window when button pressed
        }

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            LoginMenu objloginmenu = new LoginMenu();
            objloginmenu.Show();
            this.Close();
            // creates a new login menu object and closes the current window
        }

        private void AdminButton(object sender, RoutedEventArgs e)
        {
            AdminMenu objadminmenu = new AdminMenu();
            objadminmenu.Show();
            this.Hide();
            // creates a adminmenu object shows it and hides the current menu
        }

        private void WarehouseButton(object sender, RoutedEventArgs e)
        {
            WarehouseMenu objwarehouseMenu = new WarehouseMenu();
            objwarehouseMenu.Show();
            this.Hide();
            // creates a warehousemenu object shows it and hides the current menu
        }

        private void InventButton(object sender, RoutedEventArgs e)
        {
            InventoryMenu objinventorymenu = new InventoryMenu();
            objinventorymenu.Show();
            this.Hide();
            // creates a inventorymenu object shows it and hides the current menu
        }
    }
}
