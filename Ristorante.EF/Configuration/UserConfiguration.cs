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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Username)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .IsRequired();

            builder
                .Property(u => u.Ruolo)
                .IsRequired();

            builder
                .HasData(
                new User
                {
                    Id = 1,
                    Username = "MRossi",
                    Password = "12345",
                    Ruolo = Role.Ristoratore
                },
                new User
                {
                    Id = 2,
                    Username = "LBianchi",
                    Password = "54321",
                    Ruolo = Role.Cliente
                });
        }
    }
}