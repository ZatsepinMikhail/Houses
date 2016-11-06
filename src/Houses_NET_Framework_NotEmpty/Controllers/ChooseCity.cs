using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Houses_NET_Framework_NotEmpty.Controllers
{
    public class ChooseCity : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCity(string city)
        {
            ViewData["City"] = city;
            return View();
        }
    }
}
