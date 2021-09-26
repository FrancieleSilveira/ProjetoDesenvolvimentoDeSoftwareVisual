using System;

namespace API.Models
{
    public class Paciente : Pessoa
    {
        // public Paciente() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public int Matricula { get; set; }
        // public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"ID: {Id} Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | Criado em: {CriadoEm}";

    }
}