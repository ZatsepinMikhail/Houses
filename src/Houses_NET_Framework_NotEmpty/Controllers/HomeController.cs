using System;
using Microsoft.AspNetCore.Mvc;
using Houses_NET_Framework_NotEmpty.Models;
using System.Web.Script.Serialization;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Houses_NET_Framework_NotEmpty.Controllers
{
    public class HomeController : Controller
    {
        private DBconnector db = new DBconnector("cities");
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCity(string city)
        {
            Tuple<double, double> coorinates = db.GetCityCoordinate(city);
            var jsonSerialiser = new JavaScriptSerializer();
            String lat = jsonSerialiser.Serialize(coorinates.Item1);
            String lng = jsonSerialiser.Serialize(coorinates.Item2);
            ViewData["city"] = city;
            ViewData["lat"] = lat;
            ViewData["lng"] = lng;
            var housesToShow = db.Select(city, 1970, 1972);
            String jsonHouses = jsonSerialiser.Serialize(housesToShow);
            ViewData["houses"] = jsonHouses;         
            return View();
        }
    }
}
