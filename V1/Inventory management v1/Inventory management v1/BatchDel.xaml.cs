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
    /// Interaction logic for BatchDel.xaml
    /// </summary>
    public partial class BatchDel : UserControl
    {
        string curUser;
        public BatchDel(string uname)
        {
            InitializeComponent();
            curUser= uname;
        }

        private void clicked(object sender, RoutedEventArgs e)
        {
            string batchID = ID.Text;
            string yourPass = YourPass.Text;

            int res = Loginfuncs.Verify(curUser, yourPass);
            var window = Window.GetWindow(this);
            if (res == -1)
            {
                topText.Text = "Wrong Password";
            }
            else if(!int.TryParse(batchID, out int intID))
            {
                topText.Text = "invalid ID";
            }
            else
            {
                MainDbFuncs.QueryMainDB($"EXEC Batchactions @Action=2, @number = {intID} ");
                window.Close();
            }
        }
    }
}

