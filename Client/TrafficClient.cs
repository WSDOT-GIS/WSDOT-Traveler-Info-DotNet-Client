using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wsdot.Traffic.Client
{
	public class TrafficClient
	{
		public string AccessCode { get; set; }

		const string defaultApiRoot = "http://www.wsdot.wa.gov/Traffic/api";

		private string _apiRoot = defaultApiRoot;

		public string ApiRoot
		{
			get { return _apiRoot; }
			set { _apiRoot = value; }
		}

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

		public async Task<BorderCrossingData[]> GetBorderCrossings()
		{
			const string urlFmt = "{0}/BorderCrossings/BorderCrossingsREST.svc/GetBorderCrossingsAsJson?AccessCode={1}";
			return await DoRequest<BorderCrossingData[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<CVRestriction[]> GetCommercialVehicleRestrictions()
		{
			const string urlFmt = "{0}/CVRestrictions/CVRestrictionsREST.svc/GetCommercialVehicleRestrictionsAsJson?AccessCode={1}";
			return await DoRequest<CVRestriction[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<Alert[]> GetAlerts()
		{
			const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/GetAlertsAsJson?AccessCode={1}";
			return await DoRequest<Alert[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<Alert> GetAlert(int alertId)
		{
			const string urlFmt = "{0}/HighwayAlerts/HighwayAlertsREST.svc/GetAlertAsJson?AccessCode={1}&AlertID={2}";
			return await DoRequest<Alert>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, alertId));
		}

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

		public async Task<Camera[]> GetCameras()
		{
			const string urlFmt = "{0}/HighwayCameras/HighwayCamerasREST.svc/GetCamerasAsJson?AccessCode={1}";
			return await DoRequest<Camera[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<Camera> GetCamera(int cameraId)
		{
			const string urlFmt = "{0}/HighwayCameras/HighwayCamerasREST.svc/GetCameraAsJson?AccessCode={1}&CameraID={2}";
			return await DoRequest<Camera>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, cameraId));
		}

		public async Task<PassCondition[]> GetMountainPassConditions()
		{
			const string urlFmt = "{0}/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionsAsJson?AccessCode={1}";
			return await DoRequest<PassCondition[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<PassCondition> GetMountainPassCondition(int passConditionId)
		{
			const string urlFmt = "{0}/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode={1}&PassConditionID={2}";
			return await DoRequest<PassCondition>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, passConditionId));
		}

		public async Task<FlowData[]> GetTrafficFlows()
		{
			const string urlFmt = "{0}/TrafficFlow/TrafficFlowREST.svc/GetTrafficFlowsAsJson?AccessCode={1}";
			return await DoRequest<FlowData[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<FlowData> GetTrafficFlow(int flowDataId)
		{
			const string urlFmt = "{0}/TrafficFlow/TrafficFlowREST.svc/GetTrafficFlowAsJson?AccessCode={1}&FlowDataID={2}";
			return await DoRequest<FlowData>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, flowDataId));
		}

		public async Task<TravelTimeRoute[]> GetTravelTimes()
		{
			const string urlFmt = "{0}/TravelTimes/TravelTimesREST.svc/GetTravelTimesAsJson?AccessCode={1}";
			return await DoRequest<TravelTimeRoute[]>(string.Format(urlFmt, this.ApiRoot, this.AccessCode));
		}

		public async Task<TravelTimeRoute> GetTravelTime(int travelTimeId)
		{
			const string urlFmt = "{0}/TravelTimes/TravelTimesREST.svc/GetTravelTimeAsJson?AccessCode={1}&TravelTimeID={2}";
			return await DoRequest<TravelTimeRoute>(string.Format(urlFmt, this.ApiRoot, this.AccessCode, travelTimeId));
		}
	}
}
