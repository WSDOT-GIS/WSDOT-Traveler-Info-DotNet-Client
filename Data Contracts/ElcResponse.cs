using System;

namespace Wsdot.Traffic.Contracts.Elc
{
    /// <summary>
    /// Represents a spatial reference system.
    /// </summary>
    public class SpatialReference
	{
		/// <summary>
		/// The Well-Known Identifier of the spatial reference system.
		/// </summary>
		public int wkid { get; set; }
	}

	/// <summary>
	/// Represents a geometry. Different properties will be populated depending on the type of geometry.
	/// E.g., the x and y properties will have values if the geometry is a point, whereas the paths property will have a value if it is a polyline.
	/// </summary>
	public class Geometry
	{
		/// <summary>
		/// The X coordinate of a point.
		/// </summary>
		public double? x;
		/// <summary>
		/// The Y coordinate of a point.
		/// </summary>
		public double? y;
		/// <summary>
		/// The coordinates that make up a line segment.
		/// </summary>
		public double[][][] paths { get; set; }
		/// <summary>
		/// The spatial reference system of the geometry.
		/// </summary>
		public SpatialReference spatialReference { get; set; }
	}

	/// <summary>
	/// Represents a location on a state route.
	/// </summary>
	public class ElcRouteLocation
	{

		/// <summary>
		/// Since the Find Nearest Route Location method does not return records for locations where it could not find any routes within the search parameters,
		/// this ID parameter can be used to indicate which source location a route location corresponds to.
		/// </summary>
		public int? Id { get; set; }

		/// <summary>An 3 to 11 digit state route identifier.</summary>
		public string Route { get; set; }

		/// <summary>The starting measure value.  This is known as a measure or M value outside of WSDOT.</summary>
		public float? Arm { get; set; }

		/// <summary>The SRMP for the start point of a route segment or the only point of a point.</summary>
		public float? Srmp { get; set; }

		/// <summary>Indicates if the SRMP value is back mileage.</summary>
		public bool? Back { get; set; }

		/// <summary>Indicates of this location is on the Decrease LRS.  This value will be ignored if route is a ramp.</summary>
		public bool? Decrease { get; set; }

		/// <summary>The date that the data was collected.</summary>
		public DateTime? ReferenceDate { get; set; }

		/// <summary>The ArmCalc output date.</summary>
		public DateTime? ResponseDate { get; set; }

		/// <summary>The end measure value of a line segment.  This is known as a measure or M value outside of WSDOT.</summary>
		public float? EndArm { get; set; }

		/// <summary>The end SRMP value of a line segment.</summary>
		public float? EndSrmp { get; set; }

		/// <summary>Indicates if endsrmp represents back-mileage.</summary>
		public bool? EndBack { get; set; }

		/// <summary>The date that endarm and/or endsrmp was collected.</summary>
		public DateTime? EndReferenceDate { get; set; }

		/// <summary>The ArmCalc output date for the end point.</summary>
		public DateTime? EndResponseDate { get; set; }

		/// <summary>This is for storing ArmCalc result data of the start point.</summary>
		public DateTime? RealignmentDate { get; set; }

		/// <summary>This is for storing ArmCalc result data of the end point.</summary>
		public DateTime? EndRealignDate { get; set; }


		/// <summary>Return code from ArmCalc. <seealso href="http://wwwi.wsdot.wa.gov/gis/roadwaydata/training/roadwaydata/pdf/PC_ArmCalc_Manual_3-19-2009.pdf">Appendix A of the PC ArmCalc Training Manual</seealso></summary>
		public int? ArmCalcReturnCode { get; set; }

		/// <summary>Return code from ArmCalc. <seealso href="http://wwwi.wsdot.wa.gov/gis/roadwaydata/training/roadwaydata/pdf/PC_ArmCalc_Manual_3-19-2009.pdf">Appendix A of the PC ArmCalc Training Manual</seealso></summary>
		public int? ArmCalcEndReturnCode { get; set; }

		/// <summary>
		/// The error message (if any) returned by ArmCalc when converting the begin point.
		/// </summary>
		public string ArmCalcReturnMessage { get; set; }

		/// <summary>
		/// The error message (if any) returned by ArmCalc when converting the end point.
		/// </summary>
		public string ArmCalcEndReturnMessage { get; set; }

		/// <summary>
		/// If a location cannot be found on the LRS, this value will contain a message.
		/// </summary>
		public string LocatingError { get; set; }

		/// <summary>
		/// A point or line on a route.
		/// </summary>
		public Geometry RouteGeometry { get; set; }

		/// <summary>
		/// When locating the nearest point along a route, this value will be set to the input point.
		/// </summary>
		public Geometry EventPoint { get; set; }

		/// <summary>
		/// The offset distance from the <see cref="ElcRouteLocation.EventPoint"/> to the <see cref="ElcRouteLocation.RouteGeometry"/> point.
		/// </summary>
		public double? Distance { get; set; }

		/// <summary>
		/// The offset angle from the <see cref="ElcRouteLocation.EventPoint"/> to the <see cref="ElcRouteLocation.RouteGeometry"/> point.
		/// </summary>
		public double? Angle { get; set; }

	}
}
