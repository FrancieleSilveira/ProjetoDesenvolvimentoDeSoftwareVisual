using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/atendimento")]
    public class AtendimentoController : ControllerBase
    {

        private readonly DataContext _context;

        public AtendimentoController(DataContext context){
            _context = context;
        }

        //GET: api/atendimento/lista
        [HttpGet]
        [Route("lista")]
        public IActionResult MostraFilaParaAtendimento()
        {
            var listaPacienteOrdenado = _context.Atendimentos.FromSqlRaw("SELECT * FROM dbo.Atendimentos ORDER BY CriadoEm ASC").ToList();
            
            return Ok(listaPacienteOrdenado);
        }

        // Coloca o paciente como o próximo da fila para triagem
        //GET: api/atendimento/next
        [HttpGet]
        [Route("next")]
        public IActionResult EnviaPacienteParaTriagem()
        {
            Atendimento atendimento = _context.Atendimentos.FirstOrDefault(a => a.Aberto);
            
            _context.Remove(atendimento);
            _context.SaveChanges();

            return Created("", atendimento);
        }

        // Retorna o próximo paciente para triagem
        //GET: api/atendimento/get-prox
        [HttpGet]
        [Route("get-prox")]
        public IActionResult ProximoPacienteParaAtendimento()
        {
            Atendimento atendimento = _context.Atendimentos.FirstOrDefault(a => !a.Aberto);

            atendimento.Aberto = true;
            _context.Update(atendimento);
            _context.SaveChanges();
            return Ok(atendimento);
        }

        //POST: api/atendimento/create
        [HttpPost]
        [Route("create/{idP}/{idE}")]
        public IActionResult createAtendimento(int idP, int idE)
        {
            Paciente paciente = _context.Pacientes.Find(idP);
            Enfermeiro enfermeiro = _context.Enfermeiros.Find(idE);

            if(paciente != null && enfermeiro != null){
                Atendimento atendimento = new Atendimento();

                atendimento.PacienteId = paciente.Id;
                atendimento.Paciente = paciente;
                atendimento.EnfermeiroId = enfermeiro.Id;
                atendimento.Enfermeiro = enfermeiro;

                _context.Atendimentos.Add(atendimento);

                _context.SaveChanges();

                return Created("", atendimento);
            }

            return BadRequest("Paramêtros inválidos!");
        }
    }
}