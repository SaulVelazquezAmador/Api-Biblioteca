using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdEditorial { get; set; }
        public string NombreEditorial { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
