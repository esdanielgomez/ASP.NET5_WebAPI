using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PPeliculasWebAPI.DAL.Entities;

#nullable disable

namespace PPeliculasWebAPI.DAL
{
    public partial class PeliculasContext : DbContext
    {
        public PeliculasContext()
        {
        }

        public PeliculasContext(DbContextOptions<PeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PRIMARY");

                entity.ToTable("genero");

                entity.Property(e => e.IdGenero).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("PRIMARY");

                entity.ToTable("pelicula");

                entity.HasIndex(e => e.IdGenero, "fk_Pelicula_Genero_idx");

                entity.Property(e => e.IdPelicula).HasColumnType("int(11)");

                entity.Property(e => e.DuracionMinutos).HasColumnType("int(11)");

                entity.Property(e => e.FechaEstreno).HasColumnType("date");

                entity.Property(e => e.IdGenero).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pelicula_Genero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
