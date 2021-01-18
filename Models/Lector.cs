using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Lector
    {
        public Lector()
        {
            Prestamos = new HashSet<Prestamos>();
        }

        public int IdLector { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int? Telefono { get; set; }
        public int? PrestamosActivos { get; set; }

        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}
