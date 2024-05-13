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
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        Employee EmployeeContext;
        public EmployeeEditPage(Employee employee)
        {
            InitializeComponent();
            RoleIdComboBox.ItemsSource = App.DB.EmployeeRole.ToList();
            EmployeeContext = employee;
            DataContext = employee;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeContext.ID == 0)
            {
                App.DB.Employee.Add(EmployeeContext);
            }
            App.DB.SaveChanges();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}