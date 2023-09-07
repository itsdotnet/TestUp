﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestUp.DataAccess.Contexts;

#nullable disable

namespace TestUp.DataAccess.Migrations
{
    [DbContext(typeof(TestUpDbContext))]
    [Migration("20230907133806_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Attachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Exam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Create")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Delete")
                        .HasColumnType("boolean");

                    b.Property<bool>("Get")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("Update")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2281),
                            Delete = true,
                            Get = true,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2282)
                        },
                        new
                        {
                            Id = 2L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2290),
                            Delete = false,
                            Get = true,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2291)
                        },
                        new
                        {
                            Id = 3L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2294),
                            Delete = true,
                            Get = true,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2295)
                        },
                        new
                        {
                            Id = 4L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2299),
                            Delete = false,
                            Get = true,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2299)
                        },
                        new
                        {
                            Id = 5L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2303),
                            Delete = true,
                            Get = true,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2304)
                        },
                        new
                        {
                            Id = 6L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2307),
                            Delete = false,
                            Get = true,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2308)
                        },
                        new
                        {
                            Id = 7L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2311),
                            Delete = true,
                            Get = true,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2312)
                        },
                        new
                        {
                            Id = 8L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2315),
                            Delete = false,
                            Get = true,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2316)
                        },
                        new
                        {
                            Id = 9L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2320),
                            Delete = true,
                            Get = false,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2321)
                        },
                        new
                        {
                            Id = 10L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2324),
                            Delete = false,
                            Get = false,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2325)
                        },
                        new
                        {
                            Id = 11L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2329),
                            Delete = true,
                            Get = false,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2329)
                        },
                        new
                        {
                            Id = 12L,
                            Create = true,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2333),
                            Delete = false,
                            Get = false,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2334)
                        },
                        new
                        {
                            Id = 13L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2338),
                            Delete = true,
                            Get = false,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2339)
                        },
                        new
                        {
                            Id = 14L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2342),
                            Delete = false,
                            Get = false,
                            IsDeleted = false,
                            Update = true,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2343)
                        },
                        new
                        {
                            Id = 15L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2346),
                            Delete = true,
                            Get = false,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2347)
                        },
                        new
                        {
                            Id = 16L,
                            Create = false,
                            CreatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2350),
                            Delete = false,
                            Get = false,
                            IsDeleted = false,
                            Update = false,
                            UpdatedAt = new DateTime(2023, 9, 7, 18, 38, 6, 266, DateTimeKind.Utc).AddTicks(2351)
                        });
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuestionPack", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionPacks");
                });

            modelBuilder.Entity("Result", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("PermissionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AnswerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("Answer", b =>
                {
                    b.HasOne("Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.HasOne("Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuestionPack", b =>
                {
                    b.HasOne("Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Result", b =>
                {
                    b.HasOne("Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("User");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("UserAnswer", b =>
                {
                    b.HasOne("Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");

                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
