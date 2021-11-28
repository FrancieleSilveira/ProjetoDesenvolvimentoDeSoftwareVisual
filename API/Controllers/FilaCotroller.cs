using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/fila")]
    public class FilaCotroller : ControllerBase
    {
         private readonly DataContext _context;

        public FilaCotroller(DataContext context)
        {
            _context = context;
        }

        //GET: api/fila/atendimento/lista
        [HttpGet]
        [Route("atendimento/lista")]
        public IActionResult getFilaAtendimento()
        {
            var listaPacienteOrdenado = _context.Pacientes.FromSqlRaw("SELECT * FROM dbo.Pacientes ORDER BY CriadoEm ASC").ToList();
            
            return Ok(listaPacienteOrdenado);
        }

        //GET: api/fila/atendimento/next
        [HttpGet]
        [Route("atendimento/next")]
        public IActionResult nextAtendimento()
        {
            Paciente nextPaciente = _context.Pacientes.FromSqlRaw("SELECT TOP 1 * FROM dbo.Pacientes p WHERE p.Atendido = 0 ORDER BY CriadoEm ASC").FirstOrDefault<Paciente>();

            nextPaciente.Atendido = true;
            _context.Pacientes.Update(nextPaciente);
            _context.SaveChanges();

            return Ok(nextPaciente);
        }
    }
}