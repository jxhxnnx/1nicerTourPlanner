using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaktionslogik für ModifyTourWindow.xaml
    /// </summary>
    public partial class ModifyTourWindow : Window
    {
        public ModifyTourWindow(Tour tour)
        {
            InitializeComponent();
            this.DataContext = new ModifyTourVM(tour);
        }
        /*public ModifyTourWindow()
        {
            InitializeComponent();
            this.DataContext = new ModifyTourVM();
        }*/

    }
}
