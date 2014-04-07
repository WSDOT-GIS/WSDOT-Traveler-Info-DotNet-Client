using System;

namespace Wsdot.Traffic
{
    /// <summary>
    /// Represents a Commercial Vehicle Restriction. 
    /// </summary>
    public class CVRestriction: ILineSegment
    {
        /// <summary>State route ID</summary>
        public string StateRouteID { get; set; }
        /// <summary>State</summary>
        public string State { get; set; }
        /// <summary>Restriction width in inches.</summary>
        public int? RestrictionWidthInInches { get; set; }
        /// <summary>Restriction height in inches.</summary>
        public int? RestrictionHeightInInches { get; set; }
        /// <summary>Restriction length in inches.</summary>
        public int? RestrictionLengthInInches { get; set; }
        /// <summary>Restriction weight in pounds.</summary>
        public int? RestrictionWeightInPounds { get; set; }
        /// <summary>Indicates if a detour is available.</summary>
        public bool IsDetourAvailable { get; set; }
        /// <summary>Indicates if this restriction is permanent.</summary>
        public bool IsPermanentRestriction { get; set; }
        /// <summary>Indicates if exceptions are allowed.</summary>
        public bool IsExceptionsAllowed { get; set; }
        /// <summary>Indicates if this restriction is a warning.</summary>
        public bool IsWarning { get; set; }
        /// <summary>The date that the restriction was posted.</summary>
        public DateTime DatePosted { get; set; }
        /// <summary>The date the restriction goes into effect.</summary>
        public DateTime DateEffective { get; set; }
        /// <summary>The date that the restriction expires.</summary>
        public DateTime DateExpires { get; set; }
        /// <summary>The name of the restriction's location</summary>
        public string LocationName { get; set; }
        /// <summary>A description of the restriction's location.</summary>
        public string LocationDescription { get; set; }
        /// <summary>A comment about the restriction.</summary>
        public string RestrictionComment { get; set; }
        /// <summary>The latitude (y) of the restriction. (WGS84)</summary>
        public double Latitude { get; set; }
        /// <summary>The longitude (x) of the restriction. (WGS84)</summary>
        public double Longitude { get; set; }
        /// <summary>Bridge number.</summary>
        public string BridgeNumber { get; set; }
        /// <summary>Maximum gross vehicle weight in pounds.</summary>
        public int? MaximumGrossVehicleWeightInPounds { get; set; }
        /// <summary>Bridge name.</summary>
        public string BridgeName { get; set; }
        /// <summary>BL Max Axle</summary>
        public int? BLMaxAxle { get; set; }
        /// <summary>CL8 Max Axle</summary>
        public int? CL8MaxAxle { get; set; }
        /// <summary>SA Max Axle</summary>
        public int? SAMaxAxle { get; set; }
        /// <summary>TD Max Axle</summary>
        public int? TDMaxAxle { get; set; }
        /// <summary>Vehicle type</summary>
        public string VehicleType { get; set; }

        /// <summary>The type of restriction.</summary>
        public CommercialVehicleRestrictionType RestrictionType { get; set; }

        /// <summary>The start location of the restriction.</summary>
        public RoadwayLocation StartRoadwayLocation { get; set; }
        /// <summary>The end location of the restriction.</summary>
        public RoadwayLocation EndRoadwayLocation { get; set; }


        /// <summary>
        /// Line segment between <see cref="StartRoadwayLocation"/> and <see cref="EndRoadwayLocation"/>
        /// </summary>
        public double[][][] Line { get; set; }
    }

    /// <summary>
    /// Indicates the type of commercial vehicle restriction.
    /// </summary>
    public enum CommercialVehicleRestrictionType
    {
        /// <summary>Bridge restriction.</summary>
        BridgeRestriction,
        /// <summary>Road restriction.</summary>
        RoadRestriction
    }
}