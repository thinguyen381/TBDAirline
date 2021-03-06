using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Index Creates a booking using two provided flights and adds it to the database
        /// </summary>
        /// <param name="DepartFlightID"></param>
        /// <param name="ReturnFlightID"></param>
        /// <returns>View()</returns>
        public IActionResult Index(int? DepartFlightID, int? ReturnFlightID)
        {
            

            Flight departFlight = DepartFlightID != null ? _context.Flight.First(f => f.FlightID == DepartFlightID) : null;
            Flight returnFlight = ReturnFlightID != null ? _context.Flight.First(f => f.FlightID == ReturnFlightID) : null;
            string fromCity = _context.Airport.Where(f => f.AirportID == departFlight.FromID).First().AirportName.ToString();
            string toCity = _context.Airport.Where(f => f.AirportID == departFlight.ToID).First().AirportName.ToString();


            Book book = new Book()
            {
                DepartFlight = departFlight,
                ReturnFlight = returnFlight,
                TotalAmount = (departFlight?.Price ?? 0) + (returnFlight?.Price ?? 0),
                FromCity = fromCity,
                ToCity = toCity,
            };

            return View(book);
        }
        /// <summary>
        /// LognAndBook redirects a user to the Login page and books the flight]       
        /// </summary>
        /// <param name="DepartFlightID"></param>
        /// <param name="ReturnFlightID"></param>
        /// <param name="TotalAmount"></param>
        /// <returns>View()</returns>
        public IActionResult LoginAndBook(int DepartFlightID, int ReturnFlightID, decimal TotalAmount)
        {
            HttpContext.Session.SetInt32("DepartFlightID", DepartFlightID);
            HttpContext.Session.SetInt32("ReturnFlightID", ReturnFlightID);
            HttpContext.Session.SetString("TotalAmount", TotalAmount.ToString());

            if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Index", "Passenger");
            else return RedirectToAction("Login", "Account");
        }
    }
}
