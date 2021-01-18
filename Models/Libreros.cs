using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Libreros
    {
        public Libreros()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdLibrero { get; set; }
        public string NombreLibrero { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
