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

namespace Submission_of_Applications_Новосельцев.Pages
{
    /// <summary>
    /// Логика взаимодействия для Passport.xaml
    /// </summary>
    public partial class Passport : Page
    {
        public Passport()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts stat = new Contacts();
            this.NavigationService.Navigate(stat);
        }
    }
}
