﻿// <auto-generated />
using System;
using BusesServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusesServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240519154544_SixClasses2")]
    partial class SixClasses2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusesServer.Data.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusRouteDirectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusRouteDirectionId");

                    b.ToTable("BusRoutes");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRouteDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("BusRouteDirections");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRouteStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusRouteDirectionId")
                        .HasColumnType("int");

                    b.Property<int?>("BusStopId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusRouteDirectionId");

                    b.HasIndex("BusStopId");

                    b.ToTable("BusRouteStops");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BusStops");
                });

            modelBuilder.Entity("BusesServer.Data.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusId")
                        .HasColumnType("int");

                    b.Property<int?>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<int?>("BusStopId")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<string>("RouteInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("BusRouteId");

                    b.HasIndex("BusStopId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRoute", b =>
                {
                    b.HasOne("BusesServer.Data.Models.BusRouteDirection", "BusRouteDirection")
                        .WithMany()
                        .HasForeignKey("BusRouteDirectionId");

                    b.Navigation("BusRouteDirection");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRouteDirection", b =>
                {
                    b.HasOne("BusesServer.Data.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("BusesServer.Data.Models.BusRouteStop", b =>
                {
                    b.HasOne("BusesServer.Data.Models.BusRouteDirection", "BusRouteDirection")
                        .WithMany()
                        .HasForeignKey("BusRouteDirectionId");

                    b.HasOne("BusesServer.Data.Models.BusStop", "BusStop")
                        .WithMany()
                        .HasForeignKey("BusStopId");

                    b.Navigation("BusRouteDirection");

                    b.Navigation("BusStop");
                });

            modelBuilder.Entity("BusesServer.Data.Models.Departure", b =>
                {
                    b.HasOne("BusesServer.Data.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.HasOne("BusesServer.Data.Models.BusRoute", "BusRoute")
                        .WithMany()
                        .HasForeignKey("BusRouteId");

                    b.HasOne("BusesServer.Data.Models.BusStop", "BusStop")
                        .WithMany()
                        .HasForeignKey("BusStopId");

                    b.Navigation("Bus");

                    b.Navigation("BusRoute");

                    b.Navigation("BusStop");
                });
#pragma warning restore 612, 618
        }
    }
}