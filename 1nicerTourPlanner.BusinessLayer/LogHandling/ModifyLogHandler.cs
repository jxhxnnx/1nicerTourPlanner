using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;

namespace _1nicerTourPlanner.BusinessLayer.LogHandling
{
    public class ModifyLogHandler
    {
        private TourDAO tourDAO;
        public ModifyLogHandler()
        {
            tourDAO = new TourDAO();
        }
        public void ModifyLog(TourLog log)
        {
            tourDAO.ModifyLog(log);
        }
    }
}
