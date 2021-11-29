﻿using Microsoft.EntityFrameworkCore;
using JuniorMath.ApplicationCore.Entities;
using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.SettingsAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;

namespace JuniorMath.Infrastructure.Data
{
    public partial class JuniorMathContext : DbContext
    {
        public JuniorMathContext()
        {
        }

        public JuniorMathContext(DbContextOptions<JuniorMathContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SiteUser> SiteUser { get; set; }
        public virtual DbSet<SiteUserLevel> SiteUserLevel { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<QuestionImageSetting> QuestionImageSetting { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N65A546;Initial Catalog=JuniorMath_Data;User ID=sa;Password=Lq160011;Persist Security Info=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.SiteUsers)
                .WithOne(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.AttentionTo).HasMaxLength(150);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("CreatedDateUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.UpdatedDateUtc)
                    .HasColumnName("UpdatedDateUTC")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_AddressType");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Country");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AddressCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Address_Region");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AddressUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy);
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AddressType1)
                    .IsRequired()
                    .HasColumnName("AddressType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Iso2)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SiteUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(300);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("nvarchar(450)")
                    .HasMaxLength(450)
                    .IsFixedLength();

                entity.HasOne(d => d.SiteUserLevel)
                    .WithMany(p => p.SiteUser)
                    .HasForeignKey(d => d.SiteUserLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteUser_SiteUserLevel");
            });

            modelBuilder.Entity<SiteUserLevel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionImageSetting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageName)
                .IsRequired()
                .HasMaxLength(100);

                entity.HasIndex(m => new { m.ImageName }).IsUnique();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(e => e.ImageOrders)
                .IsRequired()
                .HasMaxLength(1000);

                entity.Property(e => e.Answers)
                .IsRequired()
                .HasMaxLength(1000);

                entity.HasIndex(m => new { m.Name }).IsUnique();
            });
        }
    }
}
