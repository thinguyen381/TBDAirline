namespace TBDAirline.Models
{
    /// <summary>
    /// Error View Model is used to redirect user to an error screen
    /// in the case of a fatal error.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}