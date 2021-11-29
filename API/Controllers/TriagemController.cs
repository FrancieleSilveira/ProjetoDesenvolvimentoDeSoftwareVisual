using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/triagem")]
    public class TriagemController : ControllerBase
    {
        private readonly DataContext _context;

        public TriagemController(DataContext context){
            _context = context;
        }

         //POST: api/triagem/create
        [HttpPost]
        [Route("triagem/create")]
        public IActionResult createTriagem([FromBody] List<Sintoma> sintomas)
        {
            var atendimento = _context.Atendimentos.FromSqlRaw("SELECT TOP 1 * FROM dbo.Atendimentos a ORDER BY CriadoEm ASC").ToList();
            if(atendimento != null){
                // Paciente paciente = _context.Pacientes.Find(atendimento.PacienteId);

                Triagem triagem = new Triagem();

                // triagem.Paciente = paciente;

                int intensidade = 0;
                
                // List<Sintoma> lista = new List<Sintoma>();

                // SintomaTriagem sintomaTriagem = new SintomaTriagem();

                foreach (var sintoma in sintomas){
                    triagem.Sintomas.Add(sintoma);
                    intensidade += sintoma.GrauIntensidade;
                }

                triagem.Urgencia = intensidade;

                _context.Triagens.Add(triagem);
                // _context.SintomaTriagem.Add(sintomaTriagem);

                _context.SaveChanges();
                
                return Created("", triagem);
            }

            return BadRequest("Reject");
        }
    }
}