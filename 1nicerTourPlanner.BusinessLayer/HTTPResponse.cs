using _1nicerTourPlanner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class HTTPResponse
    {
        private JObject jsonData;
        
        public void SetJObject(string jsonstring)
        {
            jsonData = JObject.Parse(jsonstring);
        }
        public MapInfos GetMapData()
        {
            MapInfos mapInfo = new MapInfos();
            mapInfo.sessionId = jsonData["route"]["sessionId"].ToString();
            mapInfo.boundingBox = new List<string>();
            mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["ul"]["lat"].ToString());
            mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["ul"]["lng"].ToString());
            mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["lr"]["lat"].ToString());
            mapInfo.boundingBox.Add(jsonData["route"]["boundingBox"]["lr"]["lng"].ToString());

            for(int i = 0; i < mapInfo.boundingBox.Count; i++)
            {
                mapInfo.boundingBox[i] = mapInfo.boundingBox[i].Replace(",", ".");
            }

            mapInfo.Distance = jsonData["route"]["distance"].ToString();
            return mapInfo;
            
        }
    }
}
