﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.Models
{
    public class MapInfos
    {
        public string sessionId { get; set; }
        public List<string> boundingBox { get; set; }
        public string Distance { get; set; }
    }
}
