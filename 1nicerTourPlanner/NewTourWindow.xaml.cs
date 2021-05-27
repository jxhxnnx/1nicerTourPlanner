using _1nicerTourPlanner.ViewModels;
using System;
using System.Windows;

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
