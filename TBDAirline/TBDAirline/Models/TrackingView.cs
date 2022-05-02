namespace TBDAirline.Models
{
    /// <summary>
    /// Tracks a users flight reservation.
    /// </summary>
    public class TrackingView
    {
        public Flight DepartureFlight { get; set; }
        public Flight ReturnFlight { get; set; }
        public Guid TrackingID { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public Passenger Passenger { get; set; }   
        public Payment Payment { get; set; }   
        public bool IsCanceled { get; set; }
    }
}