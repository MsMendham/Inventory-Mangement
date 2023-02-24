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
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Window
    {
        int table;
        public EditMenu(int table, string uname)
        {
            InitializeComponent();
            this.table = table;
            switch (table)
            {
                case 1:
                    this.ContentHolder.Content = new EditUser(uname);
                    break;
                case 2:
                    this.ContentHolder.Content = new ItemEdit();
                    break;
                case 3:
                    this.ContentHolder.Content = new EditBatches();
                    break;
                default:
                    break;
            }
        }
    }
}
