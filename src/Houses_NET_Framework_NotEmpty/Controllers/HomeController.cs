using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Houses_NET_Framework_NotEmpty.Models;

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
            Tuple<double, double> coorinates = db.GetCityCoordinate(city);
            ViewData["city"] = city;
            ViewData["lat"] = coorinates.Item1.ToString();
            ViewData["lng"] = coorinates.Item2.ToString();
            return View();
        }
    }
}
