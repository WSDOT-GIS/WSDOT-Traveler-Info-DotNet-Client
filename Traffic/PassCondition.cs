using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class PassCondition
    {
        /// <summary>
        /// A unique identifier for a mountain pass.
        /// </summary>
        public int MountainPassId { get; set; }

        /// <summary>
        /// A friendly name for a mountain pass.
        /// </summary>
        public string MountainPassName { get; set; }

        /// <summary>
        /// The latitude of the mountain pass.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the mountain pass.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The time the PassCondition was updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The temperature reading at the mountain pass in degrees fahrenheit.
        /// </summary>
        public int TemperatureInFahrenheit { get; set; }

        /// <summary>
        /// The elevation of the mountain pass in feet.
        /// </summary>
        public int ElevationInFeet { get; set; }

        /// <summary>
        /// The weather conditions at the pass.
        /// </summary>
        public string WeatherCondition { get; set; }

        /// <summary>
        /// The roadway conditions at the pass.
        /// </summary>
        public string RoadCondition { get; set; }

        /// <summary>
        /// Indicates if a travel advisory is active.
        /// </summary>
        public bool TravelAdvisoryActive { get; set; }

        /// <summary>
        /// The travel restriction in the primary direction.
        /// </summary>
        public TravelRestriction RestrictionOne { get; set; }

        /// <summary>
        /// The travel restriction in the secondary direction. 
        /// </summary>
        public TravelRestriction RestrictionTwo { get; set; }
    }

    public class TravelRestriction
    {
        /// <summary>
        /// The direction of this restriction.
        /// </summary>
        public string TravelDirection { get; set; }

        /// <summary>
        /// The text of this restriction. 
        /// </summary>
        public string RestrictionText { get; set; }

    }
}