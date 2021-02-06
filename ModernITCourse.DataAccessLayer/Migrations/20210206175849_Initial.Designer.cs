﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModernITCourse.DataAccessLayer;

namespace ModernITCourse.DataAccessLayer.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20210206175849_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.ExamMarks", b =>
                {
                    b.Property<int>("EXAM_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EXAM_DATE")
                        .HasColumnType("TEXT");

                    b.Property<int>("MARK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("STUDENT_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SUBJ_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("EXAM_ID");

                    b.HasIndex("STUDENT_ID");

                    b.HasIndex("SUBJ_ID");

                    b.ToTable("ExamMarks");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.Lecturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CITY")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("NAME")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("SURNAME")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("UNIV_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UNIV_ID");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BIRTHDAY")
                        .HasColumnType("TEXT");

                    b.Property<string>("CITY")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("KURS")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NAME")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("STIPEND")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SURNAME")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("UNIV_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UNIV_ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.Subject", b =>
                {
                    b.Property<int>("SUBJ_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HOUR")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SEMESTER")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SUBJ_NAME")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("SUBJ_ID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.SubjectLecturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LECTURER_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SUBJ_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LECTURER_ID");

                    b.HasIndex("SUBJ_ID");

                    b.ToTable("SubjectLecturers");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.University", b =>
                {
                    b.Property<int>("UNIV_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CITY")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("RATING")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UNIV_NAME")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UNIV_ID");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.ExamMarks", b =>
                {
                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("STUDENT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SUBJ_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.Lecturer", b =>
                {
                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.University", "University")
                        .WithMany()
                        .HasForeignKey("UNIV_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.Student", b =>
                {
                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.University", "University")
                        .WithMany()
                        .HasForeignKey("UNIV_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("ModernITCourse.DataAccessLayer.Entities.SubjectLecturer", b =>
                {
                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LECTURER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModernITCourse.DataAccessLayer.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SUBJ_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
