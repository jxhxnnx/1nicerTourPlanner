using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace _1nicerTourPlanner.Test
{
    [TestFixture]
    public class DB_Test
    {
        [Test]
        public void get_tours_test()
        {
            var mock = new Mock<IDataAccess>();
            mock.Setup(x => x.GetTours()).Returns(GetSampleTours());

            List<Tour> test = mock.Object.GetTours();

            Assert.That(test.Count != 0);
        }

        [Test]
        public void name_exists_test()
        {
            Tour testTour = GetSampleTours()[0];
            var mock = new Mock<IDataAccess>();
            mock.Setup(x => x.NameExists(It.Is<string>(i => i == "Name"))).Returns(true);
            bool test = testTour.Name == "Name";

            Assert.AreEqual(mock.Object.NameExists("Name"), test);
        }

        [Test]
        public void get_correct_log_test()
        {
            var mock = new Mock<IDataAccess>();
            int id = 3;
            mock.Setup(x => x.GetLogs(id)).Returns(GetLog(id));

            List<TourLog> test = mock.Object.GetLogs(3);

            Assert.That(test[0].TourID == 3);
            //mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);
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
                    TourID = 2
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


