using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBiblioteca.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBiblioteca.Controllers
{
    //prueba git
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecariosController : ControllerBase
    {
        // GET: api/<BibliotecariosController>
        [HttpGet]
        public IEnumerable<Bibliotecario> Get()
        {
            var context = new bibliotecaContext();
            var empleados = from b in context.Bibliotecario
                            select new Bibliotecario
                            {
                                IdBibliotecario = b.IdBibliotecario,
                                NombreBibliotecario = b.NombreBibliotecario,
                                ApellidoBibliotecario = b.ApellidoBibliotecario,
                                Correo = b.Correo,
                                Contraseña = b.Contraseña
                            };
            return empleados;
        }

        // GET api/<BibliotecariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BibliotecariosController>
        [HttpPost]
        public void Post([FromBody] Bibliotecario value)
        {
            var context = new bibliotecaContext();
            Bibliotecario empleado = new Bibliotecario
            {
                IdBibliotecario = value.IdBibliotecario,
                NombreBibliotecario = value.NombreBibliotecario,
                ApellidoBibliotecario = value.ApellidoBibliotecario,
                Correo = value.Correo,
                Contraseña = value.Contraseña
            };
            context.Bibliotecario.Add(empleado);
            context.SaveChanges();
        }

        // PUT api/<BibliotecariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BibliotecariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var empleado = context.Bibliotecario.Where<Bibliotecario>(e => e.IdBibliotecario == id).FirstOrDefault();
            if (empleado == null) return;
            context.Bibliotecario.Remove(empleado);
            context.SaveChanges();
        }
    }
}
