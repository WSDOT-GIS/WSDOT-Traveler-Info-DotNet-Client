﻿using System;

namespace Wsdot.Traffic
{
    public class BorderCrossingData
    {
        public DateTime Time { get; set; }
        public string CrossingName { get; set; }
        public RoadwayLocation BorderCrossingLocation { get; set; }
        public int WaitTime { get; set; }
    }
}