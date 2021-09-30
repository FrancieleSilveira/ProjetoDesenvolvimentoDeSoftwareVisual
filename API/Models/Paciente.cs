using System;

namespace API.Models
{
    public class Paciente : Pessoa
    {
        public int Id { get; set; }
        public int Matricula { get; set; }

        public override string ToString() =>
            $"ID: {Id} | Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {DataNascimento} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | Criado em: {CriadoEm}";

    }
}