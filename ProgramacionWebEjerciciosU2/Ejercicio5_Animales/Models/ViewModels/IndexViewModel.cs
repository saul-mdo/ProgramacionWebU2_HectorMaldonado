using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio5_Animales.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Clase> Clases { get; set; }

        public int NumImagen { get; set; }
    }
}
