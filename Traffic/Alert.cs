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
        public int AlertID { get; set; }


        /// <summary>
        /// County where alert is located
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// End location for the alert on the roadway
        /// </summary>
        public RoadwayLocation EndRoadwayLocation { get; set; }

        /// <summary>
        /// Estimated end time for alert
        /// </summary>
        public DateTime EndTime { get; set; }


        /// <summary>
        /// Categorization of alert, i.e. Collision, maintenance, etc.
        /// </summary>
        public string EventCategory { get; set; }


        /// <summary>
        /// Current status of alert, open, closed
        /// </summary>
        public string EventStatus { get; set; }


        /// <summary>
        /// Optional - Additional information about the alert, used for relaying useful extra information for an alert
        /// </summary>
        public string ExtendedDescription { get; set; }


        /// <summary>
        /// Information about what the alert has been issued for
        /// </summary>
        public string HeadlineDescription { get; set; }


        /// <summary>
        /// When was alert was last changed
        /// </summary>
        public DateTime LastUpdatedTime { get; set; }


        /// <summary>
        /// Expected impact on traffic, highest, high, medium, low
        /// </summary>
        public string Priority { get; set; }


        /// <summary>
        /// WSDOT Region which entered the alert
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Start location for the alert on the roadway
        /// </summary>
        public RoadwayLocation StartRoadwayLocation { get; set; }

        /// <summary>
        /// When the impact on traffic began
        /// </summary>
        public DateTime StartTime { get; set; }




        public TravelerInfoMapServices.Feature ToFeature(bool includeSpatialReference = false, int? outSR = null)
        {
            throw new NotImplementedException();
        }
    }
}