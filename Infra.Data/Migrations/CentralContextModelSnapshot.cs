﻿// <auto-generated />
using System;
using CentralDeErros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentralDeErros.Infra.Data.Migrations
{
    [DbContext(typeof(CentralContext))]
    partial class CentralContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.EnvironmentLevel", b =>
                {
                    b.Property<int>("EnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnvironmentName")
                        .IsRequired()
                        .HasColumnName("ENVIRONMENT")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("EnvironmentId");

                    b.ToTable("ENVIRONMENT");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Error", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnName("CODE")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("EnvironmentId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("TITLE")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("ErrorId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LevelId");

                    b.ToTable("ERROR");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Level", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnName("LEVEL")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("LevelId");

                    b.ToTable("LEVEL");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Logs", b =>
                {
                    b.Property<int>("ErrorOccurrenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived")
                        .HasColumnName("ARCHIVED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("DATE_TIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int?>("ERROR_ID")
                        .HasColumnType("int");

                    b.Property<int>("ErrorId")
                        .HasColumnName("ERRORID")
                        .HasColumnType("int");

                    b.Property<string>("Events")
                        .IsRequired()
                        .HasColumnName("EVENTS")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int?>("LEVEL_ID")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnName("LEVELID")
                        .HasColumnType("int");

                    b.Property<int?>("SituationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("TITLE")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int?>("USER_ID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("USERID")
                        .HasColumnType("int");

                    b.HasKey("ErrorOccurrenceId");

                    b.HasIndex("ERROR_ID");

                    b.HasIndex("LEVEL_ID");

                    b.HasIndex("SituationId");

                    b.HasIndex("USER_ID");

                    b.ToTable("ERROR_OCCURRENCE");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Situation", b =>
                {
                    b.Property<int>("SituationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SituationName")
                        .IsRequired()
                        .HasColumnName("SITUATION")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("SituationId");

                    b.ToTable("SITUATION");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("Expiration")
                        .HasColumnName("EXPIRATION")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .HasColumnName("TOKEN")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.HasKey("UserId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Error", b =>
                {
                    b.HasOne("CentralDeErros.Infra.Entidades.EnvironmentLevel", "Environment")
                        .WithMany("Errors")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentralDeErros.Infra.Entidades.Level", "Level")
                        .WithMany("Errors")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CentralDeErros.Infra.Entidades.Logs", b =>
                {
                    b.HasOne("CentralDeErros.Infra.Entidades.Error", "Error")
                        .WithMany()
                        .HasForeignKey("ERROR_ID");

                    b.HasOne("CentralDeErros.Infra.Entidades.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LEVEL_ID");

                    b.HasOne("CentralDeErros.Infra.Entidades.Situation", null)
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("SituationId");

                    b.HasOne("CentralDeErros.Infra.Entidades.Users", "User")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
