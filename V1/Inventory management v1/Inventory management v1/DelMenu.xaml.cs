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
    /// Interaction logic for DelMenu.xaml
    /// </summary>
    public partial class DelMenu : Window
    {
        int table;
        public DelMenu(int table, string uname)
        {
            InitializeComponent();
            this.table = table;
            switch (table)
            {
                case 1:
                    this.ContentHolder.Content = new UserDel(uname);
                    break;
                case 2:
                    this.ContentHolder.Content = new ItemDel();
                    break;
                case 3:
                    this.ContentHolder.Content = new BatchDel();
                    break;
                default:
                    break;
            }

        }
    }
}
