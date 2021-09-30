using System;

namespace API.Models
{
    public class Pessoa
    {
        public Pessoa() => CriadoEm = DateTime.Now;

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public int DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm {get; set;}
    }
}