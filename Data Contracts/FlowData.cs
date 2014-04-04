using System;

namespace Wsdot.Traffic
{
    /// <summary>
    /// Represents a traffic flow sensor.
    /// </summary>
    public class FlowData
    {
        /// <summary>
        /// A unique ID that identifies a specific station.
        /// </summary>
        public int FlowDataID { get; set; }

        /// <summary>
        /// The time of the station reading.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// The name of the flow station.
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// The region that maintains the flow station.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The location of the flow station.
        /// </summary>
        public RoadwayLocation FlowStationLocation { get; set; }

        /// <summary>
        /// The current traffic condition at the flow station. 
        /// </summary>
        public FlowStationReading? FlowReadingValue { get; set; }

    }

    /// <summary>
    /// Flow station reading.
    /// </summary>
    public enum FlowStationReading
    {
        /// <summary>Unknown</summary>
        Unknown,
        /// <summary>Wide open</summary>
        WideOpen,
        /// <summary>Moderate</summary>
        Moderate,
        /// <summary>Heavy</summary>
        Heavy,
        /// <summary>Stop and go</summary>
        StopAndGo,
        /// <summary>No data</summary>
        NoData
    }
}