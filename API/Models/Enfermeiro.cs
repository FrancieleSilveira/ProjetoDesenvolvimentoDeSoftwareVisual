using System;

namespace API.Models
{
    public class Enfermeiro : Pessoa
    {

        public Enfermeiro() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public int Matricula { get; set; }

        public override string ToString() =>
            $"Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | E-mail: {Email} Criado em: {CriadoEm}";

    }
}