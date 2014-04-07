using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsdot.Traffic.Client
{
	class SpatialReference {
		public int wkid { get; set; }
	}

	class RouteSegment {
		public double[][][] paths {get; set;}
		public SpatialReference spatialReference { get; set; }
	}

	class ElcRouteLocation
	{
		public float? Arm { get; set; }
		public int? ArmCalcEndReturnCode { get; set; }
		public string ArmCalcEndReturnMessage { get; set; }
		public int? ArmCalcReturnCode { get; set; }
		public string ArmCalcReturnMessage { get; set; }
		public bool? Back { get; set; }
		public float? EndArm { get; set; }
		public bool? EndBack { get; set; }
		public DateTime? EndRealignDate { get; set; }
		public DateTime? EndReferenceDate { get; set; }
		public DateTime? EndResponseDate { get; set; }
		public int? EndSrmp { get; set; }
		public DateTime? RealignmentDate { get; set; }
		public DateTime? ReferenceDate { get; set; }
		public DateTime? ResponseDate { get; set; }
		public string Route { get; set; }
		public RouteSegment RouteGeometry { get; set; }
		public float? Srmp { get; set; }
	}
}
