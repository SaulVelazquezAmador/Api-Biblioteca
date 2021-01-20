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
    public class SubclasificacionController : ControllerBase
    {
        // GET: api/<SubclasificacionController>
        [HttpGet]
        public IEnumerable<Subclasificacion> Get()
        {
            var context = new bibliotecaContext();
            var subclasificacion = from b in context.Subclasificacion
                                select new Subclasificacion
                                {
                                    IdSubclasificacion = b.IdSubclasificacion,
                                    NombreSubclasificacion = b.NombreSubclasificacion
                                };
            return subclasificacion;
        }

        // GET api/<SubclasificacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubclasificacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubclasificacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubclasificacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
