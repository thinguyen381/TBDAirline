namespace TBDAirline.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public int FromID {get; set; }
        public int ToID { get; set; }
        public string Duration { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
