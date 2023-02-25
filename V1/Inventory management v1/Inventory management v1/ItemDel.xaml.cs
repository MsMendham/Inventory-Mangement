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
using System.Xml.Linq;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for ItemDel.xaml
    /// </summary>
    public partial class ItemDel : UserControl
    {
        string curUser;
        public ItemDel(string uname)
        {
            InitializeComponent();
            curUser = uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string itemName = Name.Text;
            string yourPass = YourPass.Text;

            int res = Loginfuncs.Verify(curUser, yourPass);
            var window = Window.GetWindow(this);
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else
            {
                MainDbFuncs.QueryMainDB($"EXEC Itemactions @Action=2, @name = '{itemName}' ");
                window.Close();
            }
        }
    }
}
