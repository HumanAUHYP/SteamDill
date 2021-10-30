﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LoginPage
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public static ObservableCollection<ado.type_user> curss { get; set; }
        int i { get; set; }
        public Register()
        {
            InitializeComponent();
            curss = new ObservableCollection<ado.type_user>(class_0.db_connection.connection.type_user.ToList());
            this.DataContext = this;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show($"{i}");
                var save = new ado.Users();
                save.type_id = i;
                save.name = txt_name.Text;
                save.login = txt_login.Text;
                save.password = txt_password.Password;
                class_0.db_connection.connection.Users.Add(save);
                class_0.db_connection.connection.SaveChanges();
                MessageBox.Show("all ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as ado.type_user;
            i = a.id_type;
        }
    }
}
