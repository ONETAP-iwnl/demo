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
    /// Логика взаимодействия для UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        private DemoExdDEntities _db;
        private Product _currentProduct;
        public UpdateProductWindow(Product product, DemoExdDEntities db)
        {
            InitializeComponent();
            _db = db;
            _currentProduct = product;

            if (_currentProduct != null)
            {
                NameProductTextBox.Text = _currentProduct.NameProduct;
                DescriptionTextBox.Text = _currentProduct.Description;
                PriceTextBox.Text = _currentProduct.Price.ToString();
                SizeBoxTextBox.Text = _currentProduct.SizeBox;
                WeightWithBoxTextBox.Text = _currentProduct.WeightWithBox;
                WeightWithoutBoxTextBox.Text = _currentProduct.WeightWithoutBox;
                NumberStandartTextBox.Text = _currentProduct.NumberStandart;
                CostTextBox.Text = _currentProduct.Cost.ToString();
                NumberWorkshopTextBox.Text = _currentProduct.NumberWorkshop.ToString();
                CountEmployeesTextBox.Text = _currentProduct.CountEmployees.ToString();
                IdMaterialsTextBox.Text = _currentProduct.Id_Materials.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _currentProduct.NameProduct = NameProductTextBox.Text;
            _currentProduct.Description = DescriptionTextBox.Text;

            if (int.TryParse(PriceTextBox.Text, out int price))
                _currentProduct.Price = price;

            _currentProduct.SizeBox = SizeBoxTextBox.Text;
            _currentProduct.WeightWithBox = WeightWithBoxTextBox.Text;
            _currentProduct.WeightWithoutBox = WeightWithoutBoxTextBox.Text;
            _currentProduct.NumberStandart = NumberStandartTextBox.Text;

            if (int.TryParse(CostTextBox.Text, out int cost))
                _currentProduct.Cost = cost;

            if (int.TryParse(NumberWorkshopTextBox.Text, out int numberWorkshop))
                _currentProduct.NumberWorkshop = numberWorkshop;

            if (int.TryParse(CountEmployeesTextBox.Text, out int countEmployees))
                _currentProduct.CountEmployees = countEmployees;

            if (int.TryParse(IdMaterialsTextBox.Text, out int idMaterials))
                _currentProduct.Id_Materials = idMaterials;

            _db.SaveChanges();

            MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
