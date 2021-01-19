using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Prestamos
    {
        public int IdPrestamo { get; set; }
        public string RLibro { get; set; }
        public int? RLector { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public float? Sancion { get; set; }
        public int? RTipoPrestamo { get; set; }

        public virtual Lector RLectorNavigation { get; set; }
        public virtual Libro RLibroNavigation { get; set; }
        public virtual TipoPrestamo RTipoPrestamoNavigation { get; set; }
    }
}
