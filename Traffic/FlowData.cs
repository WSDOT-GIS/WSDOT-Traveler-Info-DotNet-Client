using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class FlowData
    {
        /// <summary>
        /// A unique ID that identifies a specific station.
        /// </summary>
        int FlowDataID { get; set; }

        /// <summary>
        /// The time of the station reading.
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        /// The name of the flow station.
        /// </summary>
        string StationName { get; set; }

        /// <summary>
        /// The region that maintains the flow station.
        /// </summary>
        string Region { get; set; }

        /// <summary>
        /// The location of the flow station.
        /// </summary>
        RoadwayLocation FlowStationLocation { get; set; }

        /// <summary>
        /// The current traffic condition at the flow station. 
        /// </summary>
        FlowStationReading? FlowReadingValue { get; set; }

    }

    public enum FlowStationReading
    {
        Unknown,
        WideOpen,
        Moderate,
        Heavy,
        StopAndGo,
        NoData
    }
}