using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ejercicio2_Estados.Models;

namespace Ejercicio2_Estados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mexicoContext context = new mexicoContext();
            var estados = context.Estados.OrderBy(x => x.Nombre).ToList();
            return View(estados);
        }
    }
}
