namespace TBDAirline.Models
{
    ///<summary>
    /// Holds security information for Customers.
    /// Admin have additional privlage of creating filghts and reservations
    ///</summary>
    public class Account
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
