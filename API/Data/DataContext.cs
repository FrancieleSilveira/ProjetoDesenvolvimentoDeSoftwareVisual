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


        //Tabela de sintomas cadastrados
        public DbSet<Sintoma> Sintomas { get; set; }


    }
}