using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WsdotTravelerInfoContracts.Ferries.Terminals
{
	public class SpaceForArrivalTerminal
	{
		/// <summary>Unique identifier for the arrival terminal.</summary>
		public int TerminalID { get; set; }
		/// <summary>The name of the arrival terminal.</summary>
		public string TerminalName { get; set; }
		/// <summary>Unique identifier for the vessel making this departure.</summary>
		public int VesselID { get; set; }
		/// <summary>The name of the vessel making this departure.</summary>
		public string VesselName { get; set; }
		/// <summary>Indicates whether or not reservable space should be displayed.</summary>
		public bool DisplayReservableSpace { get; set; }
		/// <summary>The remaining reservable space available on the vessel.</summary>
		public int? ReservableSpaceCount { get; set; }
		/// <summary>A Hex color representing the ReservableSpaceCount.</summary>
		public string ReservableSpaceHexColor { get; set; }
		/// <summary>Indicates whether or not drive-up space should be displayed.</summary>
		public bool DisplayDriveUpSpace { get; set; }
		/// <summary>The remaining drive-up space available on the vessel.</summary>
		public int? DriveUpSpaceCount { get; set; }
		/// <summary>A Hex color representing DriveUpSpaceCount.</summary>
		public string DriveUpSpaceHexColor { get; set; }
		/// <summary>The maximum space available on the vessel making this departure.</summary>
		public int MaxSpaceCount { get; set; }
	}

	public class DepartingSpace
	{
		/// <summary>The date and time of the departure.</summary>
		public DateTime Departure { get; set; }
		/// <summary>Indicates whether or not the departure is cancelled.</summary>
		public bool IsCancelled { get; set; }
		/// <summary>Unique identifier for the vessel making this departure.</summary>
		public int VesselID { get; set; }
		/// <summary>The name of the vessel making this departure.</summary>
		public string VesselName { get; set; }
		/// <summary>The maximum space available on the vessel making this departure.</summary>
		public int MaxSpaceCount { get; set; }
		/// <summary>The available space for one or more destinations.</summary>
		public SpaceForArrivalTerminal[] SpaceForArrivalTerminals { get; set; }
	}
}
