using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : UserControl
    {
        string curUser;
        public AddItem(string uname)
        {
            InitializeComponent();
            curUser = uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string type = Type.Text;
            string pass = YourPass.Text;

            int res = Loginfuncs.Verify(curUser ,pass);
            var window = Window.GetWindow(this);
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else
            {
                MainDbFuncs.QueryMainDB($"EXEC Itemactions @Action=0, @name='{name}', @type={type}"); ;
                window.Close();
            }
        }
    }
}
