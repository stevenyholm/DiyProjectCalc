﻿// <auto-generated />
using System;
using DiyProjectCalc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiyProjectCalc.Data.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220329054945_rename_pk_fields")]
    partial class rename_pk_fields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.BasicShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Number1")
                        .HasColumnType("float");

                    b.Property<double>("Number2")
                        .HasColumnType("float");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ShapeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("BasicShape", (string)null);
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Depth")
                        .HasColumnType("float");

                    b.Property<double?>("DepthNeeded")
                        .HasColumnType("float");

                    b.Property<double?>("Length")
                        .HasColumnType("float");

                    b.Property<int>("MeasurementType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<double?>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("MaterialBasicShape", b =>
                {
                    b.Property<int>("BasicShapeId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("BasicShapeId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialBasicShape");
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.BasicShape", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", "Project")
                        .WithMany("BasicShapes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.Material", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", "Project")
                        .WithMany("Materials")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MaterialBasicShape", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.BasicShape", null)
                        .WithMany()
                        .HasForeignKey("BasicShapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MaterialBasicShape_BasicShape_BasicShapeId");

                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_MaterialBasicShape_Material_MaterialId");
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", b =>
                {
                    b.Navigation("BasicShapes");

                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
