using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelerInfoMapServices;
using TravelerInfoMapServices.Geometry;

namespace Wsdot.Traffic
{
	public class Camera: ITrafficFeature
	{
		public int CameraID { get; set; }
		public RoadwayLocation CameraLocation { get; set; }
		public string CameraOwner { get; set; }
		public string Description { get; set; }
		public double DisplayLatitude { get; set; }
		public double DisplayLongitude { get; set; }
		public int ImageHeight { get; set; }
		public int ImageWidth { get; set; }
		public bool IsActive { get; set; }
		public string OwnerUrl { get; set; }
		public string Region { get; set; }
		public int SortOrder { get; set; }
		public string Title { get; set; }

		public Feature ToFeature(bool includeSpatialReference = false, int? outSR=null)
		{

			Point point = new Point
			{
				x = Convert.ToDouble(CameraLocation.Longitude),
				y = Convert.ToDouble(CameraLocation.Latitude),
				spatialReference = includeSpatialReference ? new WkidBasedSpatialReference { wkid = 4326 } : null
			};

			var feature = new Feature
			{
				geometry = point,
				attributes = new
				{
					CameraID = CameraID,
					CameraOwner = CameraOwner,
					Description = Description,
					ImageWidth = ImageWidth,
					ImageHeight = ImageHeight,
					IsActive = IsActive,
					OwnerUrl = OwnerUrl,
					Region = Region,
					SortOrder = SortOrder,
					Title = Title,
					LocationDescription = CameraLocation.Description,
					RoadName = CameraLocation.RoadName,
					Direction = CameraLocation.Direction,
					MilePost = CameraLocation.MilePost
				}
			};

			if (outSR.HasValue && outSR != 4326)
			{
				ProjectionInfo startProj = KnownCoordinateSystems.Geographic.World.WGS1984;
				ProjectionInfo endProj = null;
				if (outSR.Value == 102100 || outSR.Value == 3857)
				{
					endProj = KnownCoordinateSystems.Projected.World.WebMercator;
				}
				else
				{
					throw new NotSupportedException("The specified output coordinate system is not supported.");
				}

				double[] xy = { Convert.ToDouble(CameraLocation.Longitude), Convert.ToDouble(CameraLocation.Latitude) };

				Reproject.ReprojectPoints(xy, null, startProj, endProj, 0, 1);

				point.x = xy[0];
				point.y = xy[1];

			}

			return feature;
		}

	}
}