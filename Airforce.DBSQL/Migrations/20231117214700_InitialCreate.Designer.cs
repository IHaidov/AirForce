﻿// <auto-generated />
using Alesik.Haidov.Airforce.DBSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alesik.Haidov.Airforce.DBSQL.Migrations
{
    [DbContext(typeof(DAOSQL))]
    [Migration("20231117214700_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Alesik.Haidov.Airforce.DBSQL.AirbaseDBSQL", b =>
                {
                    b.Property<string>("GUID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GUID");

                    b.ToTable("AirbaseRelation");
                });

            modelBuilder.Entity("Alesik.Haidov.Airforce.DBSQL.AircraftDBSQL", b =>
                {
                    b.Property<string>("GUID")
                        .HasColumnType("TEXT");

                    b.Property<string>("AirbaseGUID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("GUID");

                    b.ToTable("AircraftRelation");
                });
#pragma warning restore 612, 618
        }
    }
}
