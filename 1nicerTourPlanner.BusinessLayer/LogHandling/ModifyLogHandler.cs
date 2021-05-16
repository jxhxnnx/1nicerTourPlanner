using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
