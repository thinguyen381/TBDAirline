namespace TBDAirline.Models
{
    ///<summary>
    /// Collects information on Reservations collected for a flight.
    /// </summary>
    public class Report
    {
  
        public List<Passenger> Passengers { get; set; }
        public int FlightID { get; set; }
        public Flight Flight { get; set; }
        public Airport FromAirport { get; set; }
        public Airport ToAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Error { get; set; } 
    }
}
