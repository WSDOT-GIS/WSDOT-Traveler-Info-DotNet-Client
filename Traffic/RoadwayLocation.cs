using System;

namespace Wsdot.Traffic
{
	/// <summary>
	/// Describes a specific location on a WA State Highway
	/// </summary>
	public class RoadwayLocation
	{
		/// <summary>
		/// A description of the location. This could be a cross street or a nearby landmark. 
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The name of the road. 
		/// </summary>
		public string RoadName { get; set; }

		/// <summary>
		/// The side of the road the location is on (Northbound, Southbound). This does not necessarily correspond to an actual compass direction. 
		/// </summary>
		public string Direction { get; set; }

		/// <summary>
		/// The milepost of the location. 
		/// </summary>
		public decimal MilePost { get; set; }
		/// <summary>
		/// Latitude of the location. 
		/// </summary>
		public decimal Latitude { get; set; }

		/// <summary>
		/// Longitude of the location. 
		/// </summary>
		public decimal Longitude { get; set; }
	}
}