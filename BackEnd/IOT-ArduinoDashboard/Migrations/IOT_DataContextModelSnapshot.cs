﻿// <auto-generated />
using System;
using IOT_ArduinoDashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IOT_ArduinoDashboard.Migrations
{
    [DbContext(typeof(IOT_DataContext))]
    partial class IOT_DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("IOT_ArduinoDashboard.ArduinoModel", b =>
                {
                    b.Property<int>("ArduinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PresetId")
                        .HasColumnType("int");

                    b.HasKey("ArduinoId");

                    b.HasIndex("PresetId");

                    b.ToTable("ArduinoModel");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.Models.AnaloguePin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArduinoId")
                        .HasColumnType("int");

                    b.Property<int>("pinMode")
                        .HasColumnType("int");

                    b.Property<string>("pinString")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ArduinoId");

                    b.ToTable("AnaloguePin");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.Models.ArduinoPresetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnaloguePinCount")
                        .HasColumnType("int");

                    b.Property<int>("DigitalPinCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ArduinoPresetModel");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.Models.DigitalPin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArduinoId")
                        .HasColumnType("int");

                    b.Property<int>("pinMode")
                        .HasColumnType("int");

                    b.Property<int>("pinNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArduinoId");

                    b.ToTable("DigitalPin");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.ArduinoModel", b =>
                {
                    b.HasOne("IOT_ArduinoDashboard.Models.ArduinoPresetModel", "Preset")
                        .WithMany()
                        .HasForeignKey("PresetId");

                    b.Navigation("Preset");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.Models.AnaloguePin", b =>
                {
                    b.HasOne("IOT_ArduinoDashboard.ArduinoModel", "ArduinoModel")
                        .WithMany()
                        .HasForeignKey("ArduinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArduinoModel");
                });

            modelBuilder.Entity("IOT_ArduinoDashboard.Models.DigitalPin", b =>
                {
                    b.HasOne("IOT_ArduinoDashboard.ArduinoModel", "ArduinoModel")
                        .WithMany()
                        .HasForeignKey("ArduinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArduinoModel");
                });
#pragma warning restore 612, 618
        }
    }
}