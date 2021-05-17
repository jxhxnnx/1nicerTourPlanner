namespace _1nicerTourPlanner.BusinessLayer.Filehandling
{
    public class PNGHandler : IFileHandler
    {
        private string file;
        public PNGHandler(string _file)
        {
            file = _file;
        }
        public string Open()
        {
            return file;
        }
    }
}
