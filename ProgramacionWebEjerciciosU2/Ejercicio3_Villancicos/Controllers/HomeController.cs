using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio3_Villancicos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio3_Villancicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.OrderByDescending(x => x.Nombre);
            return View(villancico);
        }

        public IActionResult Villancico(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancico.FirstOrDefault(x => x.Id == id);

            if (villancico == null)
            {
                return RedirectToAction("Index");
            }
            else            
                return View(villancico);

        }
    }
}
