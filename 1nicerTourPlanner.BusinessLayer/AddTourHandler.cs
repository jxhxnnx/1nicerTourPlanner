using _1nicerTourPlanner.DataAccessLayer;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class AddTourHandler
    {
        private TourDAO tourDAO;
        public AddTourHandler()
        {
            tourDAO = new TourDAO();
        }
        public void AddTour(string NewName, string NewDescription, float NewDistance, string NewStart, string NewDestination, string imagepath)
        {
            tourDAO.AddTour(NewName, NewDescription, NewDistance, NewStart, NewDestination, imagepath);
        }
        public bool NameExists(string name)
        {
            return tourDAO.NameExists(name);
        }
    }
}
