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
                                  NombreEditorial = WebUtility.HtmlEncode(b.NombreEditorial)
                              };

            return editoriales;
        }

        // GET api/<EditorialesController>/5
        [HttpGet("{id}")]
        public Editorial Get(int id)
        {
            var context = new bibliotecaContext();

            Editorial editor = context.Editorial.Where<Editorial>(e => e.IdEditorial == id).FirstOrDefault<Editorial>();

            if (editor == null)
            {
                return null;
            }

            return editor;
        }

        // POST api/<EditorialesController>
        [HttpPost]
        public IActionResult Post([FromBody] Editorial value)
        {
                bool error = false;

                string nombreeditor = WebUtility.HtmlEncode(value.NombreEditorial);

                try
                {
                    var context = new bibliotecaContext();
                    context.Editorial.Add(value);
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
                Editorial editores = new Editorial
                {
                    IdEditorial = value.IdEditorial,
                    NombreEditorial = value.NombreEditorial
                };
                context.Editorial.Add(editores);
                context.SaveChanges();
                */
            }

        // PUT api/<EditorialesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Editorial value)
        {
            bool error = false;

            try
            {
                var context = new bibliotecaContext();

                var editor = context.Editorial.Where<Editorial>(e => e.IdEditorial == id).FirstOrDefault();
                if (editor == null)
                {
                    return new JsonResult(new { Status = "Fail" }); ;
                }

                editor.NombreEditorial = WebUtility.HtmlEncode(value.NombreEditorial);
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
