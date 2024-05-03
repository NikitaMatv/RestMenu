﻿using System;
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
using RestWaiter.Components;
namespace RestWaiter.Pages
{
    /// <summary>
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public Order contsOrd = new Order();
        public int selectind = 0;
        public CartPage()
        {
            InitializeComponent();
            //LvTable.ItemsSource = App.DB.Order.Where(x => x.EmployeeID == App.LoggedEmployee.ID && x.DataTimeEnd == null).ToList();
            //LvTable.SelectedIndex = selectind;
            //contsOrd = LvTable.SelectedItem as Order;
            Update();
            Update2();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            if (selectedclient.StatusId == 1)
            {
                if (selectedclient.Count > 1)
                {
                    selectedclient.Count = selectedclient.Count - 1;
                }
                else
                {
                    App.DB.Order_Meal.Remove(selectedclient);
                }
                App.DB.SaveChanges();
                Update();
            }
            else
            {
                MessageBox.Show("Данный пункт заказа уже подтрежден его изменить нельзя");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            if (selectedclient.StatusId == 1)
            {
                App.DB.Order_Meal.Remove(selectedclient);
                App.DB.SaveChanges();
                Update();
            }
            else
            {
                MessageBox.Show("Данный пункт заказа уже подтрежден его изменить нельзя");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as Button).DataContext as Order_Meal;
            if (selectedclient.StatusId == 1)
            {
                if (selectedclient.Count < 20)
                {
                    selectedclient.Count = selectedclient.Count + 1;
                }
                else
                {
                    MessageBox.Show("Можно заказать тока 20 шт");
                    return;
                }
                App.DB.SaveChanges();
                Update();
            }
            else
            {
                MessageBox.Show("Данный пункт заказа уже подтрежден его изменить нельзя");
            }

        }

        private void Update()
        {
            LvTable.ItemsSource = App.DB.Order.Where(x => x.EmployeeID == App.LoggedEmployee.ID && x.DataTimeEnd == null).ToList();
            LvTable.SelectedIndex = selectind;
            contsOrd = LvTable.SelectedItem as Order;
            LbCart.ItemsSource = App.DB.Order_Meal.Where(x => x.OrderID == contsOrd.ID).ToList();
            int pri = 0;
            IEnumerable<Order_Meal> products = App.DB.Order_Meal.Where(x => x.OrderID == contsOrd.ID).ToList();
            foreach (var items in products)
            {
                pri += (int)items.Meal.Price * (int)items.Count;
            }
            contsOrd.Price = (int)pri;
            App.DB.SaveChanges();
            TbTotalPrice.Text = $"Цена: {contsOrd.Price} руб.";
            TbEndePrice.Text = $"Цена со скидкой: {contsOrd.Price * 0.95} руб.";
          
        }

        private void LvTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            contsOrd = (sender as StackPanel).DataContext as Order;
            selectind = LvTable.SelectedIndex;
            Update();
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
          
                IEnumerable<Order_Meal> products = App.DB.Order_Meal.Where(x => x.OrderID == contsOrd.ID).ToList();
            foreach (var items in products)
            {
                if (items.StatusId == 1)
                {
                    App.DB.Order_Meal.Remove(items);
                }
            }
                App.DB.SaveChanges();
                Update();
            
        }

        private void BtCompl_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Order_Meal> products = App.DB.Order_Meal.Where(x => x.OrderID == contsOrd.ID).ToList();
            foreach (var items in products)
            {
                items.StatusId = 2;

            }
            contsOrd.StatusID = 2;
            App.DB.SaveChanges();
            Update();
        }
        public IEnumerable<Meal> meal = App.DB.Meal.ToList();

        private void Update2()
        {
            if (TbSearch.Text.Length > 0)
            {
                meal = meal.Where(x => x.Name.ToLower().Contains(TbSearch.Text.Trim().ToLower()));
                LBMeal.ItemsSource = meal.ToList();
            }
            else
            {
                LBMeal.ItemsSource = meal.ToList();
            }
        }
        private void BtFirst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 1).ToList();
            Update2();
        }
        private void BtSecond_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 2).ToList();
            Update2();
        }

        private void BtSalad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 3).ToList();
            Update2();
        }

        private void BtDessert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 4).ToList();
            Update2();
        }

        private void BtDrinks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.Where(x => x.CotegoriesID == 5).ToList();
            Update2();
        }

        private void BtAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            meal = App.DB.Meal.ToList();
            TbSearch.Text = string.Empty;
            Update2();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update2();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedclient = (sender as MenuItem).DataContext as Meal;
            if (selectedclient == null)
            {
                MessageBox.Show("Выберете товар");
                return;
            }
            else
            {   if (App.DB.Order_Meal.FirstOrDefault(x => x.Order.ID == contsOrd.ID && x.MealID == selectedclient.ID && x.StatusId == 1) == null)
                {
                    Order_Meal zakaz = new Order_Meal();
                    zakaz.MealID = selectedclient.ID;
                    zakaz.Count = 1;
                    zakaz.OrderID = contsOrd.ID;
                    zakaz.StatusId = 1;
                    App.DB.Order_Meal.Add(zakaz);
                }
                else
                {
                    var zakazz = App.DB.Order_Meal.FirstOrDefault(x => x.OrderID == contsOrd.ID && x.MealID == selectedclient.ID && x.StatusId == 1) as Order_Meal;
                    if (zakazz.Count < 20)
                    {
                        zakazz.Count = zakazz.Count + 1;
                    }
                    else
                    {
                        MessageBox.Show("Одну позицию из меню можно заказать не больше 20 раз в одно заказе!");
                    }
                }
                    App.DB.SaveChanges();
                Update();
                }
                
            }

        
    }
    }