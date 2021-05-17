using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class FileVM_Test
    {
        [Test]
        public void extract_type_works()
        {
            FilesVM fileVM = new FilesVM(new Tour());
            fileVM.CurrentFile = "blabla.png";
            string type = fileVM.ExtractFileFormat();
            Assert.AreEqual(type, ".png");
        }

    }
}
