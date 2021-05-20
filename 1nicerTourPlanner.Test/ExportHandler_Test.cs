using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1nicerTourPlanner.BusinessLayer.ExpImpHandling;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class ExportHandler_Test
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
        public void set_path_correct_test()
        {
            ExportHandler handler = new ExportHandler();
            string path = handler.setPath(new Models.Tour() { TourID = 3 });
            TestContext.WriteLine(path);
            Assert.AreEqual(path, "C:\\Users\\Lenovo\\Desktop\\FHTechnikum\\4.Semester" +
                                    "\\SWE2\\1nicerTourPlanner\\1nicerTourPlanner\\Exports\\3.json");
        }
    }
}
