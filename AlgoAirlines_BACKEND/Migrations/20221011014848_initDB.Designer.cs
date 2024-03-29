﻿// <auto-generated />
using System;
using AlgoAirlines_BACKEND.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlgoAirlines_BACKEND.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221011014848_initDB")]
    partial class initDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Aeropuerto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aeropuertos");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Avion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aviones", (string)null);
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Oficial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oficiales");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Pasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroPasaporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pasajeros", (string)null);
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLugarLlegada")
                        .HasColumnType("int");

                    b.Property<int>("IdLugarSalida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvionId");

                    b.HasIndex("IdLugarLlegada");

                    b.HasIndex("IdLugarSalida");

                    b.ToTable("Vuelos", (string)null);
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.VueloPasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPasajero")
                        .HasColumnType("int");

                    b.Property<int>("IdVuelo")
                        .HasColumnType("int");

                    b.Property<int>("PasajeroId")
                        .HasColumnType("int");

                    b.Property<int>("VueloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PasajeroId");

                    b.HasIndex("VueloId");

                    b.ToTable("VuelosPasajeros", (string)null);
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Vuelo", b =>
                {
                    b.HasOne("AlgoAirlines_BACKEND.Entidades.Avion", "Avion")
                        .WithMany("Vuelos")
                        .HasForeignKey("AvionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgoAirlines_BACKEND.Entidades.Aeropuerto", "LugarLlegada")
                        .WithMany("VuelosLlegada")
                        .HasForeignKey("IdLugarLlegada")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlgoAirlines_BACKEND.Entidades.Aeropuerto", "LugarSalida")
                        .WithMany("VuelosSalida")
                        .HasForeignKey("IdLugarSalida")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Avion");

                    b.Navigation("LugarLlegada");

                    b.Navigation("LugarSalida");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.VueloPasajero", b =>
                {
                    b.HasOne("AlgoAirlines_BACKEND.Entidades.Pasajero", "Pasajero")
                        .WithMany("VuelosPasajeros")
                        .HasForeignKey("PasajeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgoAirlines_BACKEND.Entidades.Vuelo", "Vuelo")
                        .WithMany("VuelosPasajeros")
                        .HasForeignKey("VueloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pasajero");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Aeropuerto", b =>
                {
                    b.Navigation("VuelosLlegada");

                    b.Navigation("VuelosSalida");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Avion", b =>
                {
                    b.Navigation("Vuelos");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Pasajero", b =>
                {
                    b.Navigation("VuelosPasajeros");
                });

            modelBuilder.Entity("AlgoAirlines_BACKEND.Entidades.Vuelo", b =>
                {
                    b.Navigation("VuelosPasajeros");
                });
#pragma warning restore 612, 618
        }
    }
}
