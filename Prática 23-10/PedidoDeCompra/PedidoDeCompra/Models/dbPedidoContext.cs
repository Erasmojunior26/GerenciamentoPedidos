using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PedidoDeCompra.Models
{
    public partial class dbPedidoContext : DbContext
    {
        public dbPedidoContext()
        {
        }

        public dbPedidoContext(DbContextOptions<dbPedidoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC03LAB2834\\SENAI;User Id=sa; Password=senai.123; Database=dbPedido");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");

                entity.Property(e => e.ProdutoId).HasColumnName("ProdutoID");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Statuss)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.VendedorId)
                    .HasConstraintName("FK__Produto__Vendedo__38996AB5");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("Vendedor");

                entity.Property(e => e.VendedorId).HasColumnName("VendedorID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
