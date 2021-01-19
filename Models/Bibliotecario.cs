using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoBiblioteca.Models
{
    public partial class Bibliotecario
    {
        public int IdBibliotecario { get; set; }
        public string NombreBibliotecario { get; set; }
        public string ApellidoBibliotecario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}
