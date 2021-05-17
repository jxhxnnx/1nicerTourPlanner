using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für FilesWindow.xaml
    /// </summary>
    public partial class FilesWindow : Window
    {
        public FilesWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = new FilesVM(tour);
        }
    }
}
