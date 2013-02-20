using System;

namespace Wsdot.Traffic
{
    /// <summary>
    /// A highway alert.
    /// </summary>
    public class Alert: ITrafficFeature
    {
        /// <summary>
        /// Unique Identifier for the alert
        /// </summary>
        int AlertID { get; set; }


        /// <summary>
        /// County where alert is located
        /// </summary>
        string County { get; set; }

        /// <summary>
        /// End location for the alert on the roadway
        /// </summary>
        RoadwayLocation EndRoadwayLocation { get; set; }

        /// <summary>
        /// Estimated end time for alert
        /// </summary>
        DateTime EndTime { get; set; }


        /// <summary>
        /// Categorization of alert, i.e. Collision, maintenance, etc.
        /// </summary>
        string EventCategory { get; set; }


        /// <summary>
        /// Current status of alert, open, closed
        /// </summary>
        string EventStatus { get; set; }


        /// <summary>
        /// Optional - Additional information about the alert, used for relaying useful extra information for an alert
        /// </summary>
        string ExtendedDescription { get; set; }


        /// <summary>
        /// Information about what the alert has been issued for
        /// </summary>
        string HeadlineDescription { get; set; }


        /// <summary>
        /// When was alert was last changed
        /// </summary>
        DateTime LastUpdatedTime { get; set; }


        /// <summary>
        /// Expected impact on traffic, highest, high, medium, low
        /// </summary>
        string Priority { get; set; }


        /// <summary>
        /// WSDOT Region which entered the alert
        /// </summary>
        string Region { get; set; }

        /// <summary>
        /// Start location for the alert on the roadway
        /// </summary>
        RoadwayLocation StartRoadwayLocation { get; set; }

        /// <summary>
        /// When the impact on traffic began
        /// </summary>
        DateTime StartTime { get; set; }




        public TravelerInfoMapServices.Feature ToFeature(bool includeSpatialReference = false, int? outSR = null)
        {
            throw new NotImplementedException();
        }
    }
}