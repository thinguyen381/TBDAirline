namespace TBDAirline.Models
{
    ///<summary>
    /// Holds security information for Customers.
    /// Admin have additional privilege of creating flights, reservations, and reports
    ///</summary>
    public class Account
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
