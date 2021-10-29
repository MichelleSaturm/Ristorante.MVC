﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ristorante.EF;

namespace Ristorante.EF.Migrations
{
    [DbContext(typeof(RistoranteContext))]
    [Migration("20211029092942_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ristorante.Core.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Menu di Capodanno"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Cena Domenicale"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Pranzo Pasquale"
                        });
                });

            modelBuilder.Entity("Ristorante.Core.Models.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Piatti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descrizione = "Spaghetti, Uovo, Guanciale etc",
                            MenuId = 1,
                            Nome = "Pasta Carbonara",
                            Prezzo = 6m,
                            Tipologia = "Primo"
                        },
                        new
                        {
                            Id = 2,
                            Descrizione = "Pasta Sfoglia, Besciamella, Pomododoro etc",
                            MenuId = 2,
                            Nome = "Lasagne al Forno",
                            Prezzo = 10m,
                            Tipologia = "Primo"
                        },
                        new
                        {
                            Id = 3,
                            Descrizione = "Orecchiette, Funghi Porcini, Noci etc",
                            MenuId = 3,
                            Nome = "Orecchiette Funghi e Noci",
                            Prezzo = 7m,
                            Tipologia = "Primo"
                        },
                        new
                        {
                            Id = 4,
                            Descrizione = "Costata di Agnello, Patate arrosto etc",
                            MenuId = 3,
                            Nome = "Agnello con Patate",
                            Prezzo = 17m,
                            Tipologia = "Secondo"
                        },
                        new
                        {
                            Id = 5,
                            Descrizione = "Pollo arrosto, Patate arrosto, Rosmarino etc",
                            MenuId = 2,
                            Nome = "Pollo Arrosto",
                            Prezzo = 15m,
                            Tipologia = "Secondo"
                        },
                        new
                        {
                            Id = 6,
                            Descrizione = "Tonno, Pomodorini, Olio etc",
                            MenuId = 1,
                            Nome = "Tonno e pomodorini",
                            Prezzo = 16m,
                            Tipologia = "Secondo"
                        },
                        new
                        {
                            Id = 7,
                            Descrizione = "Patatine Fritte",
                            MenuId = 1,
                            Nome = "Patate Fritte",
                            Prezzo = 5m,
                            Tipologia = "Contorno"
                        },
                        new
                        {
                            Id = 8,
                            Descrizione = "Patate Arrosto",
                            MenuId = 2,
                            Nome = "Patate Arrosto",
                            Prezzo = 6m,
                            Tipologia = "Contorno"
                        },
                        new
                        {
                            Id = 9,
                            Descrizione = "Salame, Prosciutto Cotto, Prosciutto Crudo etc",
                            MenuId = 3,
                            Nome = "Tagliere",
                            Prezzo = 7m,
                            Tipologia = "Contorno"
                        },
                        new
                        {
                            Id = 10,
                            Descrizione = "Tiramisu al caffe",
                            MenuId = 3,
                            Nome = "Tiramisu",
                            Prezzo = 5m,
                            Tipologia = "Dolce"
                        },
                        new
                        {
                            Id = 11,
                            Descrizione = "Cheesecake ai frutti di bosco",
                            MenuId = 2,
                            Nome = "Cheesecake",
                            Prezzo = 6m,
                            Tipologia = "Dolce"
                        },
                        new
                        {
                            Id = 12,
                            Descrizione = "Sorbetto al limone",
                            MenuId = 1,
                            Nome = "Sorbetto",
                            Prezzo = 4m,
                            Tipologia = "Dolce"
                        });
                });

            modelBuilder.Entity("Ristorante.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "12345",
                            Ruolo = 0,
                            Username = "MRossi"
                        },
                        new
                        {
                            Id = 2,
                            Password = "54321",
                            Ruolo = 1,
                            Username = "LBianchi"
                        });
                });

            modelBuilder.Entity("Ristorante.Core.Models.Piatto", b =>
                {
                    b.HasOne("Ristorante.Core.Models.Menu", "Menu")
                        .WithMany("Piatti")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
