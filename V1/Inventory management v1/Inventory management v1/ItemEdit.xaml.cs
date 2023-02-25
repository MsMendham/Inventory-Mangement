using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for ItemEdit.xaml
    /// </summary>
    public partial class ItemEdit : UserControl
    {
        string curUser;
        public ItemEdit(string uname)
        {
            InitializeComponent();
            curUser = uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string curItem = ItemName.Text;
            string newName  = NewItem.Text;
            string type = NewType.Text;
            string pass = YourPass.Text;

            int res = Loginfuncs.Verify(curUser, pass);
            var window = Window.GetWindow(this);
            if (newName == "")
            {
                newName = curItem;
            }
            if (type == "")
            {
                type = "none";
            }

            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else
            {
                MainDbFuncs.QueryMainDB($"EXEC Itemactions @Action=1, @name='{curItem}', @type='{type}', @newname='{newName}'");
                window.Close();
            }
        }
    }
}
