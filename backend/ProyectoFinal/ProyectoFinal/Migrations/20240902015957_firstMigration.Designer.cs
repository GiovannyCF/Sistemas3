﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.DataBase;

#nullable disable

namespace ProyectoFinal.Migrations
{
    [DbContext(typeof(ConstructoraDbContext))]
    [Migration("20240902015957_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoFinal.Models.Avance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("date");

                    b.Property<int>("idtarea")
                        .HasColumnType("int");

                    b.Property<string>("observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("porcentaje")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idtarea");

                    b.ToTable("Avance");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Insumo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("date");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Insumo");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Proyecto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("fin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("inicio")
                        .HasColumnType("date");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Tarea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("fin")
                        .HasColumnType("date");

                    b.Property<int>("idproyecto")
                        .HasColumnType("int");

                    b.Property<DateOnly>("inicio")
                        .HasColumnType("date");

                    b.Property<string>("observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idproyecto");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Uso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("date");

                    b.Property<int>("idinsumo")
                        .HasColumnType("int");

                    b.Property<int>("idtarea")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idinsumo");

                    b.HasIndex("idtarea");

                    b.ToTable("Uso");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Avance", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Tarea", "tarea")
                        .WithMany()
                        .HasForeignKey("idtarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tarea");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Tarea", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Proyecto", "proyecto")
                        .WithMany()
                        .HasForeignKey("idproyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("proyecto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Uso", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Insumo", "insumo")
                        .WithMany()
                        .HasForeignKey("idinsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Models.Tarea", "tarea")
                        .WithMany()
                        .HasForeignKey("idtarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("insumo");

                    b.Navigation("tarea");
                });
#pragma warning restore 612, 618
        }
    }
}