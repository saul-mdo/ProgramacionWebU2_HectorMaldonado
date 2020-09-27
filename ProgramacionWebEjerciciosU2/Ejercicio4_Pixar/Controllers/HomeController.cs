using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ejercicio4_Pixar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4_Pixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Peliculas")]
        public IActionResult Pelicula()
        {
            PixarContext context = new PixarContext();
            var peliculas = context.Pelicula.OrderBy(x => x.Nombre);
            return View(peliculas);
        }

        [Route("peliculas/{id}")]
        public IActionResult DatosPelicula(string id)
        {
            PixarContext context = new PixarContext();
            var nombrePelicula = id.Replace("-", " ").ToUpper();
            //var pelicula = context.Apariciones.Include(x => x.IdPeliculaNavigation).Include(x => x.IdPersonajeNavigation)
            //    .OrderBy(x => x.IdPersonajeNavigation.Nombre.ToUpper() == nombrePelicula);

            var pelicula = context.Pelicula.Include(x => x.Apariciones).FirstOrDefault(x => x.Nombre.ToUpper() == nombrePelicula);


            if (pelicula == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                DatosPeliculaViewModel vm = new DatosPeliculaViewModel();
                vm.Nombre = pelicula.Nombre;
                vm.NombreOriginal = pelicula.NombreOriginal;
                vm.FechaEstreno = pelicula.FechaEstreno;
                vm.Descripcion = pelicula.Descripción;
                vm.Id = pelicula.Id;

                vm.Apariciones = context.Apariciones.Include(x => x.IdPeliculaNavigation).Include(x => x.IdPersonajeNavigation).Where(x => x.IdPelicula == pelicula.Id);

                return View(vm);
            }
        }

        [Route("Cortometrajes")]
        public IActionResult Corto()
        {
            PixarContext context = new PixarContext();

            CortoViewModel cortovm = new CortoViewModel();

            var cortometrajes = context.Cortometraje.OrderBy(x => x.Nombre);

            // EN VIEWMODEL, TENGO UNA VARIABLE LLAMADA CATEGORIAS, TIPO IENUMERABLE<CATEGORIA>.
            // NECESITO ALMACENAR TODAS LAS CATEGORIAS EN ESA VARIABLE, YA QUE LAS CATEGORIAS TIENEN LA COLECCIÓN DE CORTOMETRAJES.

            // EL INCLUDE SE USA CUANDO ES UNA PROPIEDAD DE NAVEGACION. AQUI NO SE PONE PORQUE "CORTOMETRAJES" DENTRO DE CATEGORIAS ES UNA
            // PROPIEDAD CON TODOS LOS CORTOMETRAJES.

            cortovm.Categorias = context.Categoria.Include(x=>x.Cortometraje).OrderBy(x=>x.Nombre);

            return View(cortovm);
        }

        [Route("Cortometrajes/{id}")]
        public IActionResult DatosCorto(string id)
        {
            PixarContext context = new PixarContext();
            var nombreCortometraje = id.Replace("-", " ").ToUpper();
            var corto = context.Cortometraje.FirstOrDefault(x => x.Nombre.ToUpper() == nombreCortometraje);
            if (corto == null)
            {
                return RedirectToAction("Index");
            }
            else
                return View(corto);
        }
    }
}
