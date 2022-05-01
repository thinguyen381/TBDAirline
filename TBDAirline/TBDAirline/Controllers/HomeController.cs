using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{ // These are all just links and don't need to be notated
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>View()</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>View()</returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Error Directs User to an error report page.
        /// </summary>
        /// <returns>View()</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}