using _1nicerTourPlanner.ViewModels;
using System.Windows;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace _1nicerTourPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
            this.DataContext = new TourVM();
        }
    }
}
