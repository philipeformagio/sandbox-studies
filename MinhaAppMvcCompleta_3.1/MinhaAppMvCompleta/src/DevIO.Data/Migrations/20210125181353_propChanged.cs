using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class propChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoForncedor",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoFornecedor",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "TipoForncedor",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
