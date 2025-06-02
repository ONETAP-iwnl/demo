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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {

        DemoExdDEntities db;
        public AddProductWindow()
        {
            InitializeComponent();
            db = new DemoExdDEntities();

            ComboBoxMaterials.ItemsSource = db.Materials.ToList();
            ComboBoxMaterials.DisplayMemberPath = "NameMaterial";
            ComboBoxMaterials.SelectedValuePath = "Id_Materials";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            db = DemoExdDEntities.GetContext();

            int selected = (int)ComboBoxMaterials.SelectedValue;

            Product product = new Product
            {
                NameProduct = NameProductTextBox.Text,
                Description = DescriptionTextBox.Text,
                Price = Convert.ToInt32(PriceTextBox.Text),
                SizeBox = SizeBoxTextBox.Text,
                WeightWithBox = WeightWithBoxTextBox.Text,
                WeightWithoutBox = WeightWithoutBoxTextBox.Text,
                NumberStandart = NumberStandartTextBox.Text,
                Cost = Convert.ToInt32(CostTextBox.Text),
                NumberWorkshop = Convert.ToInt32(NumberWorkshopTextBox.Text),
                CountEmployees = Convert.ToInt32(CountEmployeesTextBox.Text),
                Id_Materials = selected
            };
            db.Product.Add(product);
            
            db.SaveChanges();

            MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
