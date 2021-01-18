using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamos>();
        }

        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public int? REditorial { get; set; }
        public int? RClasificacion { get; set; }
        public int? RSubclasificacion { get; set; }
        public int? RUbicacion { get; set; }
        public int? Año { get; set; }
        public int? Existencias { get; set; }

        public virtual Clasificacion RClasificacionNavigation { get; set; }
        public virtual Editorial REditorialNavigation { get; set; }
        public virtual Subclasificacion RSubclasificacionNavigation { get; set; }
        public virtual Libreros RUbicacionNavigation { get; set; }
        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}
