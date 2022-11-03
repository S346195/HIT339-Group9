﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using s318344_Assignment1.Data;

#nullable disable

namespace s318344_Assignment1.Migrations
{
    [DbContext(typeof(s318344_Assignment1Context))]
    [Migration("20221014041114_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("s318344_Assignment1.Models.GenderModel", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"), 1L, 1);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("GenderModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.InstrumentModel", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstrumentId"), 1L, 1);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentId");

                    b.ToTable("InstrumentModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LessonModel", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"), 1L, 1);

                    b.Property<int?>("InstrumentModelInstrumentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LessonDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LessonTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LetterId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.HasIndex("InstrumentModelInstrumentId");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("LetterId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TutorId");

                    b.ToTable("LessonModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LessonTypeModel", b =>
                {
                    b.Property<int>("LessonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonTypeId"), 1L, 1);

                    b.Property<float>("LessonCost")
                        .HasColumnType("real");

                    b.Property<int>("LessonDuration")
                        .HasColumnType("int");

                    b.Property<string>("LessonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonTypeId");

                    b.ToTable("LessonTypeModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LetterModel", b =>
                {
                    b.Property<int>("LetterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LetterId"), 1L, 1);

                    b.Property<string>("BankAccountBSB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeginningComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailSignature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LessonDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LessonTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("LetterId");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("LetterModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.StudentModel", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("GuardianName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PaymentContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("StudentID");

                    b.HasIndex("GenderId");

                    b.ToTable("StudentModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.TutorModel", b =>
                {
                    b.Property<int>("TutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorId"), 1L, 1);

                    b.Property<string>("TutorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorId");

                    b.ToTable("TutorModel");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LessonModel", b =>
                {
                    b.HasOne("s318344_Assignment1.Models.InstrumentModel", null)
                        .WithMany("Lessons")
                        .HasForeignKey("InstrumentModelInstrumentId");

                    b.HasOne("s318344_Assignment1.Models.LessonTypeModel", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId");

                    b.HasOne("s318344_Assignment1.Models.LetterModel", "Letter")
                        .WithMany("Lessons")
                        .HasForeignKey("LetterId");

                    b.HasOne("s318344_Assignment1.Models.StudentModel", "Student")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("s318344_Assignment1.Models.TutorModel", "Tutor")
                        .WithMany("Lessons")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonType");

                    b.Navigation("Letter");

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LetterModel", b =>
                {
                    b.HasOne("s318344_Assignment1.Models.LessonTypeModel", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId");

                    b.HasOne("s318344_Assignment1.Models.StudentModel", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonType");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.StudentModel", b =>
                {
                    b.HasOne("s318344_Assignment1.Models.GenderModel", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.InstrumentModel", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.LetterModel", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.StudentModel", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("s318344_Assignment1.Models.TutorModel", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
