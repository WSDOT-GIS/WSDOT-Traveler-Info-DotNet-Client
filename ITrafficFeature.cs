using System.Collections.Generic;
using TravelerInfoMapServices;

namespace Wsdot.Traffic
{
	/// <summary>
	/// Provides a common reference point for the features of the Traveler API represented by auto-generated classes.
	/// </summary>
	public interface ITrafficFeature
	{
		Feature ToFeature(bool includeSpatialReference=false, int? outSR=null);
	}
}