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

namespace RestBoss.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            IncomeTB.Text = $"Ваш ресторан заработал {App.DB.Order.Where(o => o.DataTimeEnd < DateTime.Now).Sum(o => o.Price)}";
            VisitorsTB.Text = $"Вы обслужили гостей {App.DB.Order.Where(o => o.DataTimeEnd < DateTime.Now).Count()} раз";
        }

        private void BtChief_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChiefRequestPage());
        }

        private void BtEmployees_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPage());
        }

        private void BtDismissed_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
