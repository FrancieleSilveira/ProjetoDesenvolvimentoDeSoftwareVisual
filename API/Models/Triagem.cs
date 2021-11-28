using System;

namespace API.Models
{
    public class Triagem
    {
        private Paciente paciente;
        private Enfermeiro enfermeiro;


        public Triagem() => CriadoEm = DateTime.Now;


        public int Id { get; set; }
        public Enfermeiro Enfermeiro {get; set;}
        public Paciente Paciente {get; set;}
        public DateTime CriadoEm {get; set;}

        // public override string ToString() =>
        //     $"Nome: {Nome} | Sobrenome: {Sobrenome} | Matrícula: {Matricula} | Cpf: {Cpf} | Idade: {Idade} | Telefone: {Telefone} | Email: {Email} | Endereço: {Endereco} | E-mail: {Email} Criado em: {CriadoEm}";

    }
}