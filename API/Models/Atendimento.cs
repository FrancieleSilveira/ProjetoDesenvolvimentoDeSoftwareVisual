using System;

namespace API.Models
{
    public class Atendimento
    {
        public Atendimento() => CriadoEm = DateTime.Now;


        public int Id { get; set; }
        public Enfermeiro Enfermeiro {get; set;}
        public int EnfermeiroId {get; set;}
        public int PacienteId {get; set;}
        public Paciente Paciente {get; set;}
        public Boolean Aberto {get; set;}
        public DateTime CriadoEm {get; set;}

    }
}