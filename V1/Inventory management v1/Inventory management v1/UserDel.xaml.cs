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
    /// Interaction logic for UserDel.xaml
    /// </summary>
    public partial class UserDel : UserControl
    {
        private string curusername;
        public UserDel(string uname)
        {
            InitializeComponent();
            curusername= uname;
            
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string userdel = UName.Text;
            string yourpass = YourPass.Text;
            int res = Loginfuncs.Verify(curusername, yourpass);
            var win = Window.GetWindow(this);
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else
            {
                DBfuncs.queryDB($"EXEC UserActions @action = 2, @username = {userdel};");
                win.Close();
            }
        }
    }
}
