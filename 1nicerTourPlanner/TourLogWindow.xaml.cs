using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

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
