namespace TBDAirline.Models
{
    public class Book
    {
        public Flight DepartFlight { get; set; }
        public Flight ReturnFlight { get; set; }
        public decimal? TotalAmount { get; set; }

        public string FromCity { get; set; }
        public string ToCity { get; set; }
    }
}
