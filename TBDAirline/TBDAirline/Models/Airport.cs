namespace TBDAirline.Models
{
    /// <summary>
    /// Airport is a complex data type holds a single ID and name.
    /// Airports can act as take off and destination points 
    /// </summary>
    public class Airport
    {
        public int AirportID { get; set; }  
        public string AirportName { get; set; }

    }
}
