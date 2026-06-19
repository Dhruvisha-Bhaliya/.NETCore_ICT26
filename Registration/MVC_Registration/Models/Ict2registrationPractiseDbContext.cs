using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Registration.Models;

public partial class Ict2registrationPractiseDbContext : DbContext
{
    public Ict2registrationPractiseDbContext()
    {
    }

    public Ict2registrationPractiseDbContext(DbContextOptions<Ict2registrationPractiseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ICT2RegistrationPractiseDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bills__11F2FC6A49A7C847");

            entity.Property(e => e.BillId).ValueGeneratedNever();
            entity.Property(e => e.Billamount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FinalBill).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Surcharge).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.User).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Table_ToTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CFB7EADA3");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
