﻿using RestBoss.Components;
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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            LBEmployee.ItemsSource = App.DB.Employee.Where(x => x.IsDismissed != true).ToList();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            var SelectedEmployee = (sender as MenuItem).DataContext as Employee;
            if (SelectedEmployee == null)
            {
                return;
            }
            NavigationService.Navigate(new EmployeeEditPage(SelectedEmployee));
        }

        private void EmployeeFire_Click(object sender, RoutedEventArgs e)
        {
            var SelectedEmployee = (sender as MenuItem).DataContext as Employee;
            if (SelectedEmployee == null)
            {
                return;
            }
            SelectedEmployee.IsDismissed = true;
            App.DB.SaveChanges();
            LBEmployee.ItemsSource = App.DB.Employee.Where(x => x.IsDismissed != true).ToList();
        }

        private void EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeEditPage(new Employee()));
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
