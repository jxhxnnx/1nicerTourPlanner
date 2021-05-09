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

namespace _1nicerTourPlanner.ViewModels
{
    public class PrintTourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Tour printTour;
        public PrintTourVM(Tour tour)
        {
            printTour = tour;
        }

        private ICommand printDetailsCommand;
        public ICommand PrintDetailsCommand => printDetailsCommand ??= new RelayCommand(PrintDetails);

        private void PrintDetails(object commandParameter)
        {
            string pdfName = printTour.Name + ".pdf";
            string pdfPath = ConfigurationManager.AppSettings["PDFFolderPath"].ToString() + "\\" + pdfName;
            try
            {
                if (File.Exists(pdfPath))
                {
                    File.Delete(pdfPath);
                }
                PdfWriter writer = new PdfWriter(pdfPath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph(printTour.Name)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);
                document.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                ls.SetMarginTop(10).SetMarginBottom(10);
                Image img = new Image(ImageDataFactory
                .Create(printTour.Imagepath))
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                .SetHeight(240)
                .SetWidth(320);
                document.Add(img);
                document.Add(ls);
                document.Add(new Paragraph($"Start:\t {printTour.Start}"));
                document.Add(new Paragraph($"Destination:\t {printTour.Destination}"));
                document.Add(new Paragraph($"Description:\t {printTour.Description}"));
                document.Add(new Paragraph($"Distance:\t {printTour.Distance} km"));
                
                document.Add(ls);
                document.Add(new Paragraph("Logs").SetFontSize(16));

                foreach (var item in printTour.Logs)
                {
                    document.Add(new Paragraph($"Name:\t{ item.Name }"));
                    document.Add(new Paragraph($"Distance:\t{item.Distance} km"));
                    document.Add(new Paragraph($"Date:\t{item.Date}"));
                    document.Add(new Paragraph($"Report:\t{item.Report}"));
                    document.Add(new Paragraph($"Rating:\t{item.Rating} out of 10"));
                    document.Add(new Paragraph($"Total Time:\t{item.TotalTime} min"));
                    document.Add(new Paragraph($"Alone:\t{item.Alone}"));
                    document.Add(new Paragraph($"Vehicle:\t{item.Vehicle}"));
                    document.Add(new Paragraph($"Weather:\t{item.Weather}"));
                    document.Add(new Paragraph($"Traveller:\t{item.Traveller}"));
                    document.Add(new Paragraph($"Average Speed:\t{item.Speed} km/h"));
                    document.Add(ls);
                }


                document.Close();
                MessageBox.Show("Success!");
            }
            catch(Exception)
            {
                log.Error("Generating detailed Tour-Report failed");
            }
            
        }

        private ICommand printSummaryCommand;
        public ICommand PrintSummaryCommand => printSummaryCommand ??= new RelayCommand(PrintSummary);

        private void PrintSummary(object commandParameter)
        {
            string pdfName = printTour.Name + "_summary.pdf";
            string pdfPath = ConfigurationManager.AppSettings["PDFFolderPath"].ToString() + "\\" + pdfName;
            try
            {
                if (File.Exists(pdfPath))
                {
                    File.Delete(pdfPath);
                }
                PdfWriter writer = new PdfWriter(pdfPath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph(printTour.Name)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(24);
                document.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                ls.SetMarginTop(10).SetMarginBottom(10);
                Image img = new Image(ImageDataFactory
                .Create(printTour.Imagepath))
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                .SetHeight(240)
                .SetWidth(320);
                document.Add(img);
                document.Add(ls);
                document.Add(new Paragraph($"Start:\t {printTour.Start}"));
                document.Add(new Paragraph($"Destination:\t {printTour.Destination}"));
                document.Add(new Paragraph($"Description:\t {printTour.Description}"));
                document.Add(new Paragraph($"Distance:\t {printTour.Distance} km"));
                document.Add(ls);
                document.Add(new Paragraph("Log-Summary: ").SetFontSize(16));
                float timeSummary = 0;
                float distanceSummary = 0;

                foreach (var item in printTour.Logs)
                {
                    timeSummary = timeSummary + item.TotalTime;
                    distanceSummary = distanceSummary + item.Distance;
                }
                float timeInHours = timeSummary / 60;
                document.Add(new Paragraph($"Total time:\t {timeSummary} min = {timeInHours} h"));
                document.Add(new Paragraph($"Total distance:\t {distanceSummary} km"));

                document.Close();
                MessageBox.Show("Success!");
            }
            catch (Exception)
            {
                log.Error("Generating detailed Tour-Report failed");
            }
        }
    }
}
