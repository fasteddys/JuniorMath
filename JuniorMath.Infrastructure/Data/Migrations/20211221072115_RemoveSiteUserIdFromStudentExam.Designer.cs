﻿// <auto-generated />
using System;
using JuniorMath.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JuniorMath.Infrastructure.Data.Migrations
{
    [DbContext(typeof(JuniorMathContext))]
    [Migration("20211221072115_RemoveSiteUserIdFromStudentExam")]
    partial class RemoveSiteUserIdFromStudentExam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview.19074.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Class");
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

                    b.Property<int?>("CreatedBy");

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

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.ExamAggregate.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.QuestionAggregate.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("ExamId");

                    b.Property<int>("Marks");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("QuestionType");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ExamId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.QuestionAggregate.QuestionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("QuestionId");

                    b.Property<int>("QuestionImageSettingId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionImageSettingId");

                    b.ToTable("QuestionDetail");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.QuestionAggregate.QuestionImageSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ImageType");

                    b.HasKey("Id");

                    b.HasIndex("ImageName")
                        .IsUnique();

                    b.ToTable("QuestionImageSetting");
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

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EaxmId");

                    b.Property<string>("Notes");

                    b.Property<bool>("Submitted");

                    b.Property<int>("SubmittedBy");

                    b.Property<DateTime>("SubmittedDate");

                    b.Property<int?>("TotalMarks");

                    b.HasKey("Id");

                    b.HasIndex("EaxmId");

                    b.HasIndex("SubmittedBy");

                    b.ToTable("StudentExam");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExamQuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers");

                    b.Property<int?>("Marks");

                    b.Property<int>("QuestionId");

                    b.Property<int?>("SiteUserId");

                    b.Property<int>("StudentExamId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SiteUserId");

                    b.HasIndex("StudentExamId");

                    b.ToTable("StudentExamQuestionAnswers");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExamQuestionAnswerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnswerCounts");

                    b.Property<int>("QuestionDetailId");

                    b.Property<int>("StudentExamQuestionAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionDetailId");

                    b.HasIndex("StudentExamQuestionAnswerId");

                    b.ToTable("StudentExamQuestionAnswerDetail");
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
                        .WithMany("AddressCreatedByCollection")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.SettingsAggregate.Region", "RegionNavigation")
                        .WithMany("Address")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Address_Region");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "UpdatedByNavigation")
                        .WithMany("AddressUpdatedByCollection")
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.ExamAggregate.Exam", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("ExamCreatedByCollection")
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.QuestionAggregate.Question", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "CreatedByNavigation")
                        .WithMany("QuestionCreatedByCollection")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.ExamAggregate.Exam", "ExamIdNavigation")
                        .WithMany("QuestionCollection")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.QuestionAggregate.QuestionDetail", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.QuestionAggregate.Question", "QuestionIdNavigation")
                        .WithMany("QuestionDetailCollection")
                        .HasForeignKey("QuestionId");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.QuestionAggregate.QuestionImageSetting", "QuestionImageSettingIdNavigation")
                        .WithMany("QuestionDetailCollection")
                        .HasForeignKey("QuestionImageSettingId");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExam", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.ExamAggregate.Exam", "ExamIdNavigation")
                        .WithMany("StudentExamCollection")
                        .HasForeignKey("EaxmId");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", "SubmittedByNavigation")
                        .WithMany("StudentExamCreatedByCollection")
                        .HasForeignKey("SubmittedBy");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExamQuestionAnswer", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.QuestionAggregate.Question", "QuestionIdNavigation")
                        .WithMany("StudentExamQuestionAnswerCollection")
                        .HasForeignKey("QuestionId");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser")
                        .WithMany("StudentExamQuestionAnswerCollection")
                        .HasForeignKey("SiteUserId");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExam", "StudentExamIdNavigation")
                        .WithMany("StudentExamQuestionAnswerCollection")
                        .HasForeignKey("StudentExamId");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExamQuestionAnswerDetail", b =>
                {
                    b.HasOne("JuniorMath.ApplicationCore.Entities.QuestionAggregate.QuestionDetail", "QuestionDetailIdNavigation")
                        .WithMany("StudentExamQuestionAnswerDetailCollection")
                        .HasForeignKey("QuestionDetailId");

                    b.HasOne("JuniorMath.ApplicationCore.Entities.StudentAggregate.StudentExamQuestionAnswer", "StudentExamQuestionAnswerIdNavigation")
                        .WithMany("StudentExamQuestionAnswerDetailCollection")
                        .HasForeignKey("StudentExamQuestionAnswerId");
                });

            modelBuilder.Entity("JuniorMath.ApplicationCore.Entities.UserAggregate.SiteUser", b =>
                {
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
