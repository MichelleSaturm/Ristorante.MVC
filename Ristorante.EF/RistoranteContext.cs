using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Models;
using Ristorante.EF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF
{
    public class RistoranteContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<User> Users { get; set; }


        public RistoranteContext(DbContextOptions<RistoranteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
