using System;

namespace Wsdot.Traffic
{
    /// <summary>
    /// Border crossing data.
    /// </summary>
    public class BorderCrossingData
    {
        /// <summary>The time the data was updated.</summary>
        public DateTime Time { get; set; }
        /// <summary>The name of the border crossing.</summary>
        public string CrossingName { get; set; }
        /// <summary>The location of the border crossing.</summary>
        public RoadwayLocation BorderCrossingLocation { get; set; }
        /// <summary>The wait time to cross at the border crossing.</summary>
        public int WaitTime { get; set; }
    }
}