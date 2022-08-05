using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLotoRewards.Migrations
{
    public partial class vista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW view_cant_loterias AS
                    SELECT lt.Descripcion, count(lt.LoteriaId) Cantidad from jugadas
                    INNER join TiposJugadas tj on tj.TipoJugadaId = Jugadas.TipoJugadaId
                    INNER join Loterias lt on lt.LoteriaId = tj.LoteriaId
                    GROUP by tj.LoteriaId
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW view_cant_loterias");
        }
    }
}
