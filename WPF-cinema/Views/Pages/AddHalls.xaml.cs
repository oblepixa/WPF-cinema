﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_cinema.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddHalls.xaml
    /// </summary>
    public partial class AddHalls : UserControl
    {
        public AddHalls()
        {
            InitializeComponent();
        }

        private void TextInputOnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            
            e.Handled = regex.IsMatch(e.Text);

        }
    }
}
