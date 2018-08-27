using System;
using System.Collections.Generic;

namespace Wsdot.Traffic.Contracts
{
    public class WeatherReading
    {
        public string StationId { get; set; }


        public string StationName { get; set; }


        public decimal Latitude { get; set; }


        public decimal Longitude { get; set; }


        public int Elevation { get; set; }


        public DateTime ReadingTime { get; set; }


        public decimal AirTemperature { get; set; }


        public byte RelativeHumidty { get; set; }


        public byte AverageWindSpeed { get; set; }


        public short AverageWindDirection { get; set; }


        public byte WindGust { get; set; }


        public short Visibility { get; set; }


        public byte PrecipitationIntensity { get; set; }


        public byte PrecipitationType { get; set; }


        public decimal PrecipitationPast1Hour { get; set; }


        public decimal PrecipitationPast3Hours { get; set; }


        public decimal PrecipitationPast6Hours { get; set; }


        public decimal PrecipitationPast12Hours { get; set; }


        public decimal PrecipitationPast24Hours { get; set; }


        public decimal PrecipitationAccumulation { get; set; }


        public int BarometricPressure { get; set; }


        public int SnowDepth { get; set; }


        public List<ScanwebSurfaceMeasurements> SurfaceMeasurements { get; set; }


        public List<ScanwebSubSurfaceMeasurements> SubSurfaceMeasurements { get; set; }
    }

    public class ScanwebSurfaceMeasurements
    {
        public byte SensorId { get; set; }


        public decimal SurfaceTemperature { get; set; }


        public decimal RoadFreezingTemperature { get; set; }


        public int RoadSurfaceCondition { get; set; }
    }

    public class ScanwebSubSurfaceMeasurements
    {
        public byte SensorId { get; set; }


        public decimal SubSurfaceTemperature { get; set; }
    }
}
