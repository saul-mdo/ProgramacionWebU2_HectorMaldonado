using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio5_Animales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5_Animales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();

            var clases = context.Clase.OrderBy(x => x.Nombre);

            return View(clases);
        }
        [Route("/Especie/{id}")]
        public IActionResult Especies(string id)
        {
            animalesContext context = new animalesContext();

            var nombre = id.Replace("-", " ").ToUpper();

            var especies = context.Clase.Include(x => x.Especies).Where(x => x.Nombre.ToUpper() == nombre).OrderBy(x => x.Nombre);

            return View(especies);
        }
    }
}
