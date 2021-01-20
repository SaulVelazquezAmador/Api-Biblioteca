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
    public class ClasificacionController : ControllerBase
    {
        // GET: api/<ClasificacionController>
        [HttpGet]
        public IEnumerable<Clasificacion> Get()
        {
                var context = new bibliotecaContext();
                var clasificacion = from b in context.Clasificacion
                              select new Clasificacion
                              {
                                  IdClasificacion = b.IdClasificacion,
                                  NombreClasificacion = b.NombreClasificacion
                              };
                return clasificacion;
        }

        // GET api/<ClasificacionController>/5
        [HttpGet("{id}")]
        public Clasificacion Get(int id)
        {
            var context = new bibliotecaContext();

            Clasificacion clasificacion = context.Clasificacion.Where<Clasificacion>(e => e.IdClasificacion == id).FirstOrDefault<Clasificacion>();
            if (clasificacion == null)
            {
                return null;
            }


            return clasificacion;
        }

        // POST api/<ClasificacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClasificacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClasificacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
