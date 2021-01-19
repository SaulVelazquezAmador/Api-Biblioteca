using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBiblioteca.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        // GET: api/<LectorController>
        [HttpGet]
        public IEnumerable<Lector> Get()
        {
            var context = new bibliotecaContext();
            var lectores = from b in context.Lector
            select new Lector
            {
                IdLector = b.IdLector,
                Nombre = b.Nombre,
                Apellido = b.Apellido,
                Edad = b.Edad,
                Direccion = b.Direccion,
                Correo = b.Correo,
                Telefono = b.Telefono,
                PrestamosActivos = b.PrestamosActivos
            };
            return lectores;
        }

        // GET api/<LectorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LectorController>
        [HttpPost]
        public void Post([FromBody] Lector value)
        {
            var context = new bibliotecaContext();
            Lector lectores = new Lector
            {
                IdLector = value.IdLector,
                Nombre = value.Nombre,
                Apellido = value.Apellido,
                Edad = value.Edad,
                Direccion = value.Direccion,
                Correo = value.Correo,
                Telefono = value.Telefono,
                PrestamosActivos = value.PrestamosActivos
            };
            context.Lector.Add(lectores);
            context.SaveChanges();
        }

        // PUT api/<LectorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var lector = context.Lector.Where<Lector>(e => e.IdLector == id).FirstOrDefault();
            if (lector == null) return;
            context.Lector.Remove(lector);
            context.SaveChanges();
        }
    }
}
