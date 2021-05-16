using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        public string Open()
        {
            string content = File.ReadAllText(file);
            return content;
        }
     }
}
