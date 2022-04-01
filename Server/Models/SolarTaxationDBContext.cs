using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Name=solartax");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryTb>(entity =>
            {
                entity.HasKey(e => e.Categoryid);

                entity.ToTable("CategoryTB");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.CategoryDescription).HasColumnName("categoryDescription");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname");

                entity.Property(e => e.Imageurl).HasColumnName("imageurl");
            });

            modelBuilder.Entity<ClassificationTb>(entity =>
            {
                entity.HasKey(e => e.Classificationid);

                entity.ToTable("ClassificationTB");

                entity.Property(e => e.Classificationid).HasColumnName("classificationid");

                entity.Property(e => e.Categoryid)
                    .IsRequired()
                    .HasColumnName("categoryid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Hscode)
                    .IsRequired()
                    .HasColumnName("hscode");

                entity.Property(e => e.Illustrationurl)
                    .IsRequired()
                    .HasColumnName("illustrationurl");

                entity.Property(e => e.Solarmodularcapacity)
                    .IsRequired()
                    .HasColumnName("solarmodularcapacity");
            });

            modelBuilder.Entity<StateTb>(entity =>
            {
                entity.HasKey(e => e.Stateid);

                entity.ToTable("StateTB");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.Statename)
                    .IsRequired()
                    .HasColumnName("statename");
            });

            modelBuilder.Entity<TaxTb>(entity =>
            {
                entity.HasKey(e => e.Taxid);

                entity.ToTable("TaxTB");

                entity.Property(e => e.Taxid).HasColumnName("taxid");

                entity.Property(e => e.TaxName).IsRequired();

                entity.Property(e => e.Taxcode)
                    .IsRequired()
                    .HasColumnName("taxcode");
            });

            modelBuilder.Entity<TaxTreatementTb>(entity =>
            {
                entity.ToTable("TaxTreatementTB");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Classificationid)
                    .IsRequired()
                    .HasColumnName("classificationid");

                entity.Property(e => e.Stateid)
                    .IsRequired()
                    .HasColumnName("stateid");

                entity.Property(e => e.Taxid)
                    .IsRequired()
                    .HasColumnName("taxid");

                entity.Property(e => e.Taxpercentage)
                    .IsRequired()
                    .HasColumnName("taxpercentage");
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTB");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
