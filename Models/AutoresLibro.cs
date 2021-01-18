using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class AutoresLibro
    {
        public int RAutor { get; set; }
        public string RIsbn { get; set; }

        public virtual Autor RAutorNavigation { get; set; }
        public virtual Libro RIsbnNavigation { get; set; }
    }
}
