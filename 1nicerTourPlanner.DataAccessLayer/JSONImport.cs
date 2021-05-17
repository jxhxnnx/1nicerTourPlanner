using System;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class JSONImport
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string getFileName()
        {
            string filename = "";
            try
            {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "Tour";
                dialog.DefaultExt = ".json";
                dialog.Filter = "Json files (.json)|*.json";
                Nullable<bool> result = dialog.ShowDialog();
                if (result == true)
                {

                    filename = dialog.FileName;
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }


            return filename;
        }

    }
}
