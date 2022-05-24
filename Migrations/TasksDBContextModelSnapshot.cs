﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efFundamentals.Context;

#nullable disable

namespace EntityFrameworkFundamentals.Migrations
{
    [DbContext(typeof(TasksDBContext))]
    partial class TasksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("efFundamentals.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf2"),
                            Name = "Pending activities",
                            Weight = 20
                        },
                        new
                        {
                            Id = new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf3"),
                            Name = "Personal activities",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("efFundamentals.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10be4d76-8e50-4606-8628-ce9aede5cd10"),
                            CategoryId = new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf2"),
                            CreationDate = new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Priority = 1,
                            Title = "Paymente of public sercices"
                        },
                        new
                        {
                            Id = new Guid("10be4d76-8e50-4606-8628-ce9aede5cd20"),
                            CategoryId = new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf3"),
                            CreationDate = new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Priority = 0,
                            Title = "Finish watching movie on Netflix"
                        });
                });

            modelBuilder.Entity("efFundamentals.Models.Task", b =>
                {
                    b.HasOne("efFundamentals.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("efFundamentals.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
