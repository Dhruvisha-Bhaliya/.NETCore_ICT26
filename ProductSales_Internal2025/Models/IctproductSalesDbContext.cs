using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductSales_Internal2025.Models;

public partial class IctproductSalesDbContext : DbContext
{
    public IctproductSalesDbContext()
    {
    }

    public IctproductSalesDbContext(DbContextOptions<IctproductSalesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ICTProductSalesDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD909CDA3B");

            entity.ToTable("Product");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId).HasName("PK__Sales__C952FB32C152C801");

            entity.Property(e => e.SalesId).ValueGeneratedOnAdd();
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Gst)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GST");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Totalamount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
