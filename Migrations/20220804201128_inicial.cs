using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLotoRewards.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ganancias",
                columns: table => new
                {
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganancias", x => x.GananciaId);
                });

            migrationBuilder.CreateTable(
                name: "Loterias",
                columns: table => new
                {
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loterias", x => x.LoteriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "TiposJugadas",
                columns: table => new
                {
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposJugadas", x => x.TipoJugadaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false),
                    UserIdApi = table.Column<string>(type: "TEXT", maxLength: 2147483647, nullable: false),
                    TotalGanado = table.Column<double>(type: "REAL", nullable: false),
                    TotalInvertido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Jugadas",
                columns: table => new
                {
                    JugadaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadas", x => x.JugadaId);
                    table.ForeignKey(
                        name: "FK_Jugadas_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 1, "Loteria Nacional" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 2, "Leidsa" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 3, "Loto Real" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 4, "Loteka" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 5, "La Primera" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 6, "La Suerte" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 7, "Lotedom" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 8, "New York" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 9, "Anguila Lottery" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Descripcion" },
                values: new object[] { 10, "King Lottery" });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 1, "Lotería Nacional - Noche", 1 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 2, "Juega + Pega +", 1 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 3, "Gana Más", 1 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 4, "Loto", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 5, "Loto Más", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 6, "Súper Más", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 7, "Loto Pool", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 8, "Super Kino TV", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 9, "Pega 3 Más", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 10, "Tripleta", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 11, "Super Palé", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 12, "Loto - Super Loto Más", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 13, "Quiniela Leidsa", 2 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 14, "Quiniela Real", 3 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 15, "Loto Real", 3 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 16, "Loto Pool", 3 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 17, "Quiniela Loteka", 4 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 18, "Mega Chance", 4 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 19, "Mega Lotto", 4 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 20, "Quiniela La Primera", 5 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 21, "La Primera Día", 5 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 22, "La Primera Noche", 5 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 23, "Quiniela La Suerte", 6 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 24, "Quiniela Lotedom", 7 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 25, "El Quemaito Mayor", 7 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 26, "New York Tarde", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 27, "New York Noche", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 28, "Florida Tarde", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 29, "Florida Noche", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 30, "Mega Millions", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 31, "Power Ball", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 32, "Cash 4 Life", 8 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 33, "Anguila 10AM", 9 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 34, "Anguila 1PM", 9 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 35, "Anguila 5PM", 9 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 36, "Anguila 9PM", 9 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 37, "SXM- Quiniela Dia", 10 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 38, "SXM- Quiniela Noche", 10 });

            migrationBuilder.InsertData(
                table: "TiposJugadas",
                columns: new[] { "TipoJugadaId", "Descripcion", "LoteriaId" },
                values: new object[] { 39, "PICK 3 DÍA", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Jugadas_TicketId",
                table: "Jugadas",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ganancias");

            migrationBuilder.DropTable(
                name: "Jugadas");

            migrationBuilder.DropTable(
                name: "Loterias");

            migrationBuilder.DropTable(
                name: "TiposJugadas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
