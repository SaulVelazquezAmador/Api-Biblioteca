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
    public class AutorController : ControllerBase
    {
        // GET: api/<AutorController>
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            var context = new bibliotecaContext();
            var autores = from b in context.Autor
                          select new Autor
                          {
                              IdAutor = b.IdAutor,
                              NombreAutor = b.NombreAutor,
                              ApellidoPaterno = b.ApellidoPaterno,
                              ApellidoMaterno = b.ApellidoMaterno,
                              FechaNacimiento = b.FechaNacimiento
                          };
            return autores;
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorController>
        [HttpPost]
        public void Post([FromBody] Autor value)
        {
            var context = new bibliotecaContext();
            Autor autores = new Autor
            {
                IdAutor = value.IdAutor,
                NombreAutor = value.NombreAutor,
                ApellidoPaterno = value.ApellidoPaterno,
                ApellidoMaterno = value.ApellidoMaterno,
                FechaNacimiento = value.FechaNacimiento
            };
            context.Autor.Add(autores);
            context.SaveChanges();
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var autor = context.Autor.Where<Autor>(e => e.IdAutor == id).FirstOrDefault();
            if (autor == null) return;
            context.Autor.Remove(autor);
            context.SaveChanges();
        }
    }
}
