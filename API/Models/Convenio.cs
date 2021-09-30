using System;

namespace API.Models
{
    public class Convenio
    {
        public Convenio() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"Nome: { Nome } | Endereco: { Endereco } | Telefone: { Telefone } | Criado em: { CriadoEm }";
    }
}