using _1nicerTourPlanner.DataAccessLayer;
using Moq;
using NUnit.Framework;
using System;

namespace _1nicerTourPlanner.Test
{
    public class HTTPConnection_Test
    {

        [Test]
        public void return_uri_test()
        {
            Uri uri = new Uri("http://www.mapquestapi.com/directions/v2/route?key=cAPnl8Ur8VmsYmXA4igAOLIb6qVOKS6Q&from=Wien&to=Graz");
            var mock = new Mock<IHTTPConnection>();
            mock.Setup(x => x.RequestBuilder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(uri);

            Uri response = mock.Object.RequestBuilder("Wien", "Graz");
            Assert.IsNotNull(response);
            Assert.AreEqual(response, uri);
        }
    }
}
