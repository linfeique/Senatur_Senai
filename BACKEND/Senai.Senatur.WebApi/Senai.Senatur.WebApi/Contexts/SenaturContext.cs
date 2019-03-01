using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class SenaturContext : DbContext
    {
        public SenaturContext()
        {
        }

        public SenaturContext(DbContextOptions<SenaturContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= Senatur_Tarde; User Id=sa; Password=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasKey(e => e.PacoteId);

                entity.ToTable("PACOTES");

                entity.HasIndex(e => e.NomePacote)
                    .HasName("UQ__PACOTES__77BB3B44306C8E5F")
                    .IsUnique();

                entity.Property(e => e.DataIda).HasColumnType("date");

                entity.Property(e => e.DataVolta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomePacote)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__A9D10534B33B9AF4")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
