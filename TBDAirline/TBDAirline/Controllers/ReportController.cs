using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary> Displays view of class Report </summary>
        /// <returns> View() </returns>
        [HttpGet]
        public IActionResult Index()
        {
             return View();
        }

        /// <summary>
        /// Creates a report and returns the View of created report.
        /// </summary>
        /// <param name="int"></param>
        /// <returns>View()</returns>
        [HttpPost]
        public IActionResult Index(int FlightID)
        {
          
            var flightParam = new SqlParameter("@FlightID", FlightID);
            List<Passenger> passengers = _context
            .Passenger
            .FromSqlRaw("exec project1..GetPassengersUseFlightID @FlightID", flightParam)
            .ToList();

            Report report = new Report();
            report.Passengers = passengers;

            return View(report);
        }
    }
}
