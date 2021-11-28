using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades que vão virar tabelas no banco

        //Tabela de enfermeiros cadastrados
        public DbSet<Enfermeiro> Enfermeiros { get; set; }

        //Tabela de pacientes cadastrados
        public DbSet<Paciente> Pacientes { get; set; }

        //Tabela de sintomas cadastrados
        public DbSet<Sintoma> Sintomas { get; set; }

        //Tabela de convenios cadastrados
        public DbSet<Convenio> Convenios { get; set; }

        //Tabela de triagens cadastrados
        public DbSet<Triagem> Triagens { get; set; }


    }
}