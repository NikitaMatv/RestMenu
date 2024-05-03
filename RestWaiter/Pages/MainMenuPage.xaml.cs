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

namespace RestWaiter.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }
        private void BtHistory_Click(object sender, RoutedEventArgs e)
        {
            //MemuFame.NavigationService.Navigate(new HistoryPage());
        }


        private void BtExit_Click(object sender, RoutedEventArgs e)
        {           
           
        }

        private void BtProfile_Click(object sender, RoutedEventArgs e)
        {
            //MemuFame.NavigationService.Navigate(new ProfilePage(App.LoggedCustomer));
        }

        private void BtCart_Click(object sender, RoutedEventArgs e)
        {
            //MemuFame.NavigationService.Navigate(new BasketPage());
        }

        private void BtMenu_Click(object sender, RoutedEventArgs e)
        {
            MemuFame.NavigationService.Navigate(new MenuPage());
        }
    }
}
