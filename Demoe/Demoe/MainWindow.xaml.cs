﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthorizWindow AuthorizWindow;
        public MainWindow()
        {
            InitializeComponent();
            //AuthorizWindow = new AuthorizWindow();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //AuthorizWindow.Show();
        }
    }
}
