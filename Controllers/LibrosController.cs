using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

                    select new Libro
                     {
                         Isbn = b.Isbn,
                         Titulo = WebUtility.HtmlEncode(b.Titulo),
                         RAutor = b.RAutor,
                         REditorial = b.REditorial,
                         RClasificacion = b.RClasificacion,
                         RSubclasificacion = b.RSubclasificacion,
                         RUbicacion = b.RUbicacion,
                         Año = b.Año,
                         Existencias = b.Existencias,
                     };
            return libro;
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public Libro Get(string id)
        {
            var context = new bibliotecaContext();

            Libro libro = context.Libro.Where<Libro>(e => e.Isbn == id).FirstOrDefault<Libro>();
            if (libro == null)
            {
                return null;
            }

            return libro;
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro value)
        {
            bool error = false;

            string titulo = WebUtility.HtmlEncode(value.Titulo);

            try
            {
                var context = new bibliotecaContext();
                context.Libro.Add(value);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                error = true;
            }

            var result = new
            {
                Status = !error ? "Success" : "Fail"
            };

            return new JsonResult(result);

            /*
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
            */
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
