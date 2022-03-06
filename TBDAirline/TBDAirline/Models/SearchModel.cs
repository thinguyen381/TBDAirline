using System.ComponentModel.DataAnnotations;

namespace TBDAirline.Models
{
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
    }
}
