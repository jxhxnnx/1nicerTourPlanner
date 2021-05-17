using _1nicerTourPlanner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer.MapImageHandling
{
    public class HTTPResponse
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private JObject jsonData;

        public void SetJObject(string jsonstring)
        {
            jsonData = JObject.Parse(jsonstring);
        }
        public MapInfos GetMapData()
        {   
            MapInfos mapInfo = new MapInfos();
            try
            {
                
                mapInfo.sessionId = jsonData["route"]["sessionId"].ToString();
                mapInfo.boundingBox = new List<string>();
                mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["ul"]["lat"].ToString());
                mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["ul"]["lng"].ToString());
                mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["lr"]["lat"].ToString());
                mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["lr"]["lng"].ToString());

                for (int i = 0; i < mapInfo.boundingBox.Count; i++)
                {
                    mapInfo.boundingBox[i] = mapInfo.boundingBox[i].Replace(",", ".");
                }

                mapInfo.Distance = jsonData["route"]["distance"].ToString();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }


            return mapInfo;

        }
    }
}
