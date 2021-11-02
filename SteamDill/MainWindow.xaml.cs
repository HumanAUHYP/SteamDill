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

                if (z == null) MessageBox.Show($"Неправильный логин или пароль", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    var type = types.Where(a => a.id_type == z.id_type).FirstOrDefault();
                    MessageBox.Show($"Авторизация успешна, {z.name}, вы {type.type_user}");
                    if (type.type_user == "Официант")
                    {
                        WaiterMenu waiterMenu = new WaiterMenu();
                        waiterMenu.Show();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
