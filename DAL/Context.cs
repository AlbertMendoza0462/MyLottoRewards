using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLotoRewards.DAL
{
    public class Context: DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Ganancias> Ganancias { get; set; }
        public DbSet<Loterias> Loterias { get; set; }
        public DbSet<TiposJugadas> TiposJugadas { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loterias>().HasData(
                new Loterias()
                {
                    LoteriaId = 1,
                    Descripcion = "Loteria Nacional"
                },
                new Loterias()
                {
                    LoteriaId = 2,
                    Descripcion = "Leidsa"
                },
                new Loterias()
                {
                    LoteriaId = 3,
                    Descripcion = "Loto Real"
                },
                new Loterias()
                {
                    LoteriaId = 4,
                    Descripcion = "Loteka"
                },
                new Loterias()
                {
                    LoteriaId = 5,
                    Descripcion = "La Primera"
                },
                new Loterias()
                {
                    LoteriaId = 6,
                    Descripcion = "La Suerte"
                },
                new Loterias()
                {
                    LoteriaId = 7,
                    Descripcion = "Lotedom"
                },
                new Loterias()
                {
                    LoteriaId = 8,
                    Descripcion = "New York"
                },
                new Loterias()
                {
                    LoteriaId = 9,
                    Descripcion = "Anguila Lottery"
                },
                new Loterias()
                {
                    LoteriaId = 10,
                    Descripcion = "King Lottery"
                }
            );

            modelBuilder.Entity<TiposJugadas>().HasData(
                // Loteria Nacional
                new TiposJugadas()
                {
                    TipoJugadaId = 1,
                    LoteriaId = 1,
                    Descripcion = "Lotería Nacional - Noche"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 2,
                    LoteriaId = 1,
                    Descripcion = "Juega + Pega +"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 3,
                    LoteriaId = 1,
                    Descripcion = "Gana Más"
                },
                // Leidsa
                new TiposJugadas()
                {
                    TipoJugadaId = 4,
                    LoteriaId = 2,
                    Descripcion = "Loto"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 5,
                    LoteriaId = 2,
                    Descripcion = "Loto Más"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 6,
                    LoteriaId = 2,
                    Descripcion = "Súper Más"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 7,
                    LoteriaId = 2,
                    Descripcion = "Loto Pool"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 8,
                    LoteriaId = 2,
                    Descripcion = "Super Kino TV"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 9,
                    LoteriaId = 2,
                    Descripcion = "Pega 3 Más"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 10,
                    LoteriaId = 2,
                    Descripcion = "Tripleta"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 11,
                    LoteriaId = 2,
                    Descripcion = "Super Palé"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 12,
                    LoteriaId = 2,
                    Descripcion = "Loto - Super Loto Más"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 13,
                    LoteriaId = 2,
                    Descripcion = "Quiniela Leidsa"
                },
                // Loto Real
                new TiposJugadas()
                {
                    TipoJugadaId = 14,
                    LoteriaId = 3,
                    Descripcion = "Quiniela Real"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 15,
                    LoteriaId = 3,
                    Descripcion = "Loto Real"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 16,
                    LoteriaId = 3,
                    Descripcion = "Loto Pool"
                },
                // Loteka
                new TiposJugadas()
                {
                    TipoJugadaId = 17,
                    LoteriaId = 4,
                    Descripcion = "Quiniela Loteka"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 18,
                    LoteriaId = 4,
                    Descripcion = "Mega Chance"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 19,
                    LoteriaId = 4,
                    Descripcion = "Mega Lotto"
                },
                // La Primera
                new TiposJugadas()
                {
                    TipoJugadaId = 20,
                    LoteriaId = 5,
                    Descripcion = "Quiniela La Primera"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 21,
                    LoteriaId = 5,
                    Descripcion = "La Primera Día"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 22,
                    LoteriaId = 5,
                    Descripcion = "La Primera Noche"
                },
                // La Suerte
                new TiposJugadas()
                {
                    TipoJugadaId = 23,
                    LoteriaId = 6,
                    Descripcion = "Quiniela La Suerte"
                },
                // Lotedom
                new TiposJugadas()
                {
                    TipoJugadaId = 24,
                    LoteriaId = 7,
                    Descripcion = "Quiniela Lotedom"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 25,
                    LoteriaId = 7,
                    Descripcion = "El Quemaito Mayor"
                },
                // New York
                new TiposJugadas()
                {
                    TipoJugadaId = 26,
                    LoteriaId = 8,
                    Descripcion = "New York Tarde"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 27,
                    LoteriaId = 8,
                    Descripcion = "New York Noche"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 28,
                    LoteriaId = 8,
                    Descripcion = "Florida Tarde"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 29,
                    LoteriaId = 8,
                    Descripcion = "Florida Noche"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 30,
                    LoteriaId = 8,
                    Descripcion = "Mega Millions"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 31,
                    LoteriaId = 8,
                    Descripcion = "Power Ball"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 32,
                    LoteriaId = 8,
                    Descripcion = "Cash 4 Life"
                },
                // Anguila Lottery
                new TiposJugadas()
                {
                    TipoJugadaId = 33,
                    LoteriaId = 9,
                    Descripcion = "Anguila 10AM"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 34,
                    LoteriaId = 9,
                    Descripcion = "Anguila 1PM"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 35,
                    LoteriaId = 9,
                    Descripcion = "Anguila 5PM"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 36,
                    LoteriaId = 9,
                    Descripcion = "Anguila 9PM"
                },
                // King Lottery
                new TiposJugadas()
                {
                    TipoJugadaId = 37,
                    LoteriaId = 10,
                    Descripcion = "SXM- Quiniela Dia"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 38,
                    LoteriaId = 10,
                    Descripcion = "SXM- Quiniela Noche"
                },
                new TiposJugadas()
                {
                    TipoJugadaId = 39,
                    LoteriaId = 10,
                    Descripcion = "PICK 3 DÍA"
                }
            );
        }
    }
}
