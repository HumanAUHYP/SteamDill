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
using System.Windows.Shapes;

namespace SteamDill
{
    /// <summary>
    /// Логика взаимодействия для WaiterMenu.xaml
    /// </summary>
    public partial class WaiterMenu : Window
    {
        public WaiterMenu()
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
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            OrdersCreate ordersCreate = new OrdersCreate();
            ordersCreate.Show();
            Close();
        }

        private void btn_complete_Click(object sender, RoutedEventArgs e)
        {
            OrdersComplete ordersComplete = new OrdersComplete();
            ordersComplete.Show();
            Close();
        }
    }
}
