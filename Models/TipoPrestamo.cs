using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class TipoPrestamo
    {
        public TipoPrestamo()
        {
            Prestamos = new HashSet<Prestamos>();
        }

        public int IdTipo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}
