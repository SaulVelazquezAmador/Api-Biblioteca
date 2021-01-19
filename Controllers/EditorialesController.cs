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
    public class EditorialesController : ControllerBase
    {
        // GET: api/<EditorialesController>
        [HttpGet]
        public IEnumerable<Editorial> Get()
        {
            var context = new bibliotecaContext();
            var editoriales = from b in context.Editorial
                              select new Editorial
                              {
                                  IdEditorial = b.IdEditorial,
                                  NombreEditorial = b.NombreEditorial
                              };

            return editoriales;
        }

        // GET api/<EditorialesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EditorialesController>
        [HttpPost]
        public void Post([FromBody] Editorial value)
        {
            var context = new bibliotecaContext();
            Editorial editores = new Editorial
            {
                IdEditorial = value.IdEditorial,
                NombreEditorial = value.NombreEditorial
            };
            context.Editorial.Add(editores);
            context.SaveChanges();
        }

        // PUT api/<EditorialesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EditorialesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new bibliotecaContext();
            var editor = context.Editorial.Where<Editorial>(e => e.IdEditorial == id).FirstOrDefault();
            if (editor == null) return;
            context.Editorial.Remove(editor);
            context.SaveChanges();
        }
    }
}
