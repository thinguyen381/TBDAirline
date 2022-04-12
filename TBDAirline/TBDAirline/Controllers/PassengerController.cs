using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class PassengerController : Controller
    {

        private ApplicationDbContext _context;
        public PassengerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(PassengerView PassengerView)
        {
            if (PassengerView != null && PassengerView.Passenger != null)
            {
                HttpContext.Session.SetString("PassengerName", PassengerView.Passenger.PassengerName);
                HttpContext.Session.SetString("Email", PassengerView.Passenger.Email);
                HttpContext.Session.SetString("PhoneNumber", PassengerView.Passenger.PhoneNumber);
                return RedirectToAction("Index", "Payment");
            }
            else return View();
        }
    }
}
