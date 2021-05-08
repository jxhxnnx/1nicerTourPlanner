using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class FileImport
    {
        public string getFileName()
        {
            string filename = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Tour";
            dlg.DefaultExt = ".json"; // Default file extension
            dlg.Filter = "Json files (.json)|*.json"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }
            return filename;
        }

    }
}
