namespace TBDAirline.Models
{
    /// <summary>
    /// OrderDetail collects necessary information for proper Account reports
    /// </summary>
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
