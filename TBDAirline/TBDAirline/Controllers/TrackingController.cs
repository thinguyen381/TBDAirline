using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class TrackingController : Controller
    {
        private ApplicationDbContext _context;
        public TrackingController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a tracking ID, attaches ID to flight reservations.
        /// </summary>
        /// <param name="Guid"></param>
        /// <return>View</return>
        public IActionResult Index(Guid? trackingID)
        {

            if (trackingID == null) return View();

            Reservation order = _context.Reservation.FirstOrDefault(o => o.TrackingID == trackingID);
            if (order == null) return View("NotFound");

            List<Airport> destinations = _context.Airport.ToList();

            Flight departFlight = _context.Flight.FirstOrDefault(f => f.FlightID == order.DepartFlightID);
            Flight returnFlight = _context.Flight.FirstOrDefault(f => f.FlightID == order.ReturnFlightID);


            TrackingView tracking = new TrackingView
            {
                TrackingID = (Guid)trackingID,
                DepartureFlight = departFlight,
                ReturnFlight = returnFlight,
                From = destinations.FirstOrDefault(d => d.AirportID == departFlight.FromID)?.AirportName,
                To = destinations.FirstOrDefault(d => d.AirportID == departFlight.ToID)?.AirportName,
                Payment = _context.Payment.Where(p => p.PaymentID == order.PaymentID).First(),
                Passenger = _context.Passenger.Where(p => p.PassengerID == order.PassengerID).First(),

            };

            return View(tracking);
        }
    }
}
