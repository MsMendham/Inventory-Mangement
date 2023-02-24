using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : UserControl
    {
        private string curUser;
        public EditUser(string uname)
        {
            InitializeComponent();
            curUser= uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string edituser = User.Text;
            string newPass = NUpass.Text;
            string yourpass = YourPass.Text;
            string hashed = Loginfuncs.Hash(newPass);
            var win = Window.GetWindow(this);

            int res = Loginfuncs.Verify(curUser, yourpass); // checks password
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else // if password okay executes query
            {
                DBfuncs.queryDB($"EXEC UserActions @action = 1, @username = {edituser}, @pass = '{hashed}';");
                win.Close();
            }
        }
    }
}
