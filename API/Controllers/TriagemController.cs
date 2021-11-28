using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [Route("create")]
        public IActionResult Create([FromBody] TriagemRequest triagemRequest)
        {
            Paciente paciente = _context.Pacientes.Find(triagemRequest.Paciente);
            Enfermeiro enfermeiro = _context.Enfermeiros.Find(triagemRequest.Enfermeiro);

            var triagem = new Triagem();

            triagem.Enfermeiro = enfermeiro;
            triagem.Paciente = paciente;

            _context.Triagens.Add(triagem);
            _context.SaveChanges();
            return Created("", triagem);
        }

        // //GET: api/triagem/list
        // [HttpGet]
        // [Route("fila")]
        // public IActionResult Fila() {
        //     _context.Enfermeiros.ToList();
        //     return null;
        // }

    }
}