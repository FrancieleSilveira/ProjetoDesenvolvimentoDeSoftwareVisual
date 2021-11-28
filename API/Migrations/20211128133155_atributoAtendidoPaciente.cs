using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class atributoAtendidoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Atendido",
                table: "Pacientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atendido",
                table: "Pacientes");
        }
    }
}
