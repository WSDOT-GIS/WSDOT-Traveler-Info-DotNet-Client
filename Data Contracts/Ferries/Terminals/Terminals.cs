using System;

namespace WsdotTravelerInfoContracts.Ferries.Terminals
{
	/// <summary>
	/// Where this terminal should appear on a GIS map (at various zoom levels).
	/// </summary>
	public class ZoomLocation
	{
		/// <summary>The GIS zoom level</summary>
		public int ZoomLevel { get; set; }
		/// <summary>The terminal's latitude for this GIS zoom level.</summary>
		public double? Latitude { get; set; }
		/// <summary>
		/// The terminal's longitude for this GIS zoom level.
		/// </summary>
		public double? Longitude { get; set; }
	}

	public class Link
	{
		/// <summary>
		/// The URL of the transit link.
		/// </summary>
		public string LinkURL { get; set; }
		/// <summary>
		/// The name of the transit agency.
		/// </summary>
		public string LinkName { get; set; }
		/// <summary>
		/// A preferred sort order (sort-ascending with respect to other transit links in this array).
		/// </summary>
		public int? SortSeq { get; set; }
	}

	public class WaitTime
	{
		/// <summary>
		/// Unique identifier for the route associated with this wait time.
		/// </summary>
		public int? RouteID { get; set; }
		/// <summary>
		/// The name of the route associated with this wait time.
		/// </summary>
		public string RouteName { get; set; }
		/// <summary>
		/// Notes detailing wait time conditions along with tips for vehicles and passengers.
		/// </summary>
		public string WaitTimeNotes { get; set; }
		/// <summary>
		/// The date this wait time information was last updated.
		/// </summary>
		public DateTimeOffset? WaitTimeLastUpdated { get; set; }
	}

	public class Bulletin
	{
		/// <summary>
		/// The title of the bulletin.
		/// </summary>
		public string BulletinTitle { get; set; }
		/// <summary>
		/// The content of the bulletin.
		/// </summary>
		public string BulletinText { get; set; }
		/// <summary>
		/// A preferred sort order (sort-ascending with respect to other bulletins in this array).
		/// </summary>
		public int BulletinSortSeq { get; set; }
		/// <summary>
		/// The date that this bulletin was last updated.
		/// </summary>
		public DateTime? BulletinLastUpdated { get; set; }
		/// <summary>
		/// Legacy string representation of BulletinLastUpdated.
		/// </summary>
		public string BulletinLastUpdatedSortable { get; set; }
	}

	public class Terminal
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


		/// <summary>Indicates whether or not overhead passenger loading is available.</summary>
		public bool OverheadPassengerLoading { get; set; }


		/// <summary>Indicates whether or not the terminal has an elevator.</summary>
		public bool Elevator { get; set; }


		/// <summary>Indicates whether or not the terminal has a waiting room.</summary>
		public bool WaitingRoom { get; set; }


		/// <summary>Indicates whether or not the terminal offers food service.</summary>
		public bool FoodService { get; set; }


		/// <summary>Indicates whether or not the terminal has one or more restrooms.</summary>
		public bool Restroom { get; set; }


		/// <summary>The latitude of the terminal.</summary>
		public double? Latitude { get; set; }


		/// <summary>The longitude of the terminal.</summary>
		public double? Longitude { get; set; }


		/// <summary>The first line of the terminal's address.</summary>
		public string AddressLineOne { get; set; }


		/// <summary>The second line of the terminal's address.</summary>
		public string AddressLineTwo { get; set; }


		/// <summary>The city where the terminal is located.</summary>
		public string City { get; set; }


		/// <summary>The state where the terminal is located.</summary>
		public string State { get; set; }


		/// <summary>The terminal's zip code.</summary>
		public string ZipCode { get; set; }


		/// <summary>The country where the terminal is located.</summary>
		public string Country { get; set; }


		/// <summary>A URL to a page that displays the terminal on a GIS map.</summary>
		public string MapLink { get; set; }


