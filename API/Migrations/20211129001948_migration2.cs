using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Enfermeiros_EnfermeiroId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<int>(
                name: "EnfermeiroId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Enfermeiros_EnfermeiroId",
                table: "Atendimentos",
                column: "EnfermeiroId",
                principalTable: "Enfermeiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Enfermeiros_EnfermeiroId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<int>(
                name: "EnfermeiroId",
                table: "Atendimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Enfermeiros_EnfermeiroId",
                table: "Atendimentos",
                column: "EnfermeiroId",
                principalTable: "Enfermeiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
