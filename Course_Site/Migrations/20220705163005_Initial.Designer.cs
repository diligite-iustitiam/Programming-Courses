﻿// <auto-generated />
using System;
using Course_Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Course_Site.Migrations
{
    [DbContext(typeof(Academy))]
    [Migration("20220705163005_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Course_Site.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentFacultiesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("FacultyId");

                    b.HasIndex("StudentFacultiesId");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            FacultyId = 1,
                            Title = "C# 10 and .NET 6"
                        },
                        new
                        {
                            FacultyId = 2,
                            Title = "Web Development"
                        },
                        new
                        {
                            FacultyId = 3,
                            Title = "Python for Beginners"
                        });
                });

            modelBuilder.Entity("Course_Site.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StudentFacultiesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentFacultiesId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "Alice",
                            LastName = "Jones"
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "Bob",
                            LastName = "Smith"
                        },
                        new
                        {
                            StudentId = 3,
                            FirstName = "Cecilia",
                            LastName = "Ramirez"
                        });
                });

            modelBuilder.Entity("Course_Site.Models.StudentFaculties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentFaculties");
                });

            modelBuilder.Entity("FacultyStudent", b =>
                {
                    b.Property<int>("FacultiesFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsStudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FacultiesFacultyId", "StudentsStudentId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("FacultyStudent");
                });

            modelBuilder.Entity("Course_Site.Models.Faculty", b =>
                {
                    b.HasOne("Course_Site.Models.StudentFaculties", null)
                        .WithMany("Faculties")
                        .HasForeignKey("StudentFacultiesId");
                });

            modelBuilder.Entity("Course_Site.Models.Student", b =>
                {
                    b.HasOne("Course_Site.Models.StudentFaculties", null)
                        .WithMany("Students")
                        .HasForeignKey("StudentFacultiesId");
                });

            modelBuilder.Entity("Course_Site.Models.StudentFaculties", b =>
                {
                    b.HasOne("Course_Site.Models.Faculty", "faculty")
                        .WithMany("StudentFaculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Site.Models.Student", "student")
                        .WithMany("StudentFaculties")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("faculty");

                    b.Navigation("student");
                });

            modelBuilder.Entity("FacultyStudent", b =>
                {
                    b.HasOne("Course_Site.Models.Faculty", null)
                        .WithMany()
                        .HasForeignKey("FacultiesFacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course_Site.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Course_Site.Models.Faculty", b =>
                {
                    b.Navigation("StudentFaculties");
                });

            modelBuilder.Entity("Course_Site.Models.Student", b =>
                {
                    b.Navigation("StudentFaculties");
                });

            modelBuilder.Entity("Course_Site.Models.StudentFaculties", b =>
                {
                    b.Navigation("Faculties");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
