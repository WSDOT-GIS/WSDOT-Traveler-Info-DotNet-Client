using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wsdot.Traffic
{
    public class BorderCrossingData: ITrafficFeature
    {
        DateTime Time { get; set; }
        string CrossingName { get; set; }
        RoadwayLocation BorderCrossingLocation { get; set; }
        int WaitTime { get; set; }

        public TravelerInfoMapServices.Feature ToFeature(bool includeSpatialReference = false, int? outSR = null)
        {
            throw new NotImplementedException();
        }
    }
}