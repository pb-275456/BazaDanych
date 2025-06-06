﻿// <auto-generated />
using System;
using BazaDanych;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BazaDanych.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20250403101139_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("BazaDanych.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("lat")
                        .HasColumnType("REAL");

                    b.Property<double?>("lon")
                        .HasColumnType("REAL");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BazaDanych.WeatherEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<double>("feels_like")
                        .HasColumnType("REAL");

                    b.Property<double>("humidity")
                        .HasColumnType("REAL");

                    b.Property<double>("pressure")
                        .HasColumnType("REAL");

                    b.Property<double>("temp")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("WeatherEntries");
                });

            modelBuilder.Entity("BazaDanych.WeatherEntry", b =>
                {
                    b.HasOne("BazaDanych.City", "City")
                        .WithMany("WeatherEntries")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("BazaDanych.City", b =>
                {
                    b.Navigation("WeatherEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
