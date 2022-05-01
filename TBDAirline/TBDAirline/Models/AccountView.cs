namespace TBDAirline.Models
{
    /// <summary>
    /// Collects and holds information for the creation of a new account.
    /// </summary>
    public class AccountView
    {
        public Account Account { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
    }
}
