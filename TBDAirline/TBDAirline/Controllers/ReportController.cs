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
            Report report = new Report();
            report.Flight = _context.Flight.Where(f => f.FlightID == FlightID).FirstOrDefault();
            if (report.Flight == null) { report.Error = "Invalid Flight ID"; } // No flight found
            else
            {
                // Get report with a list of passenger by entered FlightID using Stored Procedure (SQL server)
                var flightParam = new SqlParameter("@FlightID", FlightID);
                List<Passenger> passengers = _context
                .Passenger
                .FromSqlRaw("exec project1..GetPassengersUseFlightID @FlightID", flightParam)
                .ToList();
                report.Passengers = passengers;
                report.FromAirport = _context.Airport.Where(a => a.AirportID == report.Flight.FromID).FirstOrDefault();
                report.ToAirport = _context.Airport.Where(a => a.AirportID == report.Flight.ToID).FirstOrDefault();
            }

            return View(report);
        }
    }
}
/* Stored procedure used in SQL server
 use project1
go

--drop Procedure GetPassengersUseFlightID
Create Procedure GetPassengersUseFlightID
@FlightID int
AS



select * from Passenger p
where PassengerID in
    (select PassengerID from Reservation
        where ((DepartFlightID = @FlightID
            or ReturnFlightID = @FlightID)
            and isCanceled = 0)

            GO
*/