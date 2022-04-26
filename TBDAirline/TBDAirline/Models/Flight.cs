namespace TBDAirline.Models
{
    /// <summary>
    /// Flight contains all the important attributes related a flight.
    /// Flight is used in conjuntion with other data types to construct a reservation in Book
    /// </summary>
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
