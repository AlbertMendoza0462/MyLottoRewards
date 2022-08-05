using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLotoRewards.Migrations
{
    public partial class vistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW view_winners AS
                    select ROW_NUMBER() OVER(ORDER BY TotalGanado-TotalInvertido DESC) AS Indice, UsuarioId, TotalGanado-TotalInvertido Balance
                    from Usuarios
                    where TotalGanado > TotalInvertido
                    ORDER by TotalGanado - TotalInvertido desc
                    limit 100
                ");

            migrationBuilder.Sql(@"
                CREATE VIEW view_losers AS
                    select ROW_NUMBER() OVER(ORDER BY TotalGanado-TotalInvertido DESC) AS Indice, UsuarioId, (TotalGanado-TotalInvertido)*-1 Balance
                    from Usuarios
                    where TotalGanado < TotalInvertido
                    limit 100
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW view_winners");
            migrationBuilder.Sql(@"DROP VIEW view_losers");
        }
    }
}
