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
    /// Логика взаимодействия для OrderProducts.xaml
    /// </summary>
    public partial class OrderProducts : Window
    {
        public bool isMaximize = false;
        public static ObservableCollection<products> products { get; set; }
        public static ObservableCollection<storage> storage { get; set; }
        public products product = new products();
        int product_i { get; set; }
        public OrderProducts()
        {
            InitializeComponent();

            tb_namePos.Text = $"{GLOBALS.name}, {GLOBALS.pos}";
            products = new ObservableCollection<products>(db_connection.connection.products.ToList());
            storage = new ObservableCollection<storage>(db_connection.connection.storage.ToList());
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
                var store = storage.Where(a => a.id_product == product_i).FirstOrDefault(); ;

                store.count += Convert.ToInt32(txt_count.Text);
                db_connection.connection.SaveChanges();
                MessageBox.Show($"Order for {txt_count.Text} {product.product_name} created");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmb_product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            product = (sender as ComboBox).SelectedItem as products;
            product_i = product.id_product;
        }
    }
}
