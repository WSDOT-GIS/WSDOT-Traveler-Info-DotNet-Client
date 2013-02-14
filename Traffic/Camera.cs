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

		public Feature ToFeature(bool includeSpatialReference = false)
		{
			return new Feature
			{
				geometry = new Point
				{
					x = CameraLocation.Longitude,
					y = CameraLocation.Latitude,
					spatialReference = includeSpatialReference ? new WkidBasedSpatialReference { wkid = 4326 } : null
				},
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
		}
	}
}