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
    /// Логика взаимодействия для AuthorizWindow.xaml
    /// </summary>
    public partial class AuthorizWindow : Window
    {
        DemoExdDEntities db;

        MainWindow mw;
        ManagerWindow ManagerWindow;

        public AuthorizWindow()
        {
            InitializeComponent();

            db = new DemoExdDEntities();
            mw = new MainWindow();
            ManagerWindow = new ManagerWindow();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            db = DemoExdDEntities.GetContext();

            var user = db.Users.Where(d => d.Login == LogTB.Text && d.Password == PaswwordTB.Password).FirstOrDefault();

            if(user != null)
            {
                if(user.Roles.NameRoles.Equals("Менеджер"))
                {
                    this.Close();
                    ManagerWindow.Show();
                }
                else if(user.Roles.NameRoles.Equals("Пользователь"))
                {
                    this.Close();
                    mw.Show();
                }
                else if (user.Roles.NameRoles.Equals("Администратор"))
                {
                    this.Close();
                    ManagerWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Данные неверны");
            }
        }
    }
}
