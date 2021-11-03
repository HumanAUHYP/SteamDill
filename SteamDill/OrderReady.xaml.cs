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

namespace SteamDill
{
    /// <summary>
    /// Логика взаимодействия для OrderReady.xaml
    /// </summary>
    public partial class OrderReady : Window
    {
        public bool isMaximize = false;
        public static ObservableCollection<orders> orders { get; set; }
        public OrderReady()
        {
            InitializeComponent();
            tb_namePos.Text = $"{GLOBALS.name}, {GLOBALS.pos}";
            orders = new ObservableCollection<orders>(db_connection.connection.orders.ToList());
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
        private void back_Click(object sender, RoutedEventArgs e)
        {
            ManagerMenu managerMenu = new ManagerMenu();
            managerMenu.Show();
            Close();
        }
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximize) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
            isMaximize = !isMaximize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ready = orders.Where(a => a.order_number == txt_order.Text && a.id_status == 1).FirstOrDefault();
                var order_num = ready.order_number;
                while (ready != null)
                {
                    ready.id_status = 2;
                    db_connection.connection.SaveChanges();
                    orders = new ObservableCollection<orders>(db_connection.connection.orders.ToList());
                    ready = orders.Where(a => a.order_number == txt_order.Text && a.id_status == 1).FirstOrDefault();
                }
                MessageBox.Show($"Order {order_num} ready");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
