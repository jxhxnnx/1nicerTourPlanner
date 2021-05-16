using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.BusinessLayer.ReportHandling;
using _1nicerTourPlanner.Models;
using System.Windows.Input;

namespace _1nicerTourPlanner.ViewModels
{
    public class PrintTourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Tour printTour;
        private PrintHandler printHandler;
        public PrintTourVM(Tour tour)
        {
            printTour = tour;
            printHandler = new PrintHandler();
        }

        private ICommand printDetailsCommand;
        private ICommand printSummaryCommand;
        public ICommand PrintDetailsCommand => printDetailsCommand ??= new RelayCommand(PrintDetails);
        public ICommand PrintSummaryCommand => printSummaryCommand ??= new RelayCommand(PrintSummary);

        private void PrintDetails(object commandParameter)
        {

            printHandler.PrintDetailedReport(printTour);

        }
        private void PrintSummary(object commandParameter)
        {
            printHandler.PrintSummaryReport(printTour);
        }
    }
}
