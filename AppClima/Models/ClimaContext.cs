using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace AppClima.Models
{
    public partial class ClimaContext : DbContext
    {
        public ClimaContext()
        {
        }

        public ClimaContext(DbContextOptions<ClimaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ClimaDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.Property(e => e.CiudadId)
                    .ValueGeneratedNever()
                    .HasColumnName("CiudadID");

                entity.Property(e => e.CiudadNombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisCodigo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.PaisCodigoNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.PaisCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Pais");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.ToTable("Historico");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CiudadNombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Clima).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PaisNombre)
                    .IsRequired()
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SensacionTermica).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaisCodigo)
                    .HasName("PK__Pais__F3A7B39AE772EE19");

                entity.Property(e => e.PaisCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisNombre)
                    .IsRequired()
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
