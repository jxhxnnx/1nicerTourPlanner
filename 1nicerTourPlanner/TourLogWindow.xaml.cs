﻿using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
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
    /// Interaktionslogik für TourLogWindow.xaml
    /// </summary>
    public partial class TourLogWindow : Window
    {
        public TourLogWindow()
        {
            InitializeComponent();
            this.DataContext = new TourLogVM();
        }
        public TourLogWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = new TourLogVM(tour);
        }
    }
}