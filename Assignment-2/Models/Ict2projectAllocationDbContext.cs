using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Models;

public partial class Ict2projectAllocationDbContext : DbContext
{
    public Ict2projectAllocationDbContext()
    {
    }

    public Ict2projectAllocationDbContext(DbContextOptions<Ict2projectAllocationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAllocation> ProjectAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ProjectAllocateString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F1183346B34");

            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF06966BDD3");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<ProjectAllocation>(entity =>
        {
            entity.HasKey(e => e.AllocationId).HasName("PK__ProjectA__B3C6D64BE0BF9457");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("Role ");

            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectAllocations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAllocations_ToTable");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectAllocations)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAllocations_ToTable_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
