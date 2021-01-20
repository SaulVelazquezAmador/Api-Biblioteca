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
                Nombre = WebUtility.HtmlEncode(b.Nombre),
                Apellido = WebUtility.HtmlEncode(b.Apellido),
                Edad = (b.Edad),
                Direccion = WebUtility.HtmlEncode(b.Direccion),
                Correo = WebUtility.HtmlEncode(b.Correo),
                Telefono = WebUtility.HtmlEncode(b.Telefono),
                PrestamosActivos = b.PrestamosActivos
            };
            return lectores;
        }

        // GET api/<LectorController>/5
        [HttpGet("{id}")]
        public Lector Get(int id)
        {
            var context = new bibliotecaContext();

            Lector cliente = context.Lector.Where<Lector>(e => e.IdLector == id).FirstOrDefault<Lector>();
            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        // POST api/<LectorController>
        [HttpPost]
        public IActionResult Post([FromBody] Lector value)
        {
            bool error = false;

            string nombre = WebUtility.HtmlEncode(value.Nombre);
            string apellido = WebUtility.HtmlEncode(value.Apellido);
            string direccion = WebUtility.HtmlEncode(value.Direccion);
            string correo = WebUtility.HtmlEncode(value.Correo);
            string telefono = WebUtility.HtmlEncode(value.Telefono);

            try
            {
                var context = new bibliotecaContext();
                context.Lector.Add(value);
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
            */
        }

        // PUT api/<LectorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lector value)
        {
            bool error = false;

            try
            {
                var context = new bibliotecaContext();

                var cliente = context.Lector.Where<Lector>(e => e.IdLector == id).FirstOrDefault();
                if (cliente == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                cliente.Edad = value.Edad;
                cliente.Direccion = WebUtility.HtmlEncode(value.Direccion);
                cliente.Correo = WebUtility.HtmlEncode(value.Correo);
                cliente.Telefono = WebUtility.HtmlEncode(value.Telefono);
                cliente.PrestamosActivos = value.PrestamosActivos;

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

        // DELETE api/<LectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var cliente = context.Lector.Where<Lector>(e => e.IdLector == id).FirstOrDefault();
            if (cliente == null) return;
            context.Lector.Remove(cliente);
            context.SaveChanges();
        }
    }
}
