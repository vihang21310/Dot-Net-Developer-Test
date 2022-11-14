using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models;

public partial class JobsContext : DbContext
{
    public JobsContext()
    {
    }

    public JobsContext(DbContextOptions<JobsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblJob> TblJobs { get; set; }

    public virtual DbSet<TblLocation> TblLocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CSSL08;Database=Jobs;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__tblDepar__B2079BCD5F423D55");

            entity.ToTable("tblDepartments");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblJob>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__tblJobs__056690E2178C0289");

            entity.ToTable("tblJobs");

            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.ClosingDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PostedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblJobs__Departm__1F98B2C1");

            entity.HasOne(d => d.Location).WithMany(p => p.TblJobs)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblJobs__Locatio__208CD6FA");
        });

        modelBuilder.Entity<TblLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__tblLocat__E7FEA477AA29D8EA");

            entity.ToTable("tblLocation");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
