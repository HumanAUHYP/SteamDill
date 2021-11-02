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
    /// Логика взаимодействия для OrdersComplete.xaml
    /// </summary>
    public partial class OrdersComplete : Window
    {
        public static ObservableCollection<orders> orders { get; set; }
        public OrdersComplete()
        {
            InitializeComponent();
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
            WaiterMenu waiterMenu = new WaiterMenu();
            waiterMenu.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var del = orders.Where(a => a.order_number == txt_order.Text).FirstOrDefault();
                var order_num = del.order_number;
                while (del != null)
                {
                    db_connection.connection.orders.Remove(del);
                    db_connection.connection.SaveChanges();
                    orders = new ObservableCollection<orders>(db_connection.connection.orders.ToList());
                    del = orders.Where(a => a.order_number == txt_order.Text).FirstOrDefault();
                }
                MessageBox.Show($"Order {order_num} completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