		/// <summary>Instructions detailing how to drive to the terminal.</summary>
		public string Directions { get; set; }

		/// <summary>
		/// Where this terminal should appear on a GIS map (at various zoom levels).
		/// </summary>
		public ZoomLocation[] DispGISZoomLoc { get; set; }

		/// <summary>Parking information for this terminal.</summary>
		public string ParkingInfo { get; set; }


		/// <summary>Information about parking-related shuttles that service this terminal.</summary>
		public string ParkingShuttleInfo { get; set; }


		/// <summary>Tips for commuting to this terminal from the airport.</summary>
		public string AirportInfo { get; set; }


		/// <summary>Information about parking shuttles that go between the airport and this terminal.</summary>
		public string AirportShuttleInfo { get; set; }


		/// <summary>Information for travelers who plan on taking a motorcycle to this terminal.</summary>
		public string MotorcycleInfo { get; set; }


		/// <summary>Information for travelers who plan on taking a truck to this terminal.</summary>
		public string TruckInfo { get; set; }


		/// <summary>Information for travelers who plan on taking their bicycle to this terminal.</summary>
		public string BikeInfo { get; set; }


		/// <summary>Information about trains that service this terminal.</summary>
		public string TrainInfo { get; set; }


		/// <summary>Information about taxis that service this terminal.</summary>
		public string TaxiInfo { get; set; }


		/// <summary>Tips for carpool/vanpools commuting to this terminal.</summary>
		public string HovInfo { get; set; }

		/// <summary>Links to transit agencies that service this terminal.</summary>
		public Link[] TransitLinks { get; set; }
		/// <summary>The wait times associated with this terminal.</summary>
		public WaitTime[] WaitTimes { get; set; }

		/// <summary>Miscellaneous information about the terminal.</summary>
		public string AdditionalInfo { get; set; }


		/// <summary>Information about this terminal's lost and found department.</summary>
		public string LostAndFoundInfo { get; set; }


		/// <summary>Information about security plans that affect this terminal.</summary>
		public string SecurityInfo { get; set; }


		/// <summary>Information about relevant construction projects and how they might affect this terminal.</summary>
		public string ConstructionInfo { get; set; }


		/// <summary>Details food service vendors that service this terminal.</summary>
		public string FoodServiceInfo { get; set; }


		/// <summary>Information about ADA accessibility features available at this terminal.</summary>
		public string AdaInfo { get; set; }


		/// <summary>Introduction to fares information and how to purchase tickets at this terminal.</summary>
		public string FareDiscountInfo { get; set; }


		/// <summary>Information about the tally system and how it affects travelers waiting at this terminal.</summary>
		public string TallySystemInfo { get; set; }

		/// <summary>
		/// Link to the chamber of commerce associated with this terminal.
		/// </summary>
		public Link ChamberOfCommerce { get; set; }

		/// <summary>Information about the Ferry Advisory Committee that services this terminal.</summary>
		public string FacInfo { get; set; }


		/// <summary>Indicates ownership status of this WSF resource (owned, leased, etc).</summary>
		public string ResourceStatus { get; set; }


		/// <summary>Indicates a categorization value for this terminal (eg. passenger and car, passenger only, etc).</summary>
		public string TypeDesc { get; set; }


		/// <summary>Indicates whether or not terminal condition data should be displayed for this terminal (true indicates that it should be hidden).</summary>
		public bool REALTIME_SHUTOFF_FLAG { get; set; }


		/// <summary>If REALTIME_SHUTOFF_FLAG is true, this message can be used to explain why terminal condition data is not available.</summary>
		public string REALTIME_SHUTOFF_MESSAGE { get; set; }

		/// <summary>Links designed to help travelers who are visiting this terminal.</summary>
		public Link[] VisitorLinks { get; set; }

		/// <summary>The bulletins / alerts associated with this terminal.</summary>
		public Bulletin[] Bulletins { get; set; }

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
	}
}
