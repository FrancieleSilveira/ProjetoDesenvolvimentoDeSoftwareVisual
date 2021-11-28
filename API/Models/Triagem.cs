using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Triagem
    {
        public Triagem() 
        {
            CriadoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public int Urgencia {get; set;}
        public int PacienteId { get; set; }
        public Paciente Paciente {get; set;}
        public DateTime CriadoEm {get; set;}
        public ICollection<Sintoma> Sintomas { get; set; }

    }
}