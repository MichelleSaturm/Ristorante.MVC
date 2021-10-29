using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Models;

namespace Ristorante.EF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Nome)
                .HasMaxLength(40)
                .IsRequired();

            builder
                 .HasMany(p => p.Piatti)
                 .WithOne(m => m.Menu);

            builder
                .HasData(
                new Menu
                {
                    Id = 1,
                    Nome = "Menu di Capodanno",
                },
                new Menu
                 {
                    Id = 2,
                    Nome = "Cena Domenicale",
                 },
                new Menu
                  {
                    Id = 3,
                    Nome = "Pranzo Pasquale",
                  }
                );
        }
    }
}