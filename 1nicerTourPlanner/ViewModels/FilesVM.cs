using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using _1nicerTourPlanner.BusinessLayer.Helper;
using _1nicerTourPlanner.BusinessLayer.Filehandling;

namespace _1nicerTourPlanner.ViewModels
{
    public class FilesVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string openMessage;
        private Validator validator;
        private string filesFolder;
        private ObservableCollection<string> files;
        private Tour currentTour;
        private string currentFile;
        public string CurrentFile
        {
            get
            {
                return currentFile;
            }
            set
            {
                if (currentFile != value)
                {
                    currentFile = value;
                    RaisePropertyChangedEvent(nameof(CurrentFile));
                }
            }
        }
        public string OpenMessage
        {
            get
            {
                return openMessage;
            }
            set
            {
                if (openMessage != value)
                {
                    openMessage = value;
                    RaisePropertyChangedEvent(nameof(OpenMessage));
                }
            }
        }
        public ObservableCollection<string> Files
        {
            get
            {
                return files;
            }
            set
            {
                if (files != value)
                {
                    files = value;
                    RaisePropertyChangedEvent(nameof(Files));
                }
            }
        }
        public Tour CurrentTour
        {
            get
            {
                return currentTour;
            }
            set
            {
                if (currentTour != value)
                {
                    currentTour = value;
                    RaisePropertyChangedEvent(nameof(CurrentTour));
                }
            }
        }
        public FilesVM(Tour tour)
        {
            validator = new Validator();
            CurrentTour = tour;
            Files = new ObservableCollection<string>();
            GetAllFiles();

        }

        private void GetAllFiles()
        {

            filesFolder = ConfigurationManager.AppSettings["UploadsFolderPath"].ToString();
            string folderPath = filesFolder + "\\" + CurrentTour.TourID.ToString();
            if (Directory.Exists(folderPath))
            {
                IEnumerable<string> fileEntries = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)); ;
                foreach (var file in fileEntries)
                {
                    Files.Add(file);
                }
            }

        }

        private ICommand openFileCommand;
        public ICommand OpenFileCommand => openFileCommand ??= new RelayCommand(OpenFile);

        private void OpenFile(object commandParameter)
        {
            IFileHandler handler;
            try
            {
                string type = ExtractFileFormat();
                if (validator.IsAllowedType(type))
                {
                    switch (type)
                    {
                        case ".png":
                            handler = new PNGHandler(CreateFullPath());
                            OpenMessage = handler.Open();
                            break;
                        case ".pdf":
                            handler = new PDFHandler(CreateFullPath());
                            OpenMessage = handler.Open();
                            break;
                        case ".txt":
                            handler = new TXTHandler(CreateFullPath());
                            OpenMessage = handler.Open();
                            break;
                    }
                }
                else
                {
                    log.Error("invalid data dype");
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }
            

        }
        public string ExtractFileFormat()
        {
            return Path.GetExtension(CurrentFile);
            
        }
        public string CreateFullPath()
        {
            string path = ConfigurationManager.AppSettings["UploadsFolderPath"].ToString() + "\\" + CurrentTour.TourID + "\\" + CurrentFile;
            return path;
        }
    }
}
