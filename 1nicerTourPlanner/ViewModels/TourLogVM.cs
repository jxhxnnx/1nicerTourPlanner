using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections;
using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.DataAccessLayer;

namespace _1nicerTourPlanner.ViewModels
{
    class TourLogVM
    {
        private TourDAO tourDAO = new TourDAO();
        public List<TourLog> Logs;
        public TourLogVM()
        {
           // Logs = tourDAO.GetLogs();
        }
    }
}
