using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio4_Pixar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4_Pixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pelicula()
        {
            PixarContext context = new PixarContext();
            var peliculas = context.Pelicula.OrderBy(x => x.Nombre);
            return View(peliculas);
        }
    }
}
