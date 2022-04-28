namespace TBDAirline.Models
{
    public class OrderDetail
    {
        public Reservation Reservation { get; set; }
        public Airport FromAirport { get; set; }
        public Airport ToAirport { get; set; }
        public Flight DepartFlight { get; set; }
        public Flight ReturnFlight { get; set; }
        public Passenger Passenger { get; set; }

        public Payment Payment { get; set; }
    }
}
