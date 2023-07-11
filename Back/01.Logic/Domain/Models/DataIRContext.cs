using System;
using System.Collections.Generic;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class DataIRContext : DbContext
{
    private readonly string connectionString;
    public DataIRContext(string connectionString)
    {
        this.connectionString = connectionString;

    }

    public DataIRContext(DbContextOptions<DataIRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__categori__140587C7233F9FEF");

            entity.ToTable("categoria");

            entity.HasIndex(e => e.Nombre, "UQ__categori__72AFBCC6A98906A9").IsUnique();

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3C2AF85DDF");

            entity.ToTable("producto");

            entity.HasIndex(e => e.Nombre, "UQ__producto__72AFBCC69BD6A1C8").IsUnique();

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Codigo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__idcate__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
