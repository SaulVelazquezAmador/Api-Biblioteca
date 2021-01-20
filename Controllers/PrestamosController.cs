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
    public class PrestamosController : ControllerBase
    {
        // GET: api/<PrestamosController>
        [HttpGet]
        public IEnumerable<Prestamos> Get()
        {
            var context = new bibliotecaContext();
            var prestamo = from b in context.Prestamos

                            select new Prestamos
                            {
                                IdPrestamo = b.IdPrestamo,
                                RLibro = b.RLibro,
                                RLector = b.RLector,
                                FechaEntrega = b.FechaEntrega,
                                FechaDevolucion = b.FechaDevolucion,
                                Sancion = b.Sancion,
                                RTipoPrestamo = b.RTipoPrestamo
                            };
            return prestamo;
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public Prestamos Get(int id)
        {
            var context = new bibliotecaContext();

            Prestamos prestamos = context.Prestamos.Where<Prestamos>(e => e.IdPrestamo == id).FirstOrDefault<Prestamos>();
            if (prestamos == null)
            {
                return null;
            }

            return prestamos;
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public void Post([FromBody] Prestamos value)
        {
            var context = new bibliotecaContext();
            Prestamos prestamo = new Prestamos
            {
                IdPrestamo = value.IdPrestamo,
                RLibro = value.RLibro,
                RLector = value.RLector,
                FechaEntrega = value.FechaEntrega,
                FechaDevolucion = value.FechaDevolucion,
                Sancion = value.Sancion,
                RTipoPrestamo = value.RTipoPrestamo
            };
            context.Prestamos.Add(prestamo);
            context.SaveChanges();
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var prestamo = context.Prestamos.Where<Prestamos>(e => e.IdPrestamo == id).FirstOrDefault();
            if (prestamo == null) return;
            context.Prestamos.Remove(prestamo);
            context.SaveChanges();
        }
    }
}
