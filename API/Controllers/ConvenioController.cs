using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/convenio")]
    public class ConvenioController : ControllerBase
    {
        private readonly DataContext _context;

        public ConvenioController(DataContext context)
        {
            _context = context;
        }

        //POST: api/convenio/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Convenio convenio)
        {
            _context.Convenios.Add(convenio);
            _context.SaveChanges();
            return Created("", convenio);
        }

        //GET: api/convenio/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Convenios.ToList());

        //GET: api/convenio/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Convenio convenio = _context.Convenios.Find(id);
            if (convenio == null) return NotFound();
            return Ok(convenio);
        }

        // DELETE: api/convenio/delete/Dor
        [HttpDelete]
        [Route("delete/{nome}")]
        public IActionResult Delete([FromRoute] string nome)
        {
            Convenio convenio = _context.Convenios.FirstOrDefault(
                c => c.Nome == nome
            );

            if (convenio == null)
            {
                return NotFound();
            }

            _context.Convenios.Remove(convenio);
            _context.SaveChanges();
            return Ok();
        }

        //PUT: api/convenio/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Convenio convenio)
        {
            _context.Convenios.Update(convenio);
            _context.SaveChanges();
            return Ok(convenio);
        }
    }
}