using System;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public interface IHTTPConnection
    {
        public string GetJsonResponse(string Start, string Destination);
        public Uri RequestBuilder(string Start, string Destination);
        public void HandleRequest(Uri completeRequest);
    }
}
