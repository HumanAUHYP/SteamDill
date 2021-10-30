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
using System.Windows.Shapes;

namespace LoginPage
{
    public partial class Login : Window
    {
        public static ObservableCollection<users> users { get; set; }
        public Login()
        {
            InitializeComponent();
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
                users = new ObservableCollection<users>(db_connection.connection.users.ToList());
                var z = users.Where(a => a.login == txt_login.Text && a.password == txt_password.Password).FirstOrDefault();
                MessageBox.Show($"авторизация успешна {z.name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}