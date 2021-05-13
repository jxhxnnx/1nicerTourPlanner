using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class HTTPConnection : IHTTPConnection
    {
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
            WebRequest request = WebRequest.Create(completeRequest);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                serverResponse = reader.ReadToEnd();
            }
            response.Close();
        }
    }
}
