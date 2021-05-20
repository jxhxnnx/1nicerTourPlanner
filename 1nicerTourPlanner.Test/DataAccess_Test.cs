using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace _1nicerTourPlanner.Test
{
    [TestFixture]
    public class DataAccess_Test
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
        public void get_tours_test()
        {
            var mock = new Mock<IDataAccess>();
            mock.Setup(x => x.GetTours()).Returns(GetSampleTours());

            List<Tour> test = mock.Object.GetTours();

            Assert.That(test.Count > 0);
            Assert.AreEqual(test[0].Name, "Name");
        }

        [Test]
        public void name_exists_test()
        {
            DB db = new DB();
            Assert.IsTrue(db.NameExists("Artouro"));
        }

        [Test]
        public void connectionstring_test()
        {
            string conString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            TestContext.WriteLine(conString);
            Assert.IsTrue(conString == "Server=localhost;Port=5432;User Id=postgres;Password=passwort;Database=TourPlanner;");
        }

        [Test]
        public void get_correct_log_test()
        {
            var mock = new Mock<IDataAccess>();
            int id = 3;
            mock.Setup(x => x.GetLogs(id)).Returns(GetLog(id));

            List<TourLog> test = mock.Object.GetLogs(3);

            Assert.That(test.Count == 2);
        }

        private List<TourLog> GetLog(int id)
        {
            List<TourLog> output = new List<TourLog>();
            List<TourLog> logs = GetSampleLogs();
            foreach (var item in logs)
            {
                if (item.TourID == id)
                {
                    output.Add(item);
                }
            }
            return output;
        }

        private List<Tour> GetSampleTours()
        {
            List<Tour> output = new List<Tour>
            {
                new Tour
                {
                    Name = "Name",
                    Description= "Description",
                    TourID = 3,
                    Distance = 10,
                    Start = "Wien",
                    Destination = "Graz",
                },
                new Tour
                {
                    Name = "Name2",
                    Description= "Description2",
                    TourID = 2,
                    Distance = 20,
                    Start = "Wien",
                    Destination = "Linz",
                },
                new Tour
                {
                    Name = "Name3",
                    Description= "Description3",
                    TourID = 4,
                    Distance = 30,
                    Start = "Wien",
                    Destination = "Villach",
                }
            };
            return output;
        }
        private List<TourLog> GetSampleLogs()
        {
            List<TourLog> output = new List<TourLog>
            {
                new TourLog
                {
                    Name = "Name",
                    Distance = 10,
                    Report = "blabla",
                    Rating = 8,
                    Alone = true,
                    Speed = 70,
                    TourID = 3
                },
                new TourLog
                {
                    Name = "Name2",
                    Distance = 20,
                    Report = "blabla2",
                    Rating = 9,
                    Alone = true,
                    Speed = 90,
                    TourID = 3
                },
                new TourLog
                {
                    Name = "Name3",
                    Distance = 30,
                    Report = "blabla3",
                    Rating = 3,
                    Alone = false,
                    Speed = 40,
                    TourID = 1
                }
            };
            return output;
        }
    }
}


