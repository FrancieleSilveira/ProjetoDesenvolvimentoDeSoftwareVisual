using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/enfermeiro")]
    public class EnfermeiroController : ControllerBase
    {
        private readonly DataContext _context;
        public EnfermeiroController(DataContext context)
        {
            _context = context;
        }

        //POST: api/enfermeiro/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Enfermeiro enfermeiro)
        {
            _context.Enfermeiros.Add(enfermeiro);
            _context.SaveChanges();
            return Created("", enfermeiro);
        }

        //GET: api/enfermeiro/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Enfermeiros.ToList());

        //GET: api/enfermeiro/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Enfermeiro enfermeiro = _context.Enfermeiros.Find(id);
            if (enfermeiro == null) return NotFound(); // TESTAR
            return Ok(enfermeiro);
        }

        // DELETE: api/enfermeiro/delete/Breno
        [HttpDelete]
        [Route("delete/{nome}")]
        public IActionResult Delete([FromRoute] string nome)
        {
            Enfermeiro enfermeiro = _context.Enfermeiros.FirstOrDefault
            (
                e => e.Nome == nome
            );
            if (enfermeiro == null)
            {
                return NotFound();
            }
            _context.Enfermeiros.Remove(enfermeiro);
            _context.SaveChanges();
            return Ok();
            //return Ok(_context.Produtos.ToList()); retorna a lista atualizada
        }

        //PUT: api/enfermeiro/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Enfermeiro enfermeiro)
        {
            _context.Enfermeiros.Update(enfermeiro); // altera pelo id
            _context.SaveChanges();
            return Ok(enfermeiro);
        }
    }
}