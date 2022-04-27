using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class OrderHistoryController : Controller
    {
        private ApplicationDbContext _context;
        public OrderHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            // retrieve accountID
            int? accountID = null;
            if (this.User.Identity.IsAuthenticated && int.TryParse(this.User.Claims.Where(c => c.Type == "AccountID").FirstOrDefault()?.Value, out int a))
            {
                accountID = a;
            }

            List<Reservation> reservations = _context.Reservation.Where(r => r.AccountID == accountID).ToList();
            OrderHistory orderHistory = new OrderHistory
            {
                OrderDetails = new List<OrderDetail>()
            };
                                    
            foreach (Reservation reservation in reservations)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.Reservation = reservation;
                orderDetail.Passenger = _context.Passenger.Where (p => p.PassengerID == reservation.PassengerID).FirstOrDefault();
                orderDetail.Payment = _context.Payment.Where (p => p.PaymentID == reservation.PaymentID).FirstOrDefault();
                orderDetail.DepartFlight = _context.Flight.Where(f => f.FlightID == reservation.DepartFlightID).FirstOrDefault();
                orderDetail.ReturnFlight = _context.Flight.Where(f => f.FlightID == reservation.ReturnFlightID).FirstOrDefault();
                orderDetail.FromAirport = _context.Airport.Where(a => a.AirportID == orderDetail.DepartFlight.FromID).FirstOrDefault();
                orderDetail.ToAirport = _context.Airport.Where(a => a.AirportID == orderDetail.DepartFlight.ToID).FirstOrDefault();
                
                orderHistory.OrderDetails.Add(orderDetail);
            }

            return View(orderHistory);
        }

        public IActionResult Cancel(int id)
        {
            Reservation reservation = _context.Reservation.Where(r => r.ReservationID == id).First();
            reservation.isCanceled = true;
            _context.SaveChanges();
            return RedirectToAction("Index","OrderHistory");
        }
    }
}
