using System;

namespace API.Models
{
    public class Sintoma
    {

        public Paciente() {}
        
        public int Id { get; set; }
        public String Nome { get; set; }
        public int GrauIntensidade { get; set; }

        public override string ToString() => $"Nome: {Nome} | Grau de intensidade: {GrauIntensidade}";

        
    }
}