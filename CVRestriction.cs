using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class CVRestriction
    {
        public string StateRouteID { get; set; }
        public string State { get; set; }
        public int RestrictionWidthInInches { get; set; }
        public int RestrictionHeightInInches { get; set; }
        public int RestrictionLengthInInches { get; set; }
        public int RestrictionWeightInPounds { get; set; }
        public bool IsDetourAvailable { get; set; }
        public bool IsPermanentRestriction { get; set; }
        public bool IsExceptionsAllowed { get; set; }
        public bool IsWarning { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime DateExpires { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string RestrictionComment { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string BridgeNumber { get; set; }
        public int MaximumGrossVehicleWeightInPounds { get; set; }
        public string BridgeName { get; set; }
        public int BLMaxAxle { get; set; }
        public int CL8MaxAxle { get; set; }
        public int SAMaxAxle { get; set; }
        public int TDMaxAxle { get; set; }
        public string VehicleType { get; set; }
        public CommercialVehicleRestrictionType RestrictionType { get; set; }

        public RoadwayLocation StartRoadwayLocation { get; set; }
        public RoadwayLocation EndRoadwayLocation { get; set; }
    }

    public enum CommercialVehicleRestrictionType
    {
        BridgeRestriction,
        RoadRestriction
    }
}