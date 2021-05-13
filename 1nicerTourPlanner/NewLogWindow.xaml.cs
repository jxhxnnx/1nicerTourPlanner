using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für NewLogWindow.xaml
    /// </summary>
    public partial class NewLogWindow : Window
    {
        public NewLogWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = new AddLogVM(tour);
        }
    }
}
