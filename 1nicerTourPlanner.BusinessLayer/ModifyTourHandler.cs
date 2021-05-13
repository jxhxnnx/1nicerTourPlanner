using _1nicerTourPlanner.DataAccessLayer;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class ModifyTourHandler
    {
        private TourDAO tourDAO;
        public ModifyTourHandler()
        {
            tourDAO = new TourDAO();
        }
        public void ModifyTour(int TourID, string Name, string Description, float Distance)
        {
            tourDAO.ModifyTour(TourID, Name, Description, Distance);
        }
    }
}
