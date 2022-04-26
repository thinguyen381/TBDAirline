namespace TBDAirline.Models
{
    /// <summary>
    /// Passenger contains all impoirtant information pertaining to a passenger
    /// Used in booking and reports.
    /// </summary>
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string PassengerName { get; set; }
        public string Email { get; set;}
        public string PhoneNumber { get; set; }
    }
}
