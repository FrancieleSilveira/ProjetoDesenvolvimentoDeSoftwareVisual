using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Linq;
using System;
using API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/paciente")]
    public class PacienteController : ControllerBase
    {

        private readonly DataContext _context;
        public PacienteController(DataContext context){
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Paciente paciente){
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Created("", paciente);  
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Listar(){
            return Ok(_context.Pacientes.ToList());
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Deletar([FromRoute] int id){
            Paciente paciente = _context.Pacientes.FirstOrDefault(
                paciente => paciente.Id == id
            );
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Paciente pacienteAtualizado){
            _context.Pacientes.Update(pacienteAtualizado);
            _context.SaveChanges();
            // int id;
            // Paciente paciente = _context.Pacientes.FirstOrDefault(
            //     paciente => paciente.Cpf == cpf
            // );
            // id = paciente.Id;
            // _context.Pacientes.Remove(paciente);
            // _context.SaveChanges();
            // pacienteAtualizado.Id = id;
            // _context.Pacientes.Add(pacienteAtualizado);
            // _context.SaveChanges();
            return Ok(pacienteAtualizado);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id){
           Paciente paciente = _context.Pacientes.FirstOrDefault(
                paciente => paciente.Id == id
            );
            return Ok(paciente);
        }
    }

    
}