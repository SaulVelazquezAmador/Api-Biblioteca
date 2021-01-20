using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBiblioteca.Models;

using System.Net;
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
                              NombreAutor = WebUtility.HtmlEncode (b.NombreAutor),
                              ApellidoAutor = WebUtility.HtmlEncode(b.ApellidoAutor),
                              Nacionalidad = WebUtility.HtmlEncode(b.Nacionalidad)
                          };
            return autores;
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            var context = new bibliotecaContext();

            Autor autor = context.Autor.Where<Autor>(e => e.IdAutor == id).FirstOrDefault<Autor>();
            if (autor == null)
            {
                return null;
            }

            return autor;
        }

        // POST api/<AutorController>
        [HttpPost]
        public IActionResult Post([FromBody] Autor value)
        {
            bool error = false;

            string nombreautor = WebUtility.HtmlEncode(value.NombreAutor);
            string apellidoautor = WebUtility.HtmlEncode(value.ApellidoAutor);
            string nacionalidad = value.Nacionalidad;

            try
            {
                var context = new bibliotecaContext();
                context.Autor.Add(value);
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

            /*var context = new bibliotecaContext();
            Autor autores = new Autor
            {
                IdAutor = value.IdAutor,
                NombreAutor = value.NombreAutor,
                ApellidoAutor = value.ApellidoAutor,
                Nacionalidad = value.Nacionalidad
            };
            context.Autor.Add(autores);
            context.SaveChanges();
            */
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autor value)
        {
            bool error = false;

            try
            {
                var context = new bibliotecaContext();

                var autor = context.Autor.Where<Autor>(e => e.IdAutor == id).FirstOrDefault();
                if (autor == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                autor.Nacionalidad = value.Nacionalidad;
               // autor.NombreAutor = WebUtility.HtmlEncode(value.NombreAutor);
                //autor.ApellidoAutor = WebUtility.HtmlEncode(value.ApellidoAutor);

                context.SaveChanges();
            }
            catch
            {
                error = true;
            }

            var result = new
            {
                Status = !error ? "Success" : "Fail"
            };

            return new JsonResult(result);
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
