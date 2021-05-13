using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace _1nicerTourPlanner.Test
{
    public class ImageHandler_Test
    {
        [Test]
        public void get_correct_imagepath_test()
        {
            ImageHandler imgHandler = new ImageHandler();
            MapInfos mapInfo = new MapInfos()
            {
                sessionId = "TestId",
                Distance = "30"
            };
            mapInfo.boundingBox = new List<string>();
            mapInfo.boundingBox.Add("1");
            mapInfo.boundingBox.Add("2");
            mapInfo.boundingBox.Add("3");
            mapInfo.boundingBox.Add("4");
            string imagepath = imgHandler.GetImagePath(mapInfo, "TestName");

            Assert.AreEqual(imagepath, "C:\\Users\\Lenovo\\Desktop\\FHTechnikum\\4.Semester\\SWE2\\1nicerTourPlanner\\1nicerTourPlanner\\Images\\TestName.png");
        }
    }
}
