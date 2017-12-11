using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "La página de descripción de la aplicación.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "La página de contacto.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
