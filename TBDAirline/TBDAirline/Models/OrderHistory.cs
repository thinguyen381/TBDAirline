namespace TBDAirline.Models
{
    public class OrderHistory
    {
        /// <summary>
        /// OrderHistory collects necessary Order details for proper Account reports
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
