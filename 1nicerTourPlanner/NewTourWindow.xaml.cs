﻿using _1nicerTourPlanner.ViewModels;
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

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für NewTourWindow.xaml
    /// </summary>
    public partial class NewTourWindow : Window
    {
        public NewTourWindow()
        {
            InitializeComponent();
            this.DataContext = new AddTourVM();
        }
    }
}
