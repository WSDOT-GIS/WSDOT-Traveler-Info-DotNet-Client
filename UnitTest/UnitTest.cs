﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Wsdot.Traffic;
using Wsdot.Traffic.Client;

namespace UnitTest
{
	[TestClass]
	public partial class UnitTest
	{
		public TestContext TestContext { get; set; }

		TrafficClient _trafficClient;

		[TestInitialize]
		public void TestInit()
		{
			_trafficClient = new TrafficClient { AccessCode = accessCode };

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
			_trafficClient.GetCommercialVehicleRestrictions().ContinueWith(task =>
			{
				cvrs = task.Result;
			}).Wait();

			TestArrays(cvrs);
		}

		[TestMethod]
		public void TestAlerts()
		{
			Alert[] alerts = null;
			
			_trafficClient.GetAlerts().ContinueWith(task =>
			{
				alerts = task.Result;
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
	}
}