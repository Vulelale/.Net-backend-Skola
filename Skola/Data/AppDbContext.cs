using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Skola.Models;

namespace Skola.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Codebook> Codebooks { get; set; }

    public virtual DbSet<CodebookItem> CodebookItems { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GTR-PRIME;Database=SkolaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927A047FE6E7E");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.JezikNastaveId).HasColumnName("JezikNastaveID");
            entity.Property(e => e.Naziv).HasMaxLength(50);
            entity.Property(e => e.NazivIzdvojeneSkole).HasMaxLength(20);
            entity.Property(e => e.OdeljenjskiStaresina).HasMaxLength(30);
            entity.Property(e => e.PrviStraniJezikId).HasColumnName("PrviStraniJezikID");
            entity.Property(e => e.Smena).HasMaxLength(50);
            entity.Property(e => e.VrstaOdeljenjaId).HasColumnName("VrstaOdeljenjaID");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__GradeID__4222D4EF");

            entity.HasOne(d => d.JezikNastave).WithMany(p => p.ClassJezikNastaves)
                .HasForeignKey(d => d.JezikNastaveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__JezikNa__46E78A0C");

            entity.HasOne(d => d.PrviStraniJezik).WithMany(p => p.ClassPrviStraniJeziks)
                .HasForeignKey(d => d.PrviStraniJezikId)
                .HasConstraintName("FK__Classes__PrviStr__48CFD27E");

            entity.HasOne(d => d.VrstaOdeljenja).WithMany(p => p.ClassVrstaOdeljenjas)
                .HasForeignKey(d => d.VrstaOdeljenjaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__VrstaOd__4316F928");
        });

        modelBuilder.Entity<Codebook>(entity =>
        {
            entity.HasKey(e => e.CodebookId).HasName("PK__Codebook__D010F12534352CB0");

            entity.HasIndex(e => e.Name, "UQ__Codebook__737584F6B584A257").IsUnique();

            entity.Property(e => e.CodebookId).HasColumnName("CodebookID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<CodebookItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Codebook__727E83EB1A74C131");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.CodebookId).HasColumnName("CodebookID");
            entity.Property(e => e.Value).HasMaxLength(20);

            entity.HasOne(d => d.Codebook).WithMany(p => p.CodebookItems)
                .HasForeignKey(d => d.CodebookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CodebookI__Codeb__3A81B327");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A375777E3E4");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.RazredId).HasColumnName("RazredID");
            entity.Property(e => e.SkolskaGodinaId).HasColumnName("SkolskaGodinaID");

            entity.HasOne(d => d.Program).WithMany(p => p.GradePrograms)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__ProgramI__3F466844");

            entity.HasOne(d => d.Razred).WithMany(p => p.GradeRazreds)
                .HasForeignKey(d => d.RazredId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__RazredID__3E52440B");

            entity.HasOne(d => d.SkolskaGodina).WithMany(p => p.GradeSkolskaGodinas)
                .HasForeignKey(d => d.SkolskaGodinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__SkolskaG__3D5E1FD2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC310D32A9");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C6B4433D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
