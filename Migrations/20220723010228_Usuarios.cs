using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLotoRewards.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ganancias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false),
                    UserIdApi = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ganancias");
        }
    }
}
