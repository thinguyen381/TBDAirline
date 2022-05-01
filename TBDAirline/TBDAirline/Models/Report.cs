namespace TBDAirline.Models
{
    ///<summary>
    /// Collects information on Reservations collected for a flight.
    /// </summary>
    public class Report
    {
  
        public List<Passenger> Passengers { get; set; }
        public int FlightID { get; set; }
        public bool isReservationCanceled { get; set; }
    }
}
