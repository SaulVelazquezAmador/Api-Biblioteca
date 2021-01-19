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
    public class AutoresControllers : ControllerBase
    {
        // GET: api/<BibliotecariosController>
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            var context = new bibliotecaContext();
            var autores = from b in context.Autor
                            select new Autor
                            {
                                NombreAutor = b.NombreAutor,
                                ApellidoPaterno = b.ApellidoPaterno,
                                ApellidoMaterno = b.ApellidoMaterno,
                                FechaNacimiento = b.FechaNacimiento
                            };
            return autores;
        }

        // GET api/<BibliotecariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BibliotecariosController>
        [HttpPost]
        public void Post([FromBody] Autor value)
        {
            var context = new bibliotecaContext();
            Autor autores = new Autor
            {
                NombreAutor = value.NombreAutor,
                ApellidoPaterno = value.ApellidoPaterno,
                ApellidoMaterno = value.ApellidoMaterno,
                FechaNacimiento = value.FechaNacimiento
            };
            context.Autor.Add(autores);
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
        }
    }
}
