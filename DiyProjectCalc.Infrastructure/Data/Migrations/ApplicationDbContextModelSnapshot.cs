﻿// <auto-generated />
using System;
using DiyProjectCalc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiyProjectCalc.Data.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BasicShapeMaterial", b =>
                {
                    b.Property<int>("BasicShapesId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("int");

                    b.HasKey("BasicShapesId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("BasicShapeMaterial");
                });

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

                    b.Property<int?>("ProjectId")
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

                    b.Property<int?>("ProjectId")
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

            modelBuilder.Entity("BasicShapeMaterial", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.BasicShape", null)
                        .WithMany()
                        .HasForeignKey("BasicShapesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.BasicShape", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", null)
                        .WithMany("BasicShapes")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("DiyProjectCalc.Core.Entities.ProjectAggregate.Material", b =>
                {
                    b.HasOne("DiyProjectCalc.Core.Entities.ProjectAggregate.Project", null)
                        .WithMany("Materials")
                        .HasForeignKey("ProjectId");
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