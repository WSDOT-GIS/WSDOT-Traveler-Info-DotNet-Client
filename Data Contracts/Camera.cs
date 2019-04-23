
namespace Wsdot.Traffic
{
    /// <summary>
    /// A traffic camera.
    /// </summary>
    public class Camera
	{
		/// <summary>Unique identifier of the camera.</summary>
		public int CameraID { get; set; }
		/// <summary>The location of the camera.</summary>
		public RoadwayLocation CameraLocation { get; set; }
		/// <summary>The owner of the camera.</summary>
		public string CameraOwner { get; set; }
		/// <summary>A description of the camera.</summary>
		public string Description { get; set; }
		/// <summary>display latitude (y)</summary>
		public double DisplayLatitude { get; set; }
		/// <summary>display longitude (x)</summary>
		public double DisplayLongitude { get; set; }
		/// <summary>The height of the camera image.</summary>
		public int ImageHeight { get; set; }
		/// <summary>The width of the camera image.</summary>
		public int ImageWidth { get; set; }
        /// <summary>Image URL</summary>
        public string ImageUrl { get; set; }
        /// <summary>Indicates if the camera is currently active.</summary>
		public bool IsActive { get; set; }
		/// <summary>The URL of the camera owner.</summary>
		public string OwnerUrl { get; set; }
		/// <summary>The WSDOT region where the camera is located.</summary>
		public string Region { get; set; }
		/// <summary>A value that can be used to sort <see cref="Camera"/> objects.</summary>
		public int SortOrder { get; set; }
		/// <summary>The title of the camera.</summary>
		public string Title { get; set; }

	}
}