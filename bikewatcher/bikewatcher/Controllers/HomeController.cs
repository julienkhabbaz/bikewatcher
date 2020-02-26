using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bikewatcher.Models;
using bikewatcher.Repository;
using bikewatcher.Entity;

namespace bikewatcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Liste(int favorisStationId = 0, string ville = "lyon", float lat = 0f, float lon = 0f)
        {
            List<BikeStation> stations = new List<BikeStation>(); 
            if (ville == "lyon")
            {   
                stations = await BikeStationRepository.ProcessBikeStation();
            }
            else if (ville == "bordeaux")
            {
                stations = await BikeStationRepository.ProcessBikeStationBordeauxx();
            }

            if (lat != 0 && lon != 0)
            {
                ViewBag.Stations = stations.OrderBy(s => s.GetDistanceFromUser(lat, lon)).ToList();
            }
            else
            {
                ViewBag.Stations = stations.OrderBy(s => s.name).ToList();
            }

            // TODO ajouter favoris a la base

            return View();
        }
        public async Task<IActionResult> Carte()
        {
            ViewBag.Stations = await BikeStationRepository.ProcessBikeStation();

            return View();
        }
        
        public IActionResult Favoris()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
