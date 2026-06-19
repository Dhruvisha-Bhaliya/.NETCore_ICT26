using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Models;

public partial class Internal2024EmployeeDbContext : DbContext
{
    public Internal2024EmployeeDbContext()
    {
    }

    public Internal2024EmployeeDbContext(DbContextOptions<Internal2024EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<IncrementDetail> IncrementDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Internal2024_EmployeeDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11E0BF85B7");

            entity.ToTable("Employee");
        });

        modelBuilder.Entity<IncrementDetail>(entity =>
        {
            entity.HasKey(e => e.IncrementId).HasName("PK__Incremen__E49940A8CAF705EE");

            entity.ToTable("IncrementDetail");

            entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Increment).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NewBasicSalary).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Employee).WithMany(p => p.IncrementDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_IncrementDetail_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
