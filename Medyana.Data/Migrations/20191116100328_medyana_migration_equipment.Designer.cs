﻿// <auto-generated />
using System;
using Medyana.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medyana.Data.Migrations
{
    [DbContext(typeof(MedyanaContext))]
    [Migration("20191116100328_medyana_migration_equipment")]
    partial class medyana_migration_equipment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Medyana.Data.Model.MedClinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedClinic");
                });

            modelBuilder.Entity("Medyana.Data.Model.MedEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int?>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int>("CountInfo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProvideDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<double>("UsageRate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("MedEquipment");
                });

            modelBuilder.Entity("Medyana.Data.Model.MedEquipment", b =>
                {
                    b.HasOne("Medyana.Data.Model.MedClinic", "Clinic")
                        .WithMany("Equipments")
                        .HasForeignKey("ClinicId");
                });
#pragma warning restore 612, 618
        }
    }
}
