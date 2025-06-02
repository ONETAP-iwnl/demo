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

namespace Demoe
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        DemoExdDEntities db;

        AuthorizWindow AuthorizWindow;
        public ManagerWindow()
        {
            InitializeComponent();
            db = DemoExdDEntities.GetContext();
            //AuthorizWindow = new AuthorizWindow();
            ProductDG.ItemsSource = db.Product.ToList();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //AuthorizWindow.Show();
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {

            Product selectedProduct = (sender as FrameworkElement).DataContext as Product;
            if (selectedProduct != null)
            {
                UpdateProductWindow updateWindow = new UpdateProductWindow(selectedProduct, db);
                updateWindow.ShowDialog();
                ProductDG.ItemsSource = DemoExdDEntities.GetContext().Product.ToList();
            }
        }
    }
}
