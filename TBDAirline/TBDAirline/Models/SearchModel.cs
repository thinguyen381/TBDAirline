using System.ComponentModel.DataAnnotations;

namespace TBDAirline.Models
{
    /// <summary>
    /// Search Model is used to search for flights and reservations within the database.
    /// </summary>
    public class SearchModel
    {
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
        
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public List<string> Cities { get; set; }
        public List<Flight> DepartureFlight { get; set; }
        public List<Flight> ReturnFlight { get; set; }

        public bool IsRoundTrip { get; set; }
        public bool isError { get; set; }
    }
}
