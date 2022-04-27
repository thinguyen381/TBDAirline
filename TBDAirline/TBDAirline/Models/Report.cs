namespace TBDAirline.Models
{
    public class Report
    {
  
        public List<Passenger> Passengers { get; set; }
        public int FlightID { get; set; }
        public bool isReservationCanceled { get; set; }
    }
}
