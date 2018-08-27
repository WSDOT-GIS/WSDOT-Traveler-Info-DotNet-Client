using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wsdot.Traffic;
using Wsdot.Traffic.Client;
using WsdotTravelerInfoContracts.Ferries.Terminals;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
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
        public async Task TestBorderCrossings()
        {
            BorderCrossingData[] bcs = await _trafficClient.GetBorderCrossings();
            TestArrays(bcs);
        }

        [TestMethod]
        public async Task TestCVRestrictions()
        {
            CVRestriction[] cvrs = await _trafficClient.GetCommercialVehicleRestrictions(true);
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
        public async Task TestAlerts()
        {
            Alert[] alerts = await _trafficClient.GetAlerts(true);
            TestArrays(alerts);

            var alert = await _trafficClient.GetAlert(alerts.First().AlertID);
            Assert.IsNotNull(alert);

            var categories = await _trafficClient.GetAlertEventCategories();
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Length > 0);
            CollectionAssert.AllItemsAreNotNull(categories);
            CollectionAssert.AllItemsAreUnique(categories);
        }

        [TestMethod]
        public async Task TestCameras()
        {
            Camera[] cameras = await _trafficClient.GetCameras();
            TestArrays(cameras);
            var camera = await _trafficClient.GetCamera(cameras.First().CameraID);
            Assert.IsNotNull(camera);
        }

        [TestMethod]
        public async Task TestMountainPasses()
        {
            PassCondition[] conditions = await _trafficClient.GetMountainPassConditions();
            TestArrays(conditions);
            var condition = await _trafficClient.GetMountainPassCondition(conditions.First().MountainPassId);
            Assert.IsNotNull(condition);
        }

        [TestMethod]
        public async Task TestTrafficFlows()
        {
            FlowData[] flows = await _trafficClient.GetTrafficFlows();
            var flow = await _trafficClient.GetTrafficFlow(flows.First().FlowDataID);
            Assert.IsNotNull(flow);
        }

        [TestMethod]
        public async Task TestTravelTimes()
        {
            TravelTimeRoute[] travelTimes = await _trafficClient.GetTravelTimes();
            TestArrays(travelTimes);
            var tTime = _trafficClient.GetTravelTime(travelTimes.First().TravelTimeID);
            Assert.IsNotNull(tTime);
        }

        private void TestArrays(Array arr)
        {
            Assert.IsNotNull(arr);
            Assert.IsTrue(arr.Length > 0);
        }

        #region WSF Tests

        [TestMethod]
        public async Task TestCacheFlushDate()
        {
            DateTimeOffset cacheFlushDate = await _wsfClient.GetCacheFlushDate();
            TestContext.WriteLine("Cache Flush Date: {0}", cacheFlushDate);
            Assert.IsTrue(cacheFlushDate > default(DateTimeOffset));
        }

        [TestMethod]
        public async Task TestWsfQueries()
        {
            var queryTypes = Enum.GetValues(typeof(TerminalQueryType));

            foreach (TerminalQueryType qt in queryTypes)
            {
                TestContext.WriteLine("Performing test on {0}...", qt);
                var terminals = await _wsfClient.Query<Terminal[]>(qt);
                Assert.IsNotNull(terminals);
                Assert.IsTrue(terminals.Length > 0);

                var terminal = await _wsfClient.Query(qt, terminals.First().TerminalID);
                Assert.IsNotNull(terminal);
                TestContext.WriteLine("Completed test on {0}...", qt);
            }
        }

        #endregion
    }
}
