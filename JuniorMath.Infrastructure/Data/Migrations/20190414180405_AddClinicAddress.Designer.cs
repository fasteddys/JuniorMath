﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using JuniorMath.Infrastructure.Data;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    [DbContext(typeof(JuniorMathContext))]
    [Migration("20190414180405_AddClinicAddress")]
    partial class AddClinicAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview.19074.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("AddressId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnName("CreatedDateUTC")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.CommonAggregate.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Address2")
                        .HasMaxLength(50);

                    b.Property<int>("AddressTypeId");

                    b.Property<string>("AttentionTo")
                        .HasMaxLength(150);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("CountryId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnName("CreatedDateUTC")
                        .HasColumnType("datetime");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region")
                        .HasMaxLength(50);

                    b.Property<int?>("RegionId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("RegionId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.CommonAggregate.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType1")
                        .IsRequired()
                        .HasColumnName("AddressType")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AddressType");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("Age");

                    b.Property<int>("ClinicId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnName("CreatedDateUTC")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.DoctorAggregate.DoctorSpecality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId");

                    b.Property<int>("SpecalityId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecalityId");

                    b.ToTable("DoctorSpecality");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<int>("ClinicId");

                    b.Property<int>("CreatedBy");

                    b.Property<decimal>("DiscountTotal")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<int>("DoctorId");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<int>("InvoiceStatus");

                    b.Property<string>("Note")
                        .HasMaxLength(500);

                    b.Property<int>("PatientId");

                    b.Property<int>("PaymentStatus");

                    b.Property<bool>("ReOccouring");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("TaxTotal")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId");

                    b.Property<int>("ItemId");

                    b.Property<string>("Note")
                        .HasMaxLength(500);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("TaxTotal")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceReOccouring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("EndDateUtc")
                        .HasColumnName("EndDateUTC")
                        .HasColumnType("datetime");

                    b.Property<int>("InvoiceId");

                    b.Property<int>("InvoiceReOccouringTypeId");

                    b.Property<DateTime>("StartDateUtc")
                        .HasColumnName("StartDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("InvoiceReOccouringTypeId");

                    b.ToTable("InvoiceReOccouring");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceReOccouringType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReOccouringName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("InvoiceReOccouringType");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("ClinicId");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.PatientAggregate.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.PatientAggregate.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<int>("Age");

                    b.Property<int>("ClinicId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnName("CreatedDateUTC")
                        .HasColumnType("datetime");

                    b.Property<int>("DoctorId");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("FamilyId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Minor");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("PrimaryMember");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDateUtc")
                        .HasColumnName("UpdatedDateUTC")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DoctorId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("Status");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.PatientAggregate.PatientStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PatientStatus");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Country", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Active");

                    b.Property<string>("Iso2")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Region", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Specality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Specality");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CountryId");

                    b.Property<int?>("RegionId");

                    b.Property<string>("TaxName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("Id");

                    b.ToTable("Tax");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.UserAggregate.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<int>("ClinicId");

                    b.Property<int?>("DoctorId");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasMaxLength(300);

                    b.Property<int>("SiteUserLevelId");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .IsFixedLength(true)
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SiteUserLevelId");

                    b.HasIndex("UserId");

                    b.ToTable("SiteUser");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUserLevel", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SiteUserLevel");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.Clinic", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.CommonAggregate.Address", "Address")
                        .WithMany("Clinic")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("ClinicCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("ClinicUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.CommonAggregate.Address", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.CommonAggregate.AddressType", "AddressType")
                        .WithMany("Address")
                        .HasForeignKey("AddressTypeId")
                        .HasConstraintName("FK_Address_AddressType");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Country", "Country")
                        .WithMany("Address")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Address_Country");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("AddressCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Region", "RegionNavigation")
                        .WithMany("Address")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Address_Region");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("AddressUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.Clinic", "Clinic")
                        .WithMany("Doctor")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_Doctor_Clinic");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("DoctorCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("DoctorUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.DoctorAggregate.DoctorSpecality", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", "Doctor")
                        .WithMany("DoctorSpecality")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_DoctorSpecality_Doctor");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Specality", "Specality")
                        .WithMany("DoctorSpecality")
                        .HasForeignKey("SpecalityId")
                        .HasConstraintName("FK_DoctorSpecality_Specality");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.Invoice", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.Clinic", "Clinic")
                        .WithMany("Invoice")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_Invoice_Clinic");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("InvoiceCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", "Doctor")
                        .WithMany("Invoice")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Invoice_Doctor");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.PatientAggregate.Patient", "Patient")
                        .WithMany("Invoice")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("FK_Invoice_Patient");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("InvoiceUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceItem", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.Invoice", "Invoice")
                        .WithMany("InvoiceItem")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_InvoiceItem_Invoice");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.Item", "Item")
                        .WithMany("InvoiceItem")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_InvoiceItem_Item");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceReOccouring", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.Invoice", "Invoice")
                        .WithMany("InvoiceReOccouring")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_InvoiceReOccouring_Invoice");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.InvoiceAggregate.InvoiceReOccouringType", "InvoiceReOccouringType")
                        .WithMany("InvoiceReOccouring")
                        .HasForeignKey("InvoiceReOccouringTypeId")
                        .HasConstraintName("FK_InvoiceReOccouring_InvoiceReOccouringType");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.Item", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.Clinic", "Clinic")
                        .WithMany("Item")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_Item_Clinic");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("Item")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.PatientAggregate.Patient", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.CommonAggregate.Address", "Address")
                        .WithMany("Patient")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Patient_Address");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.Clinic", "Clinic")
                        .WithMany("Patient")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_Patient_Clinic");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("PatientCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", "Doctor")
                        .WithMany("Patient")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_Patient_Doctor");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.PatientAggregate.Family", "Family")
                        .WithMany("Patient")
                        .HasForeignKey("FamilyId")
                        .HasConstraintName("FK_Patient_Family");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.PatientAggregate.PatientStatus", "StatusNavigation")
                        .WithMany("Patient")
                        .HasForeignKey("Status")
                        .HasConstraintName("FK_Patient_PatientStatus");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("PatientUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.Clinic", "Clinic")
                        .WithMany("SiteUser")
                        .HasForeignKey("ClinicId")
                        .HasConstraintName("FK_SiteUser_Clinic");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.DoctorAggregate.Doctor", "Doctor")
                        .WithMany("SiteUser")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("FK_SiteUser_Doctor");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUserLevel", "SiteUserLevel")
                        .WithMany("SiteUser")
                        .HasForeignKey("SiteUserLevelId")
                        .HasConstraintName("FK_SiteUser_SiteUserLevel");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.AspNetUser", "AspNetUser")
                        .WithMany("SiteUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
