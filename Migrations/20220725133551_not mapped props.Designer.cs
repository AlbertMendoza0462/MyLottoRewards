﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLotoRewards.DAL;

#nullable disable

namespace MyLotoRewards.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220725133551_not mapped props")]
    partial class notmappedprops
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("MyLotoRewards.Models.Ganancias", b =>
                {
                    b.Property<int>("GananciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("TipoJugadaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GananciaId");

                    b.ToTable("Ganancias");
                });

            modelBuilder.Entity("MyLotoRewards.Models.Jugadas", b =>
                {
                    b.Property<int>("JugadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<string>("Numeros")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoJugadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JugadaId");

                    b.HasIndex("TicketId");

                    b.ToTable("Jugadas");
                });

            modelBuilder.Entity("MyLotoRewards.Models.Loterias", b =>
                {
                    b.Property<int>("LoteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.HasKey("LoteriaId");

                    b.ToTable("Loterias");

                    b.HasData(
                        new
                        {
                            LoteriaId = 1,
                            Descripcion = "Loteria Nacional"
                        },
                        new
                        {
                            LoteriaId = 2,
                            Descripcion = "Leidsa"
                        },
                        new
                        {
                            LoteriaId = 3,
                            Descripcion = "Loto Real"
                        },
                        new
                        {
                            LoteriaId = 4,
                            Descripcion = "Loteka"
                        },
                        new
                        {
                            LoteriaId = 5,
                            Descripcion = "La Primera"
                        },
                        new
                        {
                            LoteriaId = 6,
                            Descripcion = "La Suerte"
                        },
                        new
                        {
                            LoteriaId = 7,
                            Descripcion = "Lotedom"
                        },
                        new
                        {
                            LoteriaId = 8,
                            Descripcion = "New York"
                        },
                        new
                        {
                            LoteriaId = 9,
                            Descripcion = "Anguila Lottery"
                        },
                        new
                        {
                            LoteriaId = 10,
                            Descripcion = "King Lottery"
                        });
                });

            modelBuilder.Entity("MyLotoRewards.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MyLotoRewards.Models.TiposJugadas", b =>
                {
                    b.Property<int>("TipoJugadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.Property<int>("LoteriaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoJugadaId");

                    b.ToTable("TiposJugadas");

                    b.HasData(
                        new
                        {
                            TipoJugadaId = 1,
                            Descripcion = "Lotería Nacional - Noche",
                            LoteriaId = 1
                        },
                        new
                        {
                            TipoJugadaId = 2,
                            Descripcion = "Juega + Pega +",
                            LoteriaId = 1
                        },
                        new
                        {
                            TipoJugadaId = 3,
                            Descripcion = "Gana Más",
                            LoteriaId = 1
                        },
                        new
                        {
                            TipoJugadaId = 4,
                            Descripcion = "Loto",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 5,
                            Descripcion = "Loto Más",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 6,
                            Descripcion = "Súper Más",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 7,
                            Descripcion = "Loto Pool",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 8,
                            Descripcion = "Super Kino TV",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 9,
                            Descripcion = "Pega 3 Más",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 10,
                            Descripcion = "Tripleta",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 11,
                            Descripcion = "Super Palé",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 12,
                            Descripcion = "Loto - Super Loto Más",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 13,
                            Descripcion = "Quiniela Leidsa",
                            LoteriaId = 2
                        },
                        new
                        {
                            TipoJugadaId = 14,
                            Descripcion = "Quiniela Real",
                            LoteriaId = 3
                        },
                        new
                        {
                            TipoJugadaId = 15,
                            Descripcion = "Loto Real",
                            LoteriaId = 3
                        },
                        new
                        {
                            TipoJugadaId = 16,
                            Descripcion = "Loto Pool",
                            LoteriaId = 3
                        },
                        new
                        {
                            TipoJugadaId = 17,
                            Descripcion = "Quiniela Loteka",
                            LoteriaId = 4
                        },
                        new
                        {
                            TipoJugadaId = 18,
                            Descripcion = "Mega Chance",
                            LoteriaId = 4
                        },
                        new
                        {
                            TipoJugadaId = 19,
                            Descripcion = "Mega Lotto",
                            LoteriaId = 4
                        },
                        new
                        {
                            TipoJugadaId = 20,
                            Descripcion = "Quiniela La Primera",
                            LoteriaId = 5
                        },
                        new
                        {
                            TipoJugadaId = 21,
                            Descripcion = "La Primera Día",
                            LoteriaId = 5
                        },
                        new
                        {
                            TipoJugadaId = 22,
                            Descripcion = "La Primera Noche",
                            LoteriaId = 5
                        },
                        new
                        {
                            TipoJugadaId = 23,
                            Descripcion = "Quiniela La Suerte",
                            LoteriaId = 6
                        },
                        new
                        {
                            TipoJugadaId = 24,
                            Descripcion = "Quiniela Lotedom",
                            LoteriaId = 7
                        },
                        new
                        {
                            TipoJugadaId = 25,
                            Descripcion = "El Quemaito Mayor",
                            LoteriaId = 7
                        },
                        new
                        {
                            TipoJugadaId = 26,
                            Descripcion = "New York Tarde",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 27,
                            Descripcion = "New York Noche",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 28,
                            Descripcion = "Florida Tarde",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 29,
                            Descripcion = "Florida Noche",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 30,
                            Descripcion = "Mega Millions",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 31,
                            Descripcion = "Power Ball",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 32,
                            Descripcion = "Cash 4 Life",
                            LoteriaId = 8
                        },
                        new
                        {
                            TipoJugadaId = 33,
                            Descripcion = "Anguila 10AM",
                            LoteriaId = 9
                        },
                        new
                        {
                            TipoJugadaId = 34,
                            Descripcion = "Anguila 1PM",
                            LoteriaId = 9
                        },
                        new
                        {
                            TipoJugadaId = 35,
                            Descripcion = "Anguila 5PM",
                            LoteriaId = 9
                        },
                        new
                        {
                            TipoJugadaId = 36,
                            Descripcion = "Anguila 9PM",
                            LoteriaId = 9
                        },
                        new
                        {
                            TipoJugadaId = 37,
                            Descripcion = "SXM- Quiniela Dia",
                            LoteriaId = 10
                        },
                        new
                        {
                            TipoJugadaId = 38,
                            Descripcion = "SXM- Quiniela Noche",
                            LoteriaId = 10
                        },
                        new
                        {
                            TipoJugadaId = 39,
                            Descripcion = "PICK 3 DÍA",
                            LoteriaId = 10
                        });
                });

            modelBuilder.Entity("MyLotoRewards.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserIdApi")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MyLotoRewards.Models.Jugadas", b =>
                {
                    b.HasOne("MyLotoRewards.Models.Tickets", null)
                        .WithMany("Jugadas")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyLotoRewards.Models.Tickets", b =>
                {
                    b.Navigation("Jugadas");
                });
#pragma warning restore 612, 618
        }
    }
}
