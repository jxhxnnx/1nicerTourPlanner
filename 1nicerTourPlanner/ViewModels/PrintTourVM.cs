using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using System.Windows.Documents;
using System.Windows;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Configuration;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using Paragraph = iText.Layout.Element.Paragraph;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Draw;
using System.IO;
using _1nicerTourPlanner.BusinessLayer;

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
