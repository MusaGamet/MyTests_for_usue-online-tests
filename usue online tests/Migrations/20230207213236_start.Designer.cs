﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using usue_online_tests.Data;

namespace usue_online_tests.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230207213236_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("usue_online_tests.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Group")
                        .HasColumnType("text");

                    b.Property<bool>("IsEnd")
                        .HasColumnType("boolean");

                    b.Property<int?>("PresetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PresetId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("usue_online_tests.Models.ExamTestAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalAnswers")
                        .HasColumnType("integer");

                    b.Property<int?>("UserExamResultId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserExamResultId");

                    b.ToTable("ExamTestAnswers");
                });

            modelBuilder.Entity("usue_online_tests.Models.TestPreset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsHomework")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int[]>("Tests")
                        .HasColumnType("integer[]");

                    b.Property<bool>("TimeLimited")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Presets");
                });

            modelBuilder.Entity("usue_online_tests.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Group")
                        .HasColumnType("text");

                    b.Property<bool>("IsDark")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("usue_online_tests.Models.UserExamResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ExamId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExamResults");
                });

            modelBuilder.Entity("usue_online_tests.Models.Exam", b =>
                {
                    b.HasOne("usue_online_tests.Models.TestPreset", "Preset")
                        .WithMany()
                        .HasForeignKey("PresetId");

                    b.Navigation("Preset");
                });

            modelBuilder.Entity("usue_online_tests.Models.ExamTestAnswer", b =>
                {
                    b.HasOne("usue_online_tests.Models.UserExamResult", null)
                        .WithMany("ExamTestAnswers")
                        .HasForeignKey("UserExamResultId");
                });

            modelBuilder.Entity("usue_online_tests.Models.TestPreset", b =>
                {
                    b.HasOne("usue_online_tests.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("usue_online_tests.Models.UserExamResult", b =>
                {
                    b.HasOne("usue_online_tests.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("usue_online_tests.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Exam");

                    b.Navigation("User");
                });

            modelBuilder.Entity("usue_online_tests.Models.UserExamResult", b =>
                {
                    b.Navigation("ExamTestAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
