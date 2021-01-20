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
    public class LibrosController : ControllerBase
    {
        // GET: api/<LibrosController>
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
        var context = new bibliotecaContext();
        var libro = from b in context.Libro
                     join s in context.AutoresLibro on b.Isbn equals s.RIsbn
                     join t in context.Editorial on b.REditorial equals t.IdEditorial
                     join u in context.Clasificacion on b.RClasificacion equals u.IdClasificacion
                     join v in context.Subclasificacion on b.RSubclasificacion equals v.IdSubclasificacion
                     join w in context.Libreros on b.RUbicacion equals w.IdLibrero
                    orderby b.Isbn ascending
                    select new Libro
                     {
                         Isbn = b.Isbn,
                         Titulo = b.Titulo,
                         REditorial = t.IdEditorial,
                         RClasificacion = u.IdClasificacion,
                         RSubclasificacion = v.IdSubclasificacion,
                         RUbicacion = w.IdLibrero,
                         Año = b.Año,
                         Existencias = b.Existencias
                     };
            return libro;
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrosController>
        [HttpPost]
        public void Post([FromBody] Libro value)
        {
            var context = new bibliotecaContext();
            Libro libro = new Libro
            {
                Isbn = value.Isbn,
                Titulo = value.Titulo,
                REditorial = value.REditorial,
                RClasificacion = value.RClasificacion,
                RSubclasificacion = value.RSubclasificacion,
                RUbicacion = value.RUbicacion,
                Año = value.Año,
                Existencias = value.Existencias
            };
            context.Libro.Add(libro);
            context.SaveChanges();
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var context = new bibliotecaContext();
            var libro = context.Libro.Where<Libro>(e => e.Isbn == id).FirstOrDefault();
            if (libro == null) return;
            context.Libro.Remove(libro);
            context.SaveChanges();
        }
    }
}
