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
        int MountainPassId { get; set; }

        /// <summary>
        /// A friendly name for a mountain pass.
        /// </summary>
        string MountainPassName { get; set; }

        /// <summary>
        /// The latitude of the mountain pass.
        /// </summary>
        double Latitude { get; set; }

        /// <summary>
        /// The longitude of the mountain pass.
        /// </summary>
        double Longitude { get; set; }

        /// <summary>
        /// The time the PassCondition was updated.
        /// </summary>
        DateTime DateUpdated { get; set; }

        /// <summary>
        /// The temperature reading at the mountain pass in degrees fahrenheit.
        /// </summary>
        int TemperatureInFahrenheit { get; set; }

        /// <summary>
        /// The elevation of the mountain pass in feet.
        /// </summary>
        int ElevationInFeet { get; set; }

        /// <summary>
        /// The weather conditions at the pass.
        /// </summary>
        string WeatherCondition { get; set; }

        /// <summary>
        /// The roadway conditions at the pass.
        /// </summary>
        string RoadCondition { get; set; }

        /// <summary>
        /// Indicates if a travel advisory is active.
        /// </summary>
        bool TravelAdvisoryActive { get; set; }

        /// <summary>
        /// The travel restriction in the primary direction.
        /// </summary>
        TravelRestriction RestrictionOne { get; set; }

        /// <summary>
        /// The travel restriction in the secondary direction. 
        /// </summary>
        TravelRestriction RestrictionTwo { get; set; }
    }

    public class TravelRestriction
    {
        /// <summary>
        /// The direction of this restriction.
        /// </summary>
        string TravelDirection { get; set; }

        /// <summary>
        /// The text of this restriction. 
        /// </summary>
        string RestrictionText { get; set; }

    }
}