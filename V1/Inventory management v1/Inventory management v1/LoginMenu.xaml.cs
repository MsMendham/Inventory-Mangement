using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for LoginMenu.xaml
    /// </summary>
    public partial class LoginMenu : Window
    {
        public LoginMenu()
        {
            InitializeComponent();
            string frameworkDescription = RuntimeInformation.FrameworkDescription;
            Console.WriteLine(frameworkDescription);
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            

            string uname = Username.Text;
            string pword = Password.Text;
            // get the data from the windowz
            
            if (uname!="" || pword != "")
            {
                int verifyResult = Loginfuncs.Verify(uname, pword);
                // get the result of verifying the username and password
                switch (verifyResult)
                {
                    case 0:
                        Alertbox.Text = "No user Exists";// if its 0 say no user exist
                        break;
                    case -1:
                        Alertbox.Text = "Incorrect password";// if its -1 say incorrect password
                        break;
                    default:
                        MainMenu objMainMenu = new MainMenu(verifyResult); // if its any other number create a object of the main menu passing the user id

                        objMainMenu.Show();// then show the new menu
                        this.Close();// then close the current menu 
                        break;
                }
            }
            

        }
        
    }
}
