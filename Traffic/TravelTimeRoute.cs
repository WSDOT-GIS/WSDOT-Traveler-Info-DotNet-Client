using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class TravelTimeRoute
    {
        /// <summary>
        /// Unique ID that is specific to a route.
        /// </summary>
        public int TravelTimeID { get; set; }

        /// <summary>
        /// A friendly name for the route.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description for the route.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The last time that the data for this route was updated.
        /// </summary>
        public DateTime TimeUpdated { get; set; }

        /// <summary>
        /// The location where this route begins.
        /// </summary>
        public RoadwayLocation StartPoint { get; set; }

        /// <summary>
        /// The location where this route ends.
        /// </summary>
        public RoadwayLocation EndPoint { get; set; }

        /// <summary>
        /// Total distance of this route in miles.
        /// </summary>
        public decimal Distance { get; set; }

        /// <summary>
        /// The average time in minutes that it takes to complete this route.
        /// </summary>
        public int AverageTime { get; set; }

        /// <summary>
        /// The current estimated time in minutes that it takes to complete this route. 
        /// </summary>
        public int CurrentTime { get; set; }

    }
}