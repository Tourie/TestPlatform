﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestPlatform.Infrastructure.Data;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201210113529_FixUserTestResultId")]
    partial class FixUserTestResultId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CategoryTest", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("TestsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "TestsId");

                    b.HasIndex("TestsId");

                    b.ToTable("CategoryTest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TestPlatform.Core.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<bool>("isTruth")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1 ответ 1 вопроса",
                            QuestionId = 1,
                            isTruth = false
                        },
                        new
                        {
                            Id = 2,
                            Name = "2 ответ 1 вопроса",
                            QuestionId = 1,
                            isTruth = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "1 ответ 2 вопроса",
                            QuestionId = 2,
                            isTruth = false
                        },
                        new
                        {
                            Id = 4,
                            Name = "2 ответ 2 вопроса",
                            QuestionId = 2,
                            isTruth = false
                        },
                        new
                        {
                            Id = 5,
                            Name = "1 ответ",
                            QuestionId = 3,
                            isTruth = false
                        },
                        new
                        {
                            Id = 6,
                            Name = "2 ответ",
                            QuestionId = 3,
                            isTruth = false
                        },
                        new
                        {
                            Id = 7,
                            Name = "1 ответ",
                            QuestionId = 4,
                            isTruth = false
                        },
                        new
                        {
                            Id = 8,
                            Name = "2 ответ",
                            QuestionId = 4,
                            isTruth = false
                        },
                        new
                        {
                            Id = 9,
                            Name = "1 овтет",
                            QuestionId = 5,
                            isTruth = false
                        },
                        new
                        {
                            Id = 10,
                            Name = "2 ответ",
                            QuestionId = 5,
                            isTruth = false
                        });
                });

            modelBuilder.Entity("TestPlatform.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Вопросы по математике",
                            Name = "Математика"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Вопросы по физике",
                            Name = "Физика"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Вопросы по программированию",
                            Name = "Программирование"
                        });
                });

            modelBuilder.Entity("TestPlatform.Core.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Testid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Testid");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1 вопрос 1 теста",
                            Testid = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "2 вопрос 1 теста",
                            Testid = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "1 вопрос 2 теста",
                            Testid = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "2 вопрос 2 теста",
                            Testid = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "1 вопрос 3 теста",
                            Testid = 3
                        });
                });

            modelBuilder.Entity("TestPlatform.Core.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Описание",
                            Name = "Вопросы начального уровня",
                            OwnerId = "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                            Time = 12L
                        },
                        new
                        {
                            Id = 2,
                            Description = "Описание 2 теста",
                            Name = "Вопросы среднего уровня",
                            OwnerId = "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                            Time = 16L
                        },
                        new
                        {
                            Id = 3,
                            Description = "Описание 3 теста",
                            Name = "Вопросы повышенного уровня",
                            OwnerId = "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                            Time = 20L
                        });
                });

            modelBuilder.Entity("TestPlatform.Core.TestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Answers")
                        .HasColumnType("int");

                    b.Property<int>("RightAnswers")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("finished")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("testResults");
                });

            modelBuilder.Entity("TestUser", b =>
                {
                    b.Property<string>("ParticipantsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PassedTestsId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantsId", "PassedTestsId");

                    b.HasIndex("PassedTestsId");

                    b.ToTable("TestUser");
                });

            modelBuilder.Entity("TestPlatform.Core.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78379fca-3870-46f3-8b54-9fcabae8fea7",
                            Email = "email@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMAIL@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAECxrH31K3xOVVNX7e2kX0zCv/4/vgvkanKiBiXRTLLg8trfghAeu5Yq76+MhtTWpfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("CategoryTest", b =>
                {
                    b.HasOne("TestPlatform.Core.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestPlatform.Core.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestPlatform.Core.Answer", b =>
                {
                    b.HasOne("TestPlatform.Core.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestPlatform.Core.Question", b =>
                {
                    b.HasOne("TestPlatform.Core.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("Testid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("TestPlatform.Core.TestResult", b =>
                {
                    b.HasOne("TestPlatform.Core.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestPlatform.Core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TestUser", b =>
                {
                    b.HasOne("TestPlatform.Core.User", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestPlatform.Core.Test", null)
                        .WithMany()
                        .HasForeignKey("PassedTestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestPlatform.Core.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TestPlatform.Core.Test", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}