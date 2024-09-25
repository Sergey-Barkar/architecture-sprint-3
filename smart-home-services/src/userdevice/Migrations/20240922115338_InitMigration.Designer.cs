﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartHomeSystem.Context;

#nullable disable

namespace userdevice.Migrations
{
    [DbContext(typeof(UserDeviceContext))]
    [Migration("20240922115338_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartHomeSystem.Model.UserDevice", b =>
                {
                    b.Property<int?>("UserDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("UserDeviceId"));

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("UserDeviceId");

                    b.ToTable("UserDevice");

                    b.HasData(
                        new
                        {
                            UserDeviceId = 2,
                            UserId = 1
                        },
                        new
                        {
                            UserDeviceId = 3,
                            UserId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
