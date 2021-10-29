using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.Configuration
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(p => p.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.Descrizione)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(p => p.Tipologia)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (Tipo)Enum.Parse(typeof(Tipo), v));

            builder
                .Property(p => p.Prezzo)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .HasOne(m => m.Menu)
                .WithMany(p => p.Piatti)
                .HasForeignKey(m => m.MenuId);

            builder
                .HasData(
                new Piatto
                {
                    Id = 1,
                    Nome = "Pasta Carbonara",
                    Descrizione = "Spaghetti, Uovo, Guanciale etc",
                    Tipologia = Tipo.Primo,
                    Prezzo = 6,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 2,
                    Nome = "Lasagne al Forno",
                    Descrizione = "Pasta Sfoglia, Besciamella, Pomododoro etc",
                    Tipologia = Tipo.Primo,
                    Prezzo = 10,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 3,
                    Nome = "Orecchiette Funghi e Noci",
                    Descrizione = "Orecchiette, Funghi Porcini, Noci etc",
                    Tipologia = Tipo.Primo,
                    Prezzo = 7,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 4,
                    Nome = "Agnello con Patate",
                    Descrizione = "Costata di Agnello, Patate arrosto etc",
                    Tipologia = Tipo.Secondo,
                    Prezzo = 17,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 5,
                    Nome = "Pollo Arrosto",
                    Descrizione = "Pollo arrosto, Patate arrosto, Rosmarino etc",
                    Tipologia = Tipo.Secondo,
                    Prezzo = 15,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 6,
                    Nome = "Tonno e pomodorini",
                    Descrizione = "Tonno, Pomodorini, Olio etc",
                    Tipologia = Tipo.Secondo,
                    Prezzo = 16,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 7,
                    Nome = "Patate Fritte",
                    Descrizione = "Patatine Fritte",
                    Tipologia = Tipo.Contorno,
                    Prezzo = 5,
                    MenuId = 1
                },
                new Piatto
                {
                    Id = 8,
                    Nome = "Patate Arrosto",
                    Descrizione = "Patate Arrosto",
                    Tipologia = Tipo.Contorno,
                    Prezzo = 6,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 9,
                    Nome = "Tagliere",
                    Descrizione = "Salame, Prosciutto Cotto, Prosciutto Crudo etc",
                    Tipologia = Tipo.Contorno,
                    Prezzo = 7,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 10,
                    Nome = "Tiramisu",
                    Descrizione = "Tiramisu al caffe",
                    Tipologia = Tipo.Dolce,
                    Prezzo = 5,
                    MenuId = 3
                },
                new Piatto
                {
                    Id = 11,
                    Nome = "Cheesecake",
                    Descrizione = "Cheesecake ai frutti di bosco",
                    Tipologia = Tipo.Dolce,
                    Prezzo = 6,
                    MenuId = 2
                },
                new Piatto
                {
                    Id = 12,
                    Nome = "Sorbetto",
                    Descrizione = "Sorbetto al limone",
                    Tipologia = Tipo.Dolce,
                    Prezzo = 4,
                    MenuId = 1
                }
                );
        }
    }
}