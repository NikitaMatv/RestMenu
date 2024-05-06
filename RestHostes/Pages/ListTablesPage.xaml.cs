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

namespace RestHostes.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListTablesPage.xaml
    /// </summary>
    public partial class ListTablesPage : Page
    {
        public ListTablesPage()
        {
            InitializeComponent();
            LbTable.ItemsSource = App.DB.Tables.Where(x => x.Order.Where(y => y.DataTimeEnd != null && y.DataTimeEnd < DateTime.Now) != null).ToList();
        }

        private void BtTable4_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtTable6_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
