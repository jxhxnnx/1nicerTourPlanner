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
            addLogVM.Distance = 0;
            addLogVM.TotTime = 0;
            Assert.AreEqual(0, addLogVM.Speed);
            addLogVM.Distance = 100;
            Assert.AreEqual(0, addLogVM.Speed);
            addLogVM.Distance = 0;
            addLogVM.TotTime = 60;
            Assert.AreEqual(0, addLogVM.Speed);
        }

    }
}
