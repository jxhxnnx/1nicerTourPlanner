using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using NUnit.Framework;
using System.Diagnostics;

namespace _1nicerTourPlanner.Test
{
    public class FileVM_Test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        [Test]
        public void extract_type_works()
        {
            FilesVM fileVM = new FilesVM(new Tour());
            fileVM.CurrentFile = "blabla.png";
            string type = fileVM.ExtractFileFormat();
            Assert.AreEqual(type, ".png");
        }
        [Test]
        public void create_full_path_correct_test()
        {
            FilesVM fileVM = new FilesVM(new Tour() { TourID = 3 });
            fileVM.CurrentFile = "blabla.png";
            string full_path = fileVM.CreateFullPath();
            Assert.AreEqual(full_path, "C:\\Users\\Lenovo\\Desktop\\FHTechnikum\\4.Semester\\SWE2\\" +
                                        "1nicerTourPlanner\\1nicerTourPlanner\\Uploads\\3\\blabla.png");
        }
        [Test]
        public void get_all_filenames_test()
        {
            FilesVM fileVM = new FilesVM(new Tour() { TourID = 72 });
            foreach(var item in fileVM.Files)
            {
                TestContext.WriteLine(item);
            }
            Assert.AreEqual(fileVM.Files.Count, 5);
        }

    }
}
