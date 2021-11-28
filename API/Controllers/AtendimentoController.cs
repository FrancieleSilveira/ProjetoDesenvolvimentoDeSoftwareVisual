using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AtendimentoController : ControllerBase
    {

        private readonly DataContext _context;

        public AtendimentoController(DataContext context){
            _context = context;
        }

        //GET: api/fila/atendimento/lista
        [HttpGet]
        [Route("atendimento/lista")]
        public IActionResult getFilaAtendimento()
        {
            var listaPacienteOrdenado = _context.Atendimentos.FromSqlRaw("SELECT * FROM dbo.Atendimentos ORDER BY CriadoEm ASC").ToList();
            
            return Ok(listaPacienteOrdenado);
        }

        // Coloca o paciente como o próximo da fila para triagem
        //GET: api/fila/atendimento/next
        [HttpGet]
        [Route("atendimento/next")]
        public IActionResult nextAtendimento()
        {
            Atendimento atendimento = _context.Atendimentos.FromSqlRaw("SELECT TOP 1 * FROM dbo.Atendimentos p ORDER BY CriadoEm ASC").FirstOrDefault<Atendimento>();
            
            atendimento.Aberto = true;
            // Enfermeiro enfermeiro = _context.Enfermeiros.Find(atendimento.Enfermeiro.Id);
            // Paciente paciente = _context.Pacientes.Find(atendimento.Paciente.Id);
            _context.Update(atendimento);
            _context.SaveChanges();

            return Created("", atendimento);
        }

        // Retorna o próximo paciente para triagem
        //GET: api/fila/atendimento/next
        [HttpGet]
        [Route("atendimento/get-prox")]
        public IActionResult getProxPaciente()
        {
            Atendimento atendimento = _context.Atendimentos.FromSqlRaw("SELECT * FROM dbo.Atendimentos a WHERE a.Aberto = 1").FirstOrDefault<Atendimento>();
            

            return Ok(atendimento);
        }

        //GET: api/fila/atendimento/create
        [HttpGet]
        [Route("atendimento/create/{idP}/{idE}")]
        public IActionResult createAtendimento(int idP, int idE)
        {
            Paciente paciente = _context.Pacientes.Find(idP);
            Enfermeiro enfermeiro = _context.Enfermeiros.Find(idE);
            if(paciente != null && enfermeiro != null){
                Atendimento atendimento = new Atendimento();

                atendimento.PacienteId = paciente.Id;
                atendimento.Paciente = paciente;
                atendimento.Enfermeiro = enfermeiro;

                _context.Atendimentos.Add(atendimento);

                _context.SaveChanges();

                return Created("", atendimento);
            }

            return BadRequest("Paramêtros inválidos!");
        }
    }
}