﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210811112417_AddDriverTable")]
    partial class AddDriverTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TalabatApi.Domain.Model.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("DriverLocation")
                        .HasColumnType("bigint");

                    b.Property<string>("DriverName")
                        .HasColumnType("text");

                    b.Property<int>("OrdersDelivered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp");

                    b.Property<bool>("Delivered")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DeliveryPrice")
                        .HasColumnType("int");

                    b.Property<bool>("OrderedAgreed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RestName")
                        .HasColumnType("text");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RestuarantId")
                        .HasColumnType("int");

                    b.Property<string>("RestuarantName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RestuarantId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.Restuarant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("DeliveryPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Offer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Restuarants");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(4000)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(4000)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.UserData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserAddress")
                        .HasColumnType("text");

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

            modelBuilder.Entity("TalabatApi.Domain.Model.Order", b =>
                {
                    b.HasOne("TalabatApi.Domain.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.Product", b =>
                {
                    b.HasOne("TalabatApi.Domain.Model.Restuarant", "Restuarant")
                        .WithMany("Products")
                        .HasForeignKey("RestuarantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TalabatApi.Domain.Model.UserData", b =>
                {
                    b.HasOne("TalabatApi.Domain.Model.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("TalabatApi.Domain.Model.UserData", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
