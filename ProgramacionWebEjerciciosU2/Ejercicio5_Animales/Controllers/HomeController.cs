using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ejercicio5_Animales.Models;
using Ejercicio5_Animales.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio5_Animales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            animalesContext context = new animalesContext();

            IndexViewModel ivm = new IndexViewModel();

            ivm.Clases = context.Clase.OrderBy(x => x.Nombre);

            Random r = new Random();

            ivm.NumImagen = r.Next(1, 6);

            return View(ivm);
        }
        [Route("/Especie/{id}")]
        public IActionResult Especies(string id)
        {
            animalesContext context = new animalesContext();

            var nombre = id.Replace("-", " ").ToUpper();

            var especies = context.Clase.Include(x => x.Especies).Where(x => x.Nombre.ToUpper() == nombre).OrderBy(x => x.Nombre);

            if (especies.Count() == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(especies);
            }

        }
    }
}
