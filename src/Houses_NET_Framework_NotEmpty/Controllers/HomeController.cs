using System;
using Microsoft.AspNetCore.Mvc;
using Houses_NET_Framework_NotEmpty.Models;
using System.Web.Script.Serialization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Houses_NET_Framework_NotEmpty.Controllers
{
    public class HomeController : Controller
    {
        private DBconnector db = new DBconnector();
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCity(string city)
        {
            Tuple<double, double, int> cityInfo = db.GetCityInfo(city);

            var jsonSerialiser = new JavaScriptSerializer();
            String lat = jsonSerialiser.Serialize(cityInfo.Item1);
            String lng = jsonSerialiser.Serialize(cityInfo.Item2);
            String first_year = jsonSerialiser.Serialize(cityInfo.Item3);

            ViewData["city"] = city;
            ViewData["lat"] = lat;
            ViewData["lng"] = lng;
            ViewData["first_year"] = first_year;
            var housesToShow = db.Select(city, cityInfo.Item3, 2016);
            var years = housesToShow.Item1;
            var lats = housesToShow.Item2;
            var lngs = housesToShow.Item3;

            String jsonYears = jsonSerialiser.Serialize(years);
            String jsonLats = jsonSerialiser.Serialize(lats);
            String jsonLngs = jsonSerialiser.Serialize(lngs);

            ViewData["years"] = jsonYears;
            ViewData["lats"] = jsonLats;
            ViewData["lngs"] = jsonLngs;
            return View();
        }
    }
}
