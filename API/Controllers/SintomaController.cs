using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/sintoma")]
    public class SintomaController : ControllerBase
    {
        private readonly DataContext _context;

        public SintomaController(DataContext context)
        {
            _context = context;
        }

        //POST: api/sintoma/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Sintoma sintoma)
        {
            _context.Sintomas.Add(sintoma);
            _context.SaveChanges();
            return Created("", sintoma);
        }

        //GET: api/sintoma/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Sintomas.ToList());

        //GET: api/sintoma/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Sintoma sintoma = _context.Sintomas.Find(id);
            if (sintoma == null) return NotFound();
            return Ok(sintoma);
        }

        // DELETE: api/sintoma/delete/Dor
        [HttpDelete]
        [Route("delete/{nome}")]
        public IActionResult Delete([FromRoute] string nome)
        {
            Sintoma sintoma = _context.Sintomas.FirstOrDefault(
                s => s.Nome == nome
            );
            if (sintoma == null)
            {
                return NotFound();
            }
            _context.Sintomas.Remove(sintoma);
            _context.SaveChanges();
            return Ok();
        }

        //PUT: api/sintoma/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Sintoma sintoma)
        {
            _context.Sintomas.Update(sintoma); // altera pelo id
            _context.SaveChanges();
            return Ok(sintoma);
        }
    }
}