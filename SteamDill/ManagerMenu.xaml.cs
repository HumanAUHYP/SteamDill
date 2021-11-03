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
    /// Логика взаимодействия для ManagerMenu.xaml
    /// </summary>
    public partial class ManagerMenu : Window
    {
        public bool isMaximize = false;
        public ManagerMenu()
        {
            InitializeComponent();
            tb_namePos.Text = $"{GLOBALS.name}, {GLOBALS.pos}";
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
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximize) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
            isMaximize = !isMaximize;
        }

        private void btn_ready_Click(object sender, RoutedEventArgs e)
        {
            OrderReady orderReady = new OrderReady();
            orderReady.Show();
            Close();
        }

        private void btn_orderProd_Click(object sender, RoutedEventArgs e)
        {
            OrdersCreate ordersCreate = new OrdersCreate();
            ordersCreate.Show();
            Close();
        }
    }
}
