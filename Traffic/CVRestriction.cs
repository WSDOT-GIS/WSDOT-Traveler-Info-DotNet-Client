using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class CVRestriction
    {
        string StateRouteID { get; set; }
        string State { get; set; }
        int RestrictionWidthInInches { get; set; }
        int RestrictionHeightInInches { get; set; }
        int RestrictionLengthInInches { get; set; }
        int RestrictionWeightInPounds { get; set; }
        bool IsDetourAvailable { get; set; }
        bool IsPermanentRestriction { get; set; }
        bool IsExceptionsAllowed { get; set; }
        bool IsWarning { get; set; }
        DateTime DatePosted { get; set; }
        DateTime DateEffective { get; set; }
        DateTime DateExpires { get; set; }
        string LocationName { get; set; }
        string LocationDescription { get; set; }
        string RestrictionComment { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string BridgeNumber { get; set; }
        int MaximumGrossVehicleWeightInPounds { get; set; }
        string BridgeName { get; set; }
        int BLMaxAxle { get; set; }
        int CL8MaxAxle { get; set; }
        int SAMaxAxle { get; set; }
        int TDMaxAxle { get; set; }
        string VehicleType { get; set; }
        CommercialVehicleRestrictionType RestrictionType { get; set; }

        RoadwayLocation StartRoadwayLocation { get; set; }
        RoadwayLocation EndRoadwayLocation { get; set; }
    }

    public enum CommercialVehicleRestrictionType
    {
        BridgeRestriction,
        RoadRestriction
    }
}