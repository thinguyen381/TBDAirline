namespace TBDAirline.Models
{
    /// <summary>
    /// Reservation contains all information reguarding an account owned reservation.
    /// </summary>
    public class Reservation
    {
        public int ReservationID { get; set; }
        public Guid? TrackingID { get; set; }
        public int? PaymentID { get; set; }
        public int? DepartFlightID { get; set; }
        public int? ReturnFlightID { get; set; }
        public int? AccountID { get; set; }
        public int? PassengerID { get; set; }
        public bool? isCanceled { get; set; }
    }
}
