using System;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class FileImport
    {
        public string getFileName()
        {
            string filename = "";
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Tour";
            dialog.DefaultExt = ".json";
            dialog.Filter = "Json files (.json)|*.json";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {

                filename = dialog.FileName;
            }
            return filename;
        }

    }
}
