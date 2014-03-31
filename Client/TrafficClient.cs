using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wsdot.Traffic.Client
{
	/// <summary>
	/// A client for <see href="http://www.wsdot.wa.gov/Traffic/api/">the WSDOT Traveler Information API</see>.
	/// </summary>
	public class TrafficClient
	{
		/// <summary>
		/// The <see href="http://www.wsdot.wa.gov/Traffic/api/">Traffic API Access Code</see> that will be used for querying the API.
		/// </summary>
		public string AccessCode { get; set; }

		const string _defaultApiRoot = "http://www.wsdot.wa.gov/Traffic/api";

		private string _apiRoot = _defaultApiRoot;

		/// <summary>
		/// Gets or sets the API root URL. You would only need to change this if the API is moved.
		/// </summary>
		public string ApiRoot
		{
			get { return _apiRoot; }
			set { _apiRoot = value; }
		}

		/// <summary>
		/// Performs an HTTP request and serializes the response to a specific type.
		/// </summary>
		/// <typeparam name="T">The output type.</typeparam>
		/// <param name="url">The URL of the HTTP request.</param>
		/// <returns>Returns an object of type <typeparamref name="T"/>.</returns>
		private async Task<T> DoRequest<T>(string url)
		{
			T output;
			using (var client = new HttpClient())
			using (var stream = await client.GetStreamAsync(url))
			using (var streamReader = new StreamReader(stream))
			using (var jsonReader = new JsonTextReader(streamReader))
			{
				var serializer = new JsonSerializer();
				output = serializer.Deserialize<T>(jsonReader);
			}
			return output;
		}



		/// <summary>
		/// Retrieve an array of current wait times for the various border crossings into Canada. The current wait length is in minutes. 
		/// </summary>
		/// <returns>An array of <see cref="BorderCrossingData"/> objects.</returns>
		/// <remarks>Coverage Area: I-5, SR-543, SR-539, and SR-9 crossings. Provides current wait times for the various border crossings into Canada.</remarks>
		public async Task<BorderCrossingData[]> GetBorderCrossings()
		{
			const string urlFmt = "{0}/BorderCrossings/BorderCrossingsREST.svc/GetBorderCrossingsAsJson?AccessCode={1}";
			return await DoRequest<BorderCrossingData[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Get a complete list of all current commercial vehicle restrictions on WA State highways. 
		/// </summary>
		/// <returns>Returns a complete list of all current commercial vehicle restrictions on WA State highways.</returns>
		public async Task<CVRestriction[]> GetCommercialVehicleRestrictions()
		{
			const string urlFmt = "{0}/CVRestrictions/CVRestrictionsREST.svc/GetCommercialVehicleRestrictionsAsJson?AccessCode={1}";
			return await DoRequest<CVRestriction[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Retrieves an array of currently active incidents currently logged in our ROADS system.
		/// </summary>
		/// <returns>An array of currently active incidents.</returns>
		public async Task<Alert[]> GetAlerts()
		{
			const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/GetAlertsAsJson?AccessCode={1}";
			return await DoRequest<Alert[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Retrieves a specific incident. 
		/// </summary>
		/// <param name="alertId">AlertID for a specific incident</param>
		/// <returns>An <see cref="Alert"/>.</returns>
		public async Task<Alert> GetAlert(int alertId)
		{
			const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/GetAlertAsJson?AccessCode={1}&AlertID={2}";
			return await DoRequest<Alert>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, alertId));
		}

		/// <summary>
		/// Selects an array of valid categories to use with the SearchAlerts endpoint..
		/// </summary>
		/// <returns>An array of event categories.</returns>
		public async Task<string[]> GetAlertEventCategories()
		{
			const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/GetEventCategoriesAsJson";
			return await DoRequest<string[]>(string.Format(urlFmt, this.ApiRoot));
		}

		/////// <summary>
		/////// Retrieves an array of incidents that match certain criteria. 
		/////// </summary>
		/////// <param name="stateRoute">Optional. A State Route formatted as a three digit number. I-5 would be 005.</param>
		/////// <param name="region">Optional. Either NC, SC, SW, NW, OL, ER or HQ</param>
		/////// <param name="searchTimeStart">Optional. Will only find alerts occuring after this time.</param>
		/////// <param name="searchTimeEnd">Optional. Will only find alerts occuring before this time. </param>
		/////// <param name="startingMilepost">Optional. Will only find alerts after this milepost. </param>
		/////// <param name="endingMilepost">Optional. Will only find alerts before this milepost. </param>
		/////// <returns></returns>
		////public async Task<Alert[]> SearchAlerts(string stateRoute=null, string region=null, 
		////	DateTime? searchTimeStart=null, DateTime? searchTimeEnd=null, 
		////	decimal? startingMilepost=null, decimal? endingMilepost=null)
		////{
		////	////const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/SearchAlertsAsJson?AccessCode={1}&StateRoute={2}&Region={3}&SearchTimeStart={4}&SearchTimeEnd={5}&StartingMilepost={6}&EndingMilepost={7}";

		////	var paramDict = new Dictionary<string, object>(7);
		////	paramDict.Add("AccessCode", AccessCode);
		////	if (string.IsNullOrWhiteSpace(stateRoute))
		////	{
		////		paramDict.Add("StateRoute", stateRoute);
		////	}
		////	if (string.IsNullOrWhiteSpace(region))
		////	{
		////		paramDict.Add("Region", region);
		////	}
		////	if (searchTimeStart.HasValue) {
		////		paramDict.Add("SearchTimeStart", searchTimeStart.Value);
		////	}
		////	if (searchTimeEnd.HasValue)
		////	{
		////		paramDict.Add("SearchTimeEnd", searchTimeEnd.Value);
		////	}
		////	if (startingMilepost.HasValue)
		////	{
		////		paramDict.Add("StartingMilepost", startingMilepost.Value);
		////	}
		////	if (endingMilepost.HasValue)
		////	{
		////		paramDict.Add("EndingMilepost", endingMilepost.Value);
		////	}

		////	UriBuilder urlBuilder = new UriBuilder(string.Format("{0}/HighwayAlerts/HighwayAlertsREST.svc/SearchAlertsAsJson", ApiRoot));
		////	var query = string.Join("&", paramDict.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)).ToArray());
		////	urlBuilder.Query = query;

		////	return await DoRequest<Alert[]>(urlBuilder.Uri.ToString());
		////}

		/// <summary>
		/// Retrieves all Traffic Cameras. 
		/// </summary>
		/// <returns>An array of cameras.</returns>
		/// <remarks>Coverage Area: Statewide. Provides access to the camera images that appear on our Traffic pages. Currently only supports snap shots (not full video).</remarks>
		public async Task<Camera[]> GetCameras()
		{
			const string urlFmt = "{0}/HighwayCameras/HighwayCamerasREST.svc/GetCamerasAsJson?AccessCode={1}";
			return await DoRequest<Camera[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Returns a single specific camera. 
		/// </summary>
		/// <param name="cameraId">The unique identifier of a camera.</param>
		/// <returns>A <see cref="Camera"/>.</returns>
		public async Task<Camera> GetCamera(int cameraId)
		{
			const string urlFmt = "{0}/HighwayCameras/HighwayCamerasREST.svc/GetCameraAsJson?AccessCode={1}&CameraID={2}";
			return await DoRequest<Camera>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, cameraId));
		}

		/// <summary>
		/// Retrieves all pass condition reports. 
		/// </summary>
		/// <returns></returns>
		/// <remarks>Coverage Area: 15 passes <see href="http://www.wsdot.wa.gov/traffic/passes/"/>. Provides real-time data on pass conditions. The data is provided by the Mountain Pass Entry system. </remarks>
		public async Task<PassCondition[]> GetMountainPassConditions()
		{
			const string urlFmt = "{0}/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionsAsJson?AccessCode={1}";
			return await DoRequest<PassCondition[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Retrive a specific <see cref="PassCondition"/>.
		/// </summary>
		/// <param name="passConditionId">A ID for a specific pass condition report.</param>
		/// <returns>A <see cref="PassCondition"/></returns>
		/// <remarks>Coverage Area: 15 passes <see href="http://www.wsdot.wa.gov/traffic/passes/"/>. Provides real-time data on pass conditions. The data is provided by the Mountain Pass Entry system. </remarks>
		public async Task<PassCondition> GetMountainPassCondition(int passConditionId)
		{
			const string urlFmt = "{0}/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode={1}&PassConditionID={2}";
			return await DoRequest<PassCondition>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, passConditionId));
		}

		/// <summary>
		/// Retrieves an array containing all traffic flow data. 
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <para>Coverage Area: Vancouver, Olympia, Tacoma, Seattle, Spokane. Data is provided by regional Traffic Management Centers.</para>
		/// <para>Provides real-time data on our Traffic Flow sensor for the entire state.</para>
		/// <para>Possible conditions include ‘Unknown’, ‘WideOpen’, ‘Moderate’, ‘Heavy’, ‘StopAndGo’, ‘NoData’.</para>
		/// <para>In most cases, this data will be updated every 90 seconds.</para>
		/// </remarks>
		public async Task<FlowData[]> GetTrafficFlows()
		{
			const string urlFmt = "{0}/TrafficFlow/TrafficFlowREST.svc/GetTrafficFlowsAsJson?AccessCode={1}";
			return await DoRequest<FlowData[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Retrieve the current condition for a specific traffic flow station. 
		/// </summary>
		/// <param name="flowDataId">The ID of the station for which you wish to retrieve data.</param>
		/// <returns>Data for a specific traffic flow station</returns>
		/// <remarks>
		/// Coverage Area: Vancouver, Olympia, Tacoma, Seattle, Spokane. Data is provided by regional Traffic Management Centers. 
		/// Provides real-time data on our Traffic Flow sensor for the entire state. 
		/// Possible conditions include ‘Unknown’, ‘WideOpen’, ‘Moderate’, ‘Heavy’, ‘StopAndGo’, ‘NoData’. 
		/// In most cases, this data will be updated every 90 seconds.
		/// </remarks>
		public async Task<FlowData> GetTrafficFlow(int flowDataId)
		{
			const string urlFmt = "{0}/TrafficFlow/TrafficFlowREST.svc/GetTrafficFlowAsJson?AccessCode={1}&FlowDataID={2}";
			return await DoRequest<FlowData>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, flowDataId));
		}

		/// <summary>
		/// Retrieves an array of <see cref="TravelTimeRoute"/> objects containing all of the current travel times. 
		/// </summary>
		/// <returns>Returns an array of <see cref="TravelTimeRoute"/> objects containing all of the current travel times.</returns>
		/// <remarks>Coverage Area: Seattle, Tacoma, Snoqualmie Pass. Provides travel times for many popular travel routes around Washington State. </remarks>
		public async Task<TravelTimeRoute[]> GetTravelTimes()
		{
			const string urlFmt = "{0}/TravelTimes/TravelTimesREST.svc/GetTravelTimesAsJson?AccessCode={1}";
			return await DoRequest<TravelTimeRoute[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		/// <summary>
		/// Retrieves a <see cref="TravelTimeRoute"/> for a specific <see cref="TravelTimeRoute.TravelTimeID"/>. 
		/// </summary>
		/// <param name="travelTimeId">ID of a specific Travel Time Route to retrieve.</param>
		/// <returns></returns>
		/// <remarks>Coverage Area: Seattle, Tacoma, Snoqualmie Pass. Provides travel times for many popular travel routes around Washington State. </remarks>
		public async Task<TravelTimeRoute> GetTravelTime(int travelTimeId)
		{
			const string urlFmt = "{0}/TravelTimes/TravelTimesREST.svc/GetTravelTimeAsJson?AccessCode={1}&TravelTimeID={2}";
			return await DoRequest<TravelTimeRoute>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, travelTimeId));
		}
	}
}
