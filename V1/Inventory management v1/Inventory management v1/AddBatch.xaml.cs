using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for AddBatch.xaml
    /// </summary>
    public partial class AddBatch : UserControl
    {
        string curUser;
        public AddBatch(string Uname)
        {
            InitializeComponent();
            curUser = Uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string item = Item.Text;
            string date = Date.Text;
            string quant = Quant.Text;
            string pass = YourPass.Text;
            DateTime dateTime;
            int intQuant;
            var window = Window.GetWindow(this);

            int itemid = MainDbFuncs.getOneItem(item);

            int res = Loginfuncs.Verify(curUser, pass);
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else if (!DateTime.TryParse(date, out dateTime))
            {
                topText.Text = "invalid date";
            }
            else if (!int.TryParse(quant, out intQuant))
            {
                topText.Text = "invalidQuantity";
            }
            else
            {
                
                MainDbFuncs.QueryMainDB($"EXEC Batchactions @Action=0, @item={itemid}, @quant={intQuant}, @date= '{dateTime}' ;");
                window.Close();
            }
        }
    }
}
