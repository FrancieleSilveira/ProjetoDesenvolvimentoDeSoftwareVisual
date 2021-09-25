using System;

namespace API.Models
{
    public class Enfermeiro
    {

        public Enfermeiro() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Matricula { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | E-mail: {Email} Criado em: {CriadoEm}";

    }
}