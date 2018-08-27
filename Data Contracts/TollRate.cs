namespace Wsdot.Traffic.Contracts
{
    public class TollRate
    {
        string SignName { get; set; }


        public string TripName { get; set; }


        public int CurrentToll { get; set; }


        public string CurrentMessage { get; set; }


        public string StateRoute { get; set; }


        public string TravelDirection { get; set; }


        public decimal StartMilepost { get; set; }


        public string StartLocationName { get; set; }


        public decimal StartLatitude { get; set; }


        public decimal StartLongitude { get; set; }


        public decimal EndMilepost { get; set; }


        public string EndLocationName { get; set; }


        public decimal EndLatitude { get; set; }


        public decimal EndLongitude { get; set; }
    }
}
