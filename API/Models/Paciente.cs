using System;

namespace API.Models
{
    public class Paciente
    {
        public Paciente() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public int ConvenioId { get; set; }
        public Convenio Convenio { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Atendido { get; set; }

        public override string ToString() =>
            $"ID: {Id} | Convenio: { Convenio } | Nome: {Nome} | Sobrenome: {Sobrenome} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | Criado em: {CriadoEm}";

    }
}