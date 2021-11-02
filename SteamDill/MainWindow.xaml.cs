using System;
using System.Collections.ObjectModel;
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

namespace SteamDill
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<users> users { get; set; }
        public static ObservableCollection<user_types> types { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            types = new ObservableCollection<user_types>(db_connection.connection.user_types.ToList());
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

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Close();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                users = new ObservableCollection<users>(db_connection.connection.users.ToList());
                var z = users.Where(a => a.login == txt_login.Text && a.password == txt_password.Password).FirstOrDefault();

                if (z == null) MessageBox.Show($"Неправильный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    MessageBox.Show($"авторизация успешна {z.name}");
                    var type = types.Where(a => a.id_type == z.id_type).FirstOrDefault();
                    if (type.type_user == "Официант")
                    {
                        OrdersCreate ordersCreate = new OrdersCreate();
                        ordersCreate.Show();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btn_create_order_Click(object sender, RoutedEventArgs e)
        {
            OrdersCreate orders = new OrdersCreate();
            orders.Show();
            Close();
        }

        private void TextSizeChanger(object sender, SizeChangedEventArgs e)
        {
            Size n = e.NewSize;
            Size p = e.PreviousSize;
            double l = n.Width / p.Width;
            if (l != double.PositiveInfinity)
            {
                if (sender is TextBox)
                {
                    (sender as TextBox).FontSize *= l;
                }
                else if (sender is TextBlock)
                {
                    (sender as TextBlock).FontSize *= l;
                }
                else if (sender is Button)
                {
                    (sender as Button).FontSize *= l;
                }
                else if (sender is DatePicker)
                    (sender as DatePicker).FontSize *= l;
            }
        }
    }
}
