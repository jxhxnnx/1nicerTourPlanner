using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1nicerTourPlanner.BusinessLayer.ExpImpHandling;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    class ImportHandler_Test
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
        public void no_problems_without_log_test()
        {
            ImportHandler handler = new ImportHandler();
            handler.createLog("[]");
            Assert.AreEqual(handler.logList.Count, 0);
        }
        [Test]
        public void create_logs_test()
        {
            ImportHandler handler = new ImportHandler();
            string logData = "[{\"Name\": \"Stefan\",\"Distance\": 110.0,\"Date\": \"2021-05-02T00:00:00\"," +
                "\"Report\": \"Wir sind eher gemütlich gefahren\",\"Rating\": 6,\"TotalTime\": 80.0,\"TourID\": 42," +
                "\"Alone\": false,\"Vehicle\": \"Car\",\"Weather\": \"Sunny\",\"Traveller\": \"Johanna\",\"Speed\": 82.5}]";
            handler.createLog(logData);
            TestContext.WriteLine(logData);
            Assert.AreEqual(handler.logList.Count, 1);
            Assert.AreEqual(handler.logList[0].Name, "Stefan");
        }
        
    }
}
