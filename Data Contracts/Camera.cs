
namespace Wsdot.Traffic
{
	public class Camera
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

	}
}