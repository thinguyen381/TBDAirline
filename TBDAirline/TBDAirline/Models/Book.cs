namespace TBDAirline.Models
{
    /// <summary>
    /// Book collects data types from the database to create reservations.
    /// To/From City attributes are obtained from Depart/Return flight information
    /// </summary>
    public class Book
    {
        public Flight DepartFlight { get; set; }
        public Flight ReturnFlight { get; set; }
        public decimal? TotalAmount { get; set; }

        public string FromCity { get; set; }
        public string ToCity { get; set; }
    }
}
