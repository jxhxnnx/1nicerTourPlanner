using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public PrintWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = new PrintTourVM(tour);
        }
    }
}
