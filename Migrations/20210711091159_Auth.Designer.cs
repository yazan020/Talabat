﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210711091159_Auth")]
    partial class Auth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TalabatApi.Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.UserData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<long>("UserLat")
                        .HasColumnType("bigint");

                    b.Property<long>("UserLong")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersData");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.UserData", b =>
                {
                    b.HasOne("TalabatApi.Domain.Model.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("TalabatApi.Domain.Model.UserData", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.User", b =>
                {
                    b.Navigation("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}