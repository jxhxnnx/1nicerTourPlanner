using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.BusinessLayer.Filehandling
{
    public class TXTHandler : IFileHandler
    {
        private string file;
        public TXTHandler(string _file)
        {
            file = _file;
        }
        public void Open()
        {
            string filePath = ConfigurationManager.AppSettings["UploadsFolderPath"].ToString() + file;
            
        }
     }
}
