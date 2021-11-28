using System;

namespace API.Models
{
    public class TriagemRequest
    {
        public TriagemRequest() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public int Enfermeiro {get; set;}
        public int Paciente {get; set;}
        public DateTime CriadoEm {get; set;}



        // public override string ToString() =>
        //     $"Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | E-mail: {Email} Criado em: {CriadoEm}";

    }
}