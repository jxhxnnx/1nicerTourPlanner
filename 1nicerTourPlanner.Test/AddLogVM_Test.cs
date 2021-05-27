using NUnit.Framework;
using _1nicerTourPlanner.ViewModels;
using _1nicerTourPlanner.Models;

namespace _1nicerTourPlanner.Test
{
    public class AddLogVM_Test
    {
        [Test]
        public void speed_is_correct_test()
        {
            Tour tour = new Tour();
            AddLogVM addLogVM = new AddLogVM(tour) { Distance = 100, TotTime = 60 };
            Assert.AreEqual(100, addLogVM.Speed);
        }

        [Test]
        public void speed_correct_distance_tottime_zero()
        {
            Tour tour = new Tour();
            AddLogVM addLogVM = new AddLogVM(tour) { Distance = 0, TotTime = 0 };
            Assert.AreEqual(0, addLogVM.Speed);
        }

        [Test]
        public void speed_correct_tottime_zero()
        {
            Tour tour = new Tour();
            AddLogVM addLogVM = new AddLogVM(tour) { Distance = 100, TotTime = 0 };
            Assert.AreEqual(0, addLogVM.Speed);
        }
        [Test]
        public void speed_correct_distance_zero()
        {
            Tour tour = new Tour();
            AddLogVM addLogVM = new AddLogVM(tour) { Distance = 0, TotTime = 60 };
            Assert.AreEqual(0, addLogVM.Speed);
        }

    }
}
