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
using System.Windows.Shapes;

namespace Inventory_management_v1
{
    /// <summary>
    /// Interaction logic for AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Window
    {
        int table;
        public AddMenu(int table,string uname)
        {
            InitializeComponent();
            this.table = table;
            switch(table) // chooses which gui to show based on the value passed
            { // and show the GUI choosen
                case 1:
                    this.ContentHolder.Content = new addUsers(uname);
                    break;
                case 2:
                    this.ContentHolder.Content = new AddItem(uname);
                    break;
                case 3:
                    this.ContentHolder.Content = new AddBatch(uname);
                    break;
                default:
                    break;
            }
        }
    }
}
