

namespace _1nicerTourPlanner.BusinessLayer
{
    public static class TourLogFactory
    {
        private static ITourLogFactory instance;
        public static ITourLogFactory GetInstance()
        {
            if(instance == null)
            {
                instance = new TourLogFactoryImpl();
            }
            return instance;
        }
    }
}
