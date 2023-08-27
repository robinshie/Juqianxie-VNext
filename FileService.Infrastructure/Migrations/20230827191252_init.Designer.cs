﻿// <auto-generated />
using System;
using FileService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileService.Infrastructure.Migrations
{
    [DbContext(typeof(FSDbContext))]
    [Migration("20230827191252_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileService.Domain.Entities.FondConfigs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_FS_FondConfigs", (string)null);
                });

            modelBuilder.Entity("FileService.Domain.Entities.UploadedItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BackupUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("FileSHA256Hash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.Property<string>("RemoteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("FileSHA256Hash", "FileSizeInBytes");

                    b.ToTable("T_FS_UploadedItems", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}