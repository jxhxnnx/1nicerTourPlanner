using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1nicerTourPlanner.BusinessLayer.Filehandling
{
    public class PDFHandler : IFileHandler
    {
        private string file;
        public PDFHandler(string _file)
        {
            file = _file;
        }
        public void Open()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(file) { UseShellExecute = true };
            Process.Start(startInfo);

        }
    }
}
