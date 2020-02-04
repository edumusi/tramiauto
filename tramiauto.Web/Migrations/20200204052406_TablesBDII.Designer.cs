﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tramiauto.Web.Models;

namespace tramiauto.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200204052406_TablesBDII")]
    partial class TablesBDII
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tramiauto.Web.Models.Entities.Automotor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("NumeroMotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserEmail");

                    b.ToTable("Automotores");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.DatosFiscales", b =>
                {
                    b.Property<string>("Rfc")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("AlcaldiaMunicipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int")
                        .HasMaxLength(6);

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("NumeroExterior")
                        .HasColumnType("int")
                        .HasMaxLength(6);

                    b.Property<string>("NumeroInterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Rfc");

                    b.ToTable("DatosFiscales");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.TipoTramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,4)")
                        .HasMaxLength(7);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TiempoOperacion")
                        .HasColumnType("int")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("TipoTramites");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.Tramite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomotorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,4)")
                        .HasMaxLength(7);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TiempoEntrega")
                        .HasColumnType("int")
                        .HasMaxLength(5);

                    b.Property<int>("TipoTramiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutomotorId");

                    b.HasIndex("TipoTramiteId");

                    b.ToTable("Tramites");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.TramiteAdjuntos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TramiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TramiteId");

                    b.ToTable("TramiteAdjuntos");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("DatosFiscalesRfc")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("FixedPhone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Email");

                    b.HasIndex("DatosFiscalesRfc");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.Automotor", b =>
                {
                    b.HasOne("tramiauto.Web.Models.Entities.User", null)
                        .WithMany("Automotores")
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.Tramite", b =>
                {
                    b.HasOne("tramiauto.Web.Models.Entities.Automotor", "Automotor")
                        .WithMany("Tramites")
                        .HasForeignKey("AutomotorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tramiauto.Web.Models.Entities.TipoTramite", "TipoTramite")
                        .WithMany("Tramites")
                        .HasForeignKey("TipoTramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.TramiteAdjuntos", b =>
                {
                    b.HasOne("tramiauto.Web.Models.Entities.Tramite", "Tramite")
                        .WithMany("Adjuntos")
                        .HasForeignKey("TramiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tramiauto.Web.Models.Entities.User", b =>
                {
                    b.HasOne("tramiauto.Web.Models.Entities.DatosFiscales", "DatosFiscales")
                        .WithMany()
                        .HasForeignKey("DatosFiscalesRfc");
                });
#pragma warning restore 612, 618
        }
    }
}
