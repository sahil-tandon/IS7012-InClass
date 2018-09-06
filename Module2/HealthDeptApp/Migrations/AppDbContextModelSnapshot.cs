﻿// <auto-generated />
using System;
using HealthDeptApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthDeptApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("HealthDeptApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HealthDeptApp.Models.Establishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("ClosedDate");

                    b.Property<bool>("HasLiquorLicense");

                    b.Property<string>("Name");

                    b.Property<DateTime>("OpenDate");

                    b.Property<decimal>("Score");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Establishment");
                });

            modelBuilder.Entity("HealthDeptApp.Models.Establishment", b =>
                {
                    b.HasOne("HealthDeptApp.Models.Category", "Category")
                        .WithMany("Establishments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
