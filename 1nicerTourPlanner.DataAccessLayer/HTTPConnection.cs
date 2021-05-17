using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class HTTPConnection : IHTTPConnection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string urlData;
        private string serverResponse;
        public HTTPConnection()
        {
            urlData = ConfigurationManager.AppSettings["DataUrl"].ToString();
        }

        public string GetJsonResponse(string Start, string Destination)
        {
            Uri requesturi = RequestBuilder(Start, Destination);
            HandleRequest(requesturi);
            return serverResponse;
        }
        public Uri RequestBuilder(string Start, string Destination)
        {
            string requesturi = urlData + "&from=" + Start + "&to=" + Destination;

            return new Uri(requesturi);
        }
        public void HandleRequest(Uri completeRequest)
        {
            try
            {
                WebRequest request = WebRequest.Create(completeRequest);
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    serverResponse = reader.ReadToEnd();
                }
                response.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
    }
}
