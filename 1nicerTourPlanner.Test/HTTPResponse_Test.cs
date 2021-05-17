using _1nicerTourPlanner.BusinessLayer.MapImageHandling;
using _1nicerTourPlanner.Models;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class HTTPResponse_Test
    {
        public string jsonstring = "{\"route\":{\"boundingBox\":{\"lr\":{\"lng\":16.373583,\"lat\":48.186138},\"ul\":{\"lng\":6.556204,\"lat\":49.553902}},\"distance\":548.512,\"formattedTime\":\"08:26:41\",\"sessionId\":\"60a2237b-001f-4ee4-02b4-3509-0e647c97e651\"}}";
        [Test]
        public void get_correct_map_infos_test()
        {
            HTTPResponse resp = new HTTPResponse();
            resp.SetJObject(jsonstring);
            MapInfos info = resp.GetMapData();
            Assert.AreEqual(info.sessionId, "60a2237b-001f-4ee4-02b4-3509-0e647c97e651");
            Assert.AreEqual(info.boundingBox[0], "49.553902");
            Assert.AreEqual(info.boundingBox[1], "6.556204");
            Assert.AreEqual(info.boundingBox[2], "48.186138");
            Assert.AreEqual(info.boundingBox[3], "16.373583");
        }

    }
}
