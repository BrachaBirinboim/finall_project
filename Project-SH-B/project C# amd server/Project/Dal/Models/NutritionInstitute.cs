using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class NutritionInstitute : DbContext
{
    public NutritionInstitute()
    {
    }

    public NutritionInstitute(DbContextOptions<NutritionInstitute> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Dietitian> Dietitians { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<QueuesForDietitian> QueuesForDietitians { get; set; }

    public virtual DbSet<WorkHour> WorkHours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Project-SH-B\\project C# amd server\\Project\\DB\\NutritionInstitute.mdf\";Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Clients_pk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Kind)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("kind");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Dietitian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Dietitians_pk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Kind)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kind");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Meetings_pk");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DieticanId).HasColumnName("dieticanId");
            entity.Property(e => e.Hour).HasColumnName("hour");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientsId_fk");

            entity.HasOne(d => d.Dietican).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.DieticanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dieticanId_fk");
        });

        modelBuilder.Entity<QueuesForDietitian>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("QueuesForDietitian_pk");

            entity.ToTable("QueuesForDietitian");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DieticanId).HasColumnName("dieticanId");
            entity.Property(e => e.Hour).HasColumnName("hour");

            entity.HasOne(d => d.Dietican).WithMany(p => p.QueuesForDietitians)
                .HasForeignKey(d => d.DieticanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dieticanIdAvailableQueue_fk");
        });

        modelBuilder.Entity<WorkHour>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__WorkHour__357D4CF8F6FBF299");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DayInTheWeek).HasColumnName("dayInTheWeek");
            entity.Property(e => e.DieticanId).HasColumnName("dieticanId");
            entity.Property(e => e.EndHour).HasColumnName("endHour");
            entity.Property(e => e.StartHour).HasColumnName("startHour");

            entity.HasOne(d => d.Dietican).WithMany(p => p.WorkHours)
                .HasForeignKey(d => d.DieticanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dieticanId_fk2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
