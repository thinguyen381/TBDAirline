﻿using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SearchModel ob1 = new SearchModel();
            ob1.FromDate=DateTime.Now;
            ob1.ToDate=DateTime.Now;
            ob1.Cities = new List<string> {""};
            List<Airport> Airports = _context.Airport.ToList();
            foreach (Airport airport in Airports)
            {
                ob1.Cities.Add(airport.AirportName);
            }
            return View(ob1);



            //List<Flight> result= _context.Flight.Where(f => f.Date > DateTime.Now && f.Date < DateTime.Now.AddDays(15)).ToList();
            //SearchModel searchModel = new SearchModel();
            //searchModel.Flights = result;
            //return View(searchModel);
        }

        [HttpPost]
        public IActionResult Index(SearchModel searchModel)
        {
            // Using Airport table, search for AirportID where AirportName == searchModelName
            // Only get the first value (the only one) then get the AirportID of this value
            int fromID = _context.Airport.Where(f => f.AirportName == searchModel.FromCity).First().AirportID;
            int toID = _context.Airport.Where(f => f.AirportName == searchModel.ToCity).First().AirportID;

            List<Flight> DepartureFlight = _context.Flight.Where(f => f.FromID == fromID && f.ToID== toID && f.Date==searchModel.FromDate).ToList();
            List<Flight> ReturnFlight = _context.Flight.Where(f => f.FromID == toID && f.ToID== fromID && f.Date==searchModel.ToDate).ToList();
            searchModel.DepartureFlight = DepartureFlight;
            searchModel.ReturnFlight = ReturnFlight;

            
            return View("Index1", searchModel);
        }


    }
}