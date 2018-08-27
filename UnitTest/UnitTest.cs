using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wsdot.Traffic;
using Wsdot.Traffic.Client;
using WsdotTravelerInfoContracts.Ferries.Terminals;

namespace UnitTest
{
	[TestClass]
	public partial class UnitTest
	{
		public TestContext TestContext { get; set; }

		TrafficClient _trafficClient;
		WsfClient _wsfClient;

		[TestInitialize]
		public void TestInit()
		{
			const string apiCodeEnvVarName = "WSDOT_TRAFFIC_API_CODE";
			string accessCode = Environment.GetEnvironmentVariable(apiCodeEnvVarName);
			if (string.IsNullOrWhiteSpace(accessCode)) {
				throw new Exception(string.Format("Environment variable {0} is not defined.", apiCodeEnvVarName));
			}
			_trafficClient = new TrafficClient { AccessCode = accessCode };
			_wsfClient = new WsfClient { AccessCode = accessCode };
		}

		[TestMethod]
		public void TestBorderCrossings()
		{
			BorderCrossingData[] bcs = null;
			_trafficClient.GetBorderCrossings().ContinueWith(task =>
			{
				bcs = task.Result;
			}).Wait();

			TestArrays(bcs);
		}

		[TestMethod]
		public void TestCVRestrictions()
		{
			CVRestriction[] cvrs = null;
			_trafficClient.GetCommercialVehicleRestrictions(true).ContinueWith(task =>
			{
				cvrs = task.Result;
			}).Wait();

			TestArrays(cvrs);
		}

		////bool LineSegmentIsValid(ILineSegment lineSegment)
		////{
		////	bool output = true;
		////	if (lineSegment.Line != null)
		////	{
		////		foreach (var linestring in lineSegment.Line)
		////		{
		////			foreach (var point in linestring)
		////			{
		////				if (point.Length < 2)
		////				{
		////					output = false;
		////					break;
		////				}
		////			}
		////		}
		////	}
		////	return output;
		////}

		////bool LineSegmentsAreValid<T>(IEnumerable<T> lineSegments) where T : ILineSegment
		////{
		////	bool output = true;
		////	foreach (ILineSegment item in lineSegments)
		////	{
		////		if (!LineSegmentIsValid(item))
		////		{
		////			output = false;
		////			break;
		////		}
		////	}
		////	return output;
		////}

		[TestMethod]
		public void TestAlerts()
		{
			Alert[] alerts = null;

			_trafficClient.GetAlerts(true).ContinueWith(task =>
			{
				alerts = task.Result;
				////Assert.IsTrue(LineSegmentsAreValid(alerts));
			}).Wait();

			TestArrays(alerts);

			_trafficClient.GetAlert(alerts.First().AlertID).ContinueWith(task =>
			{
				var alert = task.Result;
				Assert.IsNotNull(alert);
			}).Wait();

			_trafficClient.GetAlertEventCategories().ContinueWith(task => {
				var categories = task.Result;
				Assert.IsNotNull(categories);
				Assert.IsTrue(categories.Length > 0);
				CollectionAssert.AllItemsAreNotNull(categories);
				CollectionAssert.AllItemsAreUnique(categories);
			}).Wait();
		}

		[TestMethod]
		public void TestCameras()
		{
			Camera[] cameras = null;
			_trafficClient.GetCameras().ContinueWith(task => {
				cameras = task.Result;
			}).Wait();
			TestArrays(cameras);
			_trafficClient.GetCamera(cameras.First().CameraID).ContinueWith(task => {
				Assert.IsNotNull(task.Result);
			});
		}

		[TestMethod]
		public void TestMountainPasses()
		{
			PassCondition[] conditions = null;
			_trafficClient.GetMountainPassConditions().ContinueWith(task => {
				conditions = task.Result;
			}).Wait();
			TestArrays(conditions);
			_trafficClient.GetMountainPassCondition(conditions.First().MountainPassId).ContinueWith(t =>
			{
				Assert.IsNotNull(t.Result);
			}).Wait();
		}

		[TestMethod]
		public void TestTrafficFlows()
		{
			FlowData[] flows = null;
			_trafficClient.GetTrafficFlows().ContinueWith(t => {
				flows = t.Result;
			}).Wait();
			TestArrays(flows);
			_trafficClient.GetTrafficFlow(flows.First().FlowDataID).ContinueWith(t => {
				Assert.IsNotNull(t.Result);
			}).Wait();
		}

		[TestMethod]
		public void TestTravelTimes()
		{
			TravelTimeRoute[] travelTimes = null;
			_trafficClient.GetTravelTimes().ContinueWith(t => {
				travelTimes = t.Result;
			}).Wait();
			TestArrays(travelTimes);
			_trafficClient.GetTravelTime(travelTimes.First().TravelTimeID).ContinueWith(t => {
				Assert.IsNotNull(t.Result);
			}).Wait();
		}

		private void TestArrays(Array arr)
		{
			Assert.IsNotNull(arr);
			Assert.IsTrue(arr.Length > 0);
		}

		#region WSF Tests

		[TestMethod]
		public void TestCacheFlushDate()
		{
			DateTimeOffset cacheFlushDate;
			_wsfClient.GetCacheFlushDate().ContinueWith(t => {
				cacheFlushDate = t.Result;
				TestContext.WriteLine("Cache Flush Date: {0}", cacheFlushDate);
			}).Wait();

		}

		[TestMethod]
		public void TestWsfQueries()
		{
			var queryTypes = Enum.GetValues(typeof(TerminalQueryType));

			foreach (TerminalQueryType qt in queryTypes)
			{
				TestContext.WriteLine("Performing test on {0}...", qt);
				var task = _wsfClient.Query<Terminal[]>(qt);
				task.Wait();
				Terminal[] terminals = task.Result;
				Assert.IsNotNull(terminals);
				Assert.IsTrue(terminals.Length > 0);

				var task2 = _wsfClient.Query(qt, terminals.First().TerminalID);
				task2.Wait();
				Terminal terminal = task2.Result;
				Assert.IsNotNull(terminal);
				TestContext.WriteLine("Completed test on {0}...", qt);
			}
		}

		#endregion
	}
}
