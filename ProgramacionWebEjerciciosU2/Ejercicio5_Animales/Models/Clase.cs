﻿using System;
using System.Collections.Generic;

namespace Ejercicio5_Animales.Models
{
    public partial class Clase
    {
        public Clase()
        {
            Especies = new HashSet<Especies>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Especies> Especies { get; set; }
    }
}
