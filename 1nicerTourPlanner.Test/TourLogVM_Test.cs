using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class TourLogVM_Test
    {
        [Test]
        public void LogsGetFilled()
        {
            Tour tour = new Tour()
            {
                TourID = 42
            };
            TourLogVM logVM = new TourLogVM(tour);
            Assert.Greater(tour.Logs.Count, 0);
        }

    }
}

