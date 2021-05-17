using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für ModifyLogWindow.xaml
    /// </summary>
    public partial class ModifyLogWindow : Window
    {
        public ModifyLogWindow(TourLog log)
        {
            InitializeComponent();
            DataContext = new ModifyLogVM(log);
        }
    }
}
