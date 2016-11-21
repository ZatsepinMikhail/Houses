using System;
using Microsoft.AspNetCore.Mvc;
using Houses_NET_Framework_NotEmpty.Models;
using System.Web.Script.Serialization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Houses_NET_Framework_NotEmpty.Controllers
{
    public class HomeController : Controller
    {
        private DBconnector db = new DBconnector("Cities");
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCity(string city)
        {
            Tuple<double, double> coordinates = db.GetCityCoordinate(city);

            var jsonSerialiser = new JavaScriptSerializer();
            String lat = jsonSerialiser.Serialize(coordinates.Item1);
            String lng = jsonSerialiser.Serialize(coordinates.Item2);
            ViewData["city"] = city;
            ViewData["lat"] = lat;
            ViewData["lng"] = lng;
            var housesToShow = db.Select(city, 1970, 1972);
            var lats = housesToShow.Item1;
            var lngs = housesToShow.Item2;
        
            String jsonLats = jsonSerialiser.Serialize(lats);
            String jsonLngs = jsonSerialiser.Serialize(lngs);
            ViewData["lats"] = jsonLats;
            ViewData["lngs"] = jsonLngs;
            return View();
        }
    }
}
