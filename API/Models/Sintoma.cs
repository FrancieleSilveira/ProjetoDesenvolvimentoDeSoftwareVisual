using System;

namespace API.Models
{
    public class Sintoma
    {

        public Sintoma() {}

        public int Id { get; set; }
        public String Nome { get; set; }
        public int GrauIntensidade { get; set; }

        public override string ToString() => $"Nome: {Nome} | Grau de intensidade: {GrauIntensidade}";


    }
}