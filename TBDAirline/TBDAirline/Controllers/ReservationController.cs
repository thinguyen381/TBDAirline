using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;
using TBDAirline.UseCase;

namespace TBDAirline.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Index creates a reservation and adds it to the database.
        /// </summary>
        ///<returns>
        ///View
        ///</returns>
        public IActionResult Index()
        {
            Passenger newPassenger = new Passenger
            {
                PassengerName = this.HttpContext.Session.GetString("PassengerName"),
                Email = this.HttpContext.Session.GetString("Email"),
                PhoneNumber = this.HttpContext.Session.GetString("PhoneNumber"),
            };
            _context.Add(newPassenger);
            _context.SaveChanges();
            int passengerID = newPassenger.PassengerID;


            int? accountID = null;
            if (this.User.Identity.IsAuthenticated && int.TryParse(this.User.Claims.Where(c => c.Type == "AccountID").FirstOrDefault()?.Value, out int a))
            {
                accountID = a;
            }


            // Create tracking number
            var trackingID = Guid.NewGuid();

            Reservation newReservation = new Reservation()
            {
                TrackingID = trackingID,
                PassengerID = passengerID,
                PaymentID = this.HttpContext.Session.GetInt32("PaymentID"),
                DepartFlightID = this.HttpContext.Session.GetInt32("DepartFlightID"),
                ReturnFlightID = this.HttpContext.Session.GetInt32("ReturnFlightID"),
                AccountID = accountID,
                isCanceled = false

            };
            _context.Add(newReservation);
            _context.SaveChanges();

            List<string> emails = new List<string>();
            emails.Add(newPassenger.Email);
            //EmailHandler emailUseCase = new EmailHandler();
            EmailHandler.SendEmail(emails, trackingID);


            ReservationView newReservationView = new ReservationView();
            newReservationView.Reservation = newReservation;
            return View(newReservationView);
        }
    }
}
