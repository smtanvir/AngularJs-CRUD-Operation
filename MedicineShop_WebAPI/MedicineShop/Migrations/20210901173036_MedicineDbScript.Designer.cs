﻿// <auto-generated />
using System;
using MedicineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicineShop.Migrations
{
    [DbContext(typeof(MedicneDbContext))]
    [Migration("20210901173036_MedicineDbScript")]
    partial class MedicineDbScript
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicineShop.Models.GenericGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName");

                    b.HasKey("Id");

                    b.ToTable("GenericGroups");
                });

            modelBuilder.Entity("MedicineShop.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<int>("GenericGroupId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("GenericGroupId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedicineShop.Models.Medicine", b =>
                {
                    b.HasOne("MedicineShop.Models.GenericGroup", "GenericGroup")
                        .WithMany("Medicines")
                        .HasForeignKey("GenericGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
