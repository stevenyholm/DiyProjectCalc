﻿// <auto-generated />
using DiyProjectCalc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiyProjectCalc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211229005347_BasicShapes")]
    partial class BasicShapes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DiyProjectCalc.Models.BasicShape", b =>
                {
                    b.Property<int>("BasicShapeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasicShapeId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number1")
                        .HasColumnType("int");

                    b.Property<int>("Number2")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ShapeType")
                        .HasColumnType("int");

                    b.HasKey("BasicShapeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("BasicShapes");
                });

            modelBuilder.Entity("DiyProjectCalc.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DiyProjectCalc.Models.BasicShape", b =>
                {
                    b.HasOne("DiyProjectCalc.Models.Project", "Project")
                        .WithMany("BasicShapes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DiyProjectCalc.Models.Project", b =>
                {
                    b.Navigation("BasicShapes");
                });
#pragma warning restore 612, 618
        }
    }
}
