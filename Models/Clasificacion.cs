using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Clasificacion
    {
        public Clasificacion()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdClasificacion { get; set; }
        public string NombreClasificacion { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
