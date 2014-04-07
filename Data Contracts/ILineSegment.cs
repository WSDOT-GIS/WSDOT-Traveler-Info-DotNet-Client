using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wsdot.Traffic.Contracts.Elc;

namespace Wsdot.Traffic
{
	/// <summary>
	/// Classes implementing this interface have a start and end point along a state route.
	/// </summary>
	public interface ILineSegment
	{
		/// <summary>
		/// Start location for the alert on the roadway
		/// </summary>
		RoadwayLocation StartRoadwayLocation { get; set; }

		/// <summary>
		/// End location for the alert on the roadway
		/// </summary>
		RoadwayLocation EndRoadwayLocation { get; set; }

		/// <summary>
		/// The route location as calculated by the ELC.
		/// </summary>
		ElcRouteLocation RouteLocation { get; set; }
	}
}
