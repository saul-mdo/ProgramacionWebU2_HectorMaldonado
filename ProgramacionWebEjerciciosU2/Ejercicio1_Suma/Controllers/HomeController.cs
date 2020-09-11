using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio1_Suma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1_Suma.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResultadoSuma(Numeros n)
        {
            int resultado = n.numero1 + n.numero2;
            return View(resultado);
        }
    }
}
