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
    /// Interaction logic for EditBatches.xaml
    /// </summary>
    public partial class EditBatches : UserControl
    {
        string curUser;
        public EditBatches(string uname)
        {
            InitializeComponent();
            curUser = uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string batchNum = BatchID.Text;
            string newItem = NewItem.Text;
            string newQuant = NewQuant.Text;
            string newExp = NewDate.Text;
            string pass = YourPass.Text;

            int res = Loginfuncs.Verify(curUser, pass);
            var window = Window.GetWindow(this);

            int itemID = MainDbFuncs.getOneItem(newItem);

         

            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else if (!int.TryParse(batchNum, out int intBatch))
            {
                topText.Text = "Invalid Batch Number";
            }
            else if(!int.TryParse(newQuant, out int intQuant))
            {
                topText.Text = "Invalid Quantity";
            }
            else if(!DateTime.TryParse(newExp, out DateTime expDate))
            {
                topText.Text = "Invalid Date";
            }
            else
            {
                MainDbFuncs.QueryMainDB($"EXEC BatchActions @Action=1, @number={intBatch}, @item={itemID}, @quant={intQuant}, @date='{expDate}'");
                window.Close();
            }

        }
    }
}
