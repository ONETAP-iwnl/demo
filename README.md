# demo
CREATE DATABASE DemoExdD;
GO

USE DemoExdD;
GO

CREATE TABLE TypePartners(
Id_TypePartners INT PRIMARY KEY IDENTITY(1,1),
NameType NVARCHAR(50)
);

CREATE TABLE Partners(
Id_Partners INT PRIMARY KEY IDENTITY(1,1),
TypePartners INT,
NameCompany NVARCHAR(MAX),
LegalAdress NVARCHAR(MAX),
INN NVARCHAR(13),
FIO_Directed NVARCHAR(MAX),
PhoneNumber NVARCHAR(MAX),
Rating INT,
PlaceOfSales NVARCHAR(MAX),
FOREIGN KEY (TypePartners) References TypePartners(Id_TypePartners)
);

CREATE TABLE Roles(
Id_Roles INT PRIMARY KEY IDENTITY(1,1),
NameRoles NVARCHAR(50)
);

CREATE TABLE Users(
Id_Users INT PRIMARY KEY IDENTITY(1,1),
[Login] NVARCHAR(20),
[Password] NVARCHAR(20),
Roles_ID INT,
FOREIGN KEY (Roles_ID) References Roles(Id_Roles)
);

CREATE TABLE StatusTickets(
Id_Status INT PRIMARY KEY IDENTITY(1,1),
NameStatus NVARCHAR(50)
);
--Создана, В процессе, Выполнена

CREATE TABLE TypeMaterial(
Id_TypeMaterial INT PRIMARY KEY IDENTITY(1,1),
TypeMaterial NVARCHAR(50)
);

CREATE TABLE Suppliers(
Id_Suppliers INT PRIMARY KEY IDENTITY(1,1),
NameSuppliers NVARCHAR(MAX),
INN NVARCHAR(13)
);

CREATE TABLE Materials(
Id_Materials INT PRIMARY KEY IDENTITY(1,1),
id_TypeMaterial INT,
NameMaterial NVARCHAR(MAX),
Id_Supplier INT,
AmmountBoxing INT,
[Description] NVARCHAR(MAX),
Price INT,
FOREIGN KEY (id_TypeMaterial) References TypeMaterial(Id_TypeMaterial),
FOREIGN KEY (Id_Supplier) References Suppliers(Id_Suppliers),
);

CREATE TABLE [Product](
Id_Product INT PRIMARY KEY IDENTITY(1,1),
NameProduct NVARCHAR(MAX),
[Description] NVARCHAR(MAX),
Price INT,
SizeBox NVARCHAR(15),
WeightWithBox NVARCHAR(20), 
WeightWithoutBox NVARCHAR(20),
NumberStandart NVARCHAR(20),
TimeOfCreate DATETIME,
Cost INT,
NumberWorkshop INT,
CountEmployees INT,
Id_Materials INT,
FOREIGN KEY (Id_Materials) REFERENCES Materials(Id_Materials)
);


CREATE TABLE Tickets(
Id_Ticket INT PRIMARY KEY IDENTITY(1,1),
Id_Product INT,
SumTickets INT,
Ammount INT, --кол-во продукции в заявке
Id_Partners INT,
DateOfComplete DATE,
Id_StatusTickets INT,
FOREIGN KEY (Id_Partners) References Partners(Id_Partners),
FOREIGN KEY (Id_Product) References [Product](Id_Product),
FOREIGN KEY (Id_StatusTickets) References StatusTickets(Id_Status)
);


USE DemoExdD;
GO

-- 1. Типы партнёров
INSERT INTO TypePartners (NameType) VALUES
(N'Дилер'),
(N'Розничный магазин'),
(N'Оптовый покупатель');

-- 2. Партнёры
INSERT INTO Partners (TypePartners, NameCompany, LegalAdress, INN, FIO_Directed, PhoneNumber, Rating, PlaceOfSales) VALUES
(1, N'ООО "СтройМаркет"', N'г. Оренбург, ул. Центральная, 10', N'5610001234567', N'Иванов И.И.', N'+7 (3532) 12-34-56', 8, N'Оренбургская область'),
(2, N'ИП Петров', N'г. Орск, ул. Мира, 45', N'5611006543210', N'Петров П.П.', N'+7 (3537) 65-43-21', 7, N'г. Орск');

-- 3. Роли пользователей
INSERT INTO Roles (NameRoles) VALUES
(N'Администратор'),
(N'Менеджер'),
(N'Пользователь');

-- 4. Пользователи
INSERT INTO Users ([Login], [Password], Roles_ID) VALUES
(N'admin', N'admin', 1),
(N'manager', N'man', 2),
(N'user', N'user', 3);

-- 5. Статусы заявок
INSERT INTO StatusTickets (NameStatus) VALUES
(N'Создана'),
(N'В процессе'),
(N'Выполнена');

-- 6. Типы материалов
INSERT INTO TypeMaterial (TypeMaterial) VALUES
(N'Клей'),
(N'Грунтовка');

-- 7. Поставщики
INSERT INTO Suppliers (NameSuppliers, INN) VALUES
(N'ООО "ХимКомплект"', N'7701234567890'),
(N'ЗАО "Материалы+"', N'7723456789012');

-- 8. Материалы
INSERT INTO Materials (id_TypeMaterial, NameMaterial, Id_Supplier, AmmountBoxing, [Description], Price) VALUES
(1, N'Клей ПВА', 1, 20, N'Универсальный клей, 10 л.', 450),
(2, N'Грунтовка глубокого проникновения', 2, 15, N'Для наружных и внутренних работ', 550);

-- 9. Продукция
INSERT INTO [Product] (NameProduct, [Description], Price, SizeBox, WeightWithBox, WeightWithoutBox, NumberStandart, TimeOfCreate, Cost, NumberWorkshop, CountEmployees, Id_Materials) VALUES
(N'Ламинат 8 мм', N'Ламинат для жилых помещений', 1200, N'1200x200x8', N'17 кг', N'16 кг', N'GOST123', GETDATE(), 800, 2, 10, 1),
(N'Штукатурка фасадная', N'Для отделки фасадов', 950, N'500x300x250', N'22 кг', N'20 кг', N'GOST456', GETDATE(), 600, 1, 8, 2);

-- 10. Заявки
INSERT INTO Tickets (Id_Product, SumTickets, Ammount, Id_Partners, DateOfComplete, Id_StatusTickets) VALUES
(1, 24000, 20, 1, '2025-06-10', 1),
(2, 9500, 10, 2, '2025-06-15', 2);


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

___________________
MANAGER WINDOW
____________________
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

private void ProductDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
{

    if (ProductDG.SelectedItem is Product selectedProduct)
    {
        UpdateProductWindow updateWindow = new UpdateProductWindow(selectedProduct, db);
        updateWindow.ShowDialog();
        ProductDG.ItemsSource = db.Product.ToList();
    }
}
