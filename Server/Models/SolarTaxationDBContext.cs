using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SolarTaxApp.Server.Models
{
    public partial class SolarTaxationDBContext : DbContext
    {
        public SolarTaxationDBContext()
        {
        }

        public SolarTaxationDBContext(DbContextOptions<SolarTaxationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTb> CategoryTbs { get; set; }
        public virtual DbSet<ClassificationTb> ClassificationTbs { get; set; }
        public virtual DbSet<StateTb> StateTbs { get; set; }
        public virtual DbSet<TaxTb> TaxTbs { get; set; }
        public virtual DbSet<TaxTreatementTb> TaxTreatementTbs { get; set; }
        public virtual DbSet<UserTb> UserTbs { get; set; }
        public virtual DbSet<ViewTaxTreatement> ViewTaxTreatements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=(local);initial catalog=SolarTaxationDB;Trusted_Connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryTb>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CategoryTB");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryDescription).IsUnicode(false);

                entity.Property(e => e.CategoryName).IsUnicode(false);

                entity.Property(e => e.ImageUrl).HasColumnType("text");
            });

            modelBuilder.Entity<ClassificationTb>(entity =>
            {
                entity.HasKey(e => e.ClassificationId);

                entity.ToTable("ClassificationTB");

                entity.Property(e => e.ClassificationId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.HsCode).IsUnicode(false);

                entity.Property(e => e.IllustrationUrl).HasColumnType("text");

                entity.Property(e => e.SolarModularCapacity).IsUnicode(false);
            });

            modelBuilder.Entity<StateTb>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("StateTB");

                entity.Property(e => e.StateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<TaxTb>(entity =>
            {
                entity.HasKey(e => e.TaxId);

                entity.ToTable("TaxTB");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCode).IsUnicode(false);

                entity.Property(e => e.TaxName).IsUnicode(false);
            });

            modelBuilder.Entity<TaxTreatementTb>(entity =>
            {
                entity.ToTable("TaxTreatementTB");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassificationId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPercentage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTb");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasColumnType("text");

                entity.Property(e => e.LastName).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");

                entity.Property(e => e.UserName).HasColumnType("text");
            });

            modelBuilder.Entity<ViewTaxTreatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewTaxTreatement");

                entity.Property(e => e.CategoryName).IsUnicode(false);

                entity.Property(e => e.ClassificationId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.HsCode).IsUnicode(false);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IllustrationUrl).HasColumnType("text");

                entity.Property(e => e.ImageUrl).HasColumnType("text");

                entity.Property(e => e.SolarModularCapacity).IsUnicode(false);

                entity.Property(e => e.StateId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateName).IsUnicode(false);

                entity.Property(e => e.TaxCode).IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxName).IsUnicode(false);

                entity.Property(e => e.TaxPercentage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
