using GimnasioApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GimnasioApp.Infrastructure.Data
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Clase> Clases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DNI).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(250);
            });
        }
    }
}