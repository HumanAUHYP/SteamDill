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
    /// Логика взаимодействия для OrdersCreate.xaml
    /// </summary>
    public partial class OrdersCreate : Window
    {
        public static ObservableCollection<products> products { get; set; }
        public static ObservableCollection<tables> tables { get; set; }
        int table_i { get; set; }
        int product_i { get; set; }
        public OrdersCreate()
        {
            InitializeComponent();
            products = new ObservableCollection<products>(db_connection.connection.products.ToList());
            tables = new ObservableCollection<tables>(db_connection.connection.tables.ToList());
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
                var save = new orders();
                save.id_status = 1;
                save.id_table = table_i;
                save.id_product = product_i;
                save.order_number = txt_order.Text;
                db_connection.connection.orders.Add(save);
                db_connection.connection.SaveChanges();
                MessageBox.Show("all ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Какие-то поля не заполнены {ex}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void cmb_tabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var table = (sender as ComboBox).SelectedItem as tables;
            table_i = table.id_table;
        }

        private void cmb_product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (sender as ComboBox).SelectedItem as products;
            product_i = product.id_product;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
