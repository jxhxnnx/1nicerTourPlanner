using System;
using System.Collections.Generic;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    [TestFixture]
    public class DB_Test
    {


        [Test]
        public void DBNotNull()
        {
            var db = new Mock<DB>();
            Assert.IsNotNull(db);
        }

        [Test]
        public void get_tour_test()
        {
            
        }

        private List<Tour> GetSampleTours()
        {
            List<Tour> output = new List<Tour>
            {
                new Tour
                {
                    Name = "Name",
                    Description= "Description",
                    Distance = 10,
                    Start = "Wien",
                    Destination = "Graz",
                },
                new Tour
                {
                    Name = "Name2",
                    Description= "Description2",
                    Distance = 20,
                    Start = "Wien",
                    Destination = "Linz",
                },
                new Tour
                {
                    Name = "Name3",
                    Description= "Description3",
                    Distance = 30,
                    Start = "Wien",
                    Destination = "Villach",
                }
            };
            return output;
        }
    }
}


