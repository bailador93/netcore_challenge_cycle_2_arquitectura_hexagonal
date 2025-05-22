using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using domain.Entities;

namespace infraestructure.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Indicar que se usará el esquema "Catalogo"
            modelBuilder.HasDefaultSchema("Catalogo");

            // Mapear la clase Producto a la tabla Productos (opcional si coinciden los nombres)
            modelBuilder.Entity<Producto>().ToTable("Productos");

            // Configurar la precisión del campo Precio
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasPrecision(10, 2);
        }

    }
}
