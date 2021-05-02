using NUnit.Framework;

using TourPlanner.DataAccessLayer;

namespace _1nicerTourPlanner.Test
{
    public class RESTClient_Test
    {
        public RESTClient client = new RESTClient();

        [Test]
        public void Static_Uri_Works()
        {
            Assert.IsNotNull(client.makeImageDataRequest());
            System.Console.WriteLine(client.makeImageDataRequest());
        }
        [Test]
        public void Dreams_Come_True()
        {
            client.getInformationFromResponse(client.makeImageDataRequest());
            System.Console.WriteLine(client.getURIforImage(client.sessionId, client.boundingBox));
        }
        [Test]
        public void Get_This_Damn_Image()
        {
            client.getInformationFromResponse(client.makeImageDataRequest());
            client.getImage();
        }
    }
}
