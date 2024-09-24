﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartHomeSystem.Context;

#nullable disable

namespace userdevicetelemetry.Migrations
{
    [DbContext(typeof(UserDeviceTelemetryContext))]
    partial class UserDeviceTelemetryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartHomeSystem.Model.UserDeviceTelemetry", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("CreatedDateTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UserDeviceId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Value")
                        .HasColumnType("numeric");

                    b.Property<int?>("ValueType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserDeviceTelemetry");
                });
#pragma warning restore 612, 618
        }
    }
}