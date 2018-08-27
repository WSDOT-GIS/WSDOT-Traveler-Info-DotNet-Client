using System;

namespace WsdotTravelerInfoContracts.Ferries.Terminals
{
    /// <summary>
    /// Sailing space.
    /// </summary>
    public class SailingSpace
	{
		/// <summary>Unique identifier for a terminal.</summary>
		public int TerminalID { get; set; }
		/// <summary>Identifies this terminal as a unique WSF subject.</summary>
		public int TerminalSubjectID { get; set; }
		/// <summary>Identifies the geographical region where the terminal is located.</summary>
		public int RegionID { get; set; }
		/// <summary>The name of the terminal.</summary>
		public string TerminalName { get; set; }
		/// <summary>The terminal's abbreviation.</summary>
		public string TerminalAbbrev { get; set; }
		/// <summary>A preferred sort order (sort-ascending with respect to other terminals).</summary>
		public int SortSeq { get; set; }

		/// <summary>
		/// The most recent departures leaving this terminal.
		/// </summary>
		public DepartingSpace[] DepartingSpaces { get; set; }
	}

	/// <summary>
	/// Space for arrival terminal
	/// </summary>
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

	/// <summary>
	/// Departing space.
	/// </summary>
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
