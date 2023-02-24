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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for addUsers.xaml
    /// </summary>
    public partial class addUsers : UserControl
    {
        private string curusername;
        public addUsers(string username)
        {
            InitializeComponent();
            curusername = username;

        }

        private void EnterClicked(object sender, RoutedEventArgs e)
        {
            string newUser = UName.Text;
            string newPword = PWord.Text;
            int newPerms = Convert.ToInt32(Perms.Text);
            string yourpass  = YourPass.Text;
            var window = Window.GetWindow(this);
            string hashed = Loginfuncs.Hash(newPword);

            int res = Loginfuncs.Verify(curusername, yourpass);
            if (res == -1) {
                topText.Text = "Wrong Password";
            }
            else if(newPerms != 0 && newPerms != 1) {
                topText.Text = "invalid permissions";
            }
            else
            {
                DBfuncs.queryDB($"EXEC UserActions @action = {0}, @Username = {newUser},@pass = '{hashed}', @perms = {newPerms}"); ;
                window.Close();
            }
        }
    }
}
