using _1nicerTourPlanner.BusinessLayer;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    class TourFactory_Test
    {
        [Test]
        public void RefreshFlagChange()
        {
            ITourFactory tourFactory = TourFactory.GetInstance();
            tourFactory.changeRefreshFlag();
            Assert.IsTrue(tourFactory.Refresh_flag);
            tourFactory.changeRefreshFlag();
            Assert.IsFalse(tourFactory.Refresh_flag);
        }
    }
}
