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

namespace ApplicationSetting_НовосЗах
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum pages { setting }

        public void OpenPage(pages _pages)
        {
            if (_pages == pages.setting)
                frame.Navigate(new Pages.Settings(this));
        }
        public MainWindow()
        {
            InitializeComponent();

            OpenPage(pages.setting);
        }
    }
}
