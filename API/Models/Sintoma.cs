using System;
using System.Collections.Generic;

namespace API.Models
{
    
    public class Sintoma
    {
        public Sintoma() 
        {
        }
        
        public int Id { get; set; }
        public String Nome { get; set; }
        public int GrauIntensidade { get; set; }
        public virtual ICollection<Triagem> Triagens { get; set; }

        public override string ToString() => $" Id: {Id} |Nome: {Nome} | Grau de intensidade: {GrauIntensidade}";
    }
}