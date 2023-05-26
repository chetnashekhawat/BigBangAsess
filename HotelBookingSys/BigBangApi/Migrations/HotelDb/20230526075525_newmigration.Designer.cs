﻿// <auto-generated />
using BigBangApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigBangApi.Migrations.HotelDb
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20230526075525_newmigration")]
    partial class newmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigBangApi.Models.Hotel", b =>
                {
                    b.Property<int>("Hid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Hid"));

                    b.Property<string>("Hlocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hprice")
                        .HasColumnType("int");

                    b.Property<string>("hname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hid");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BigBangApi.Models.Rooms", b =>
                {
                    b.Property<int>("Rid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rid"));

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Hid")
                        .HasColumnType("int");

                    b.Property<decimal>("RPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rid");

                    b.HasIndex("Hid");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BigBangApi.Models.Rooms", b =>
                {
                    b.HasOne("BigBangApi.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("Hid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("BigBangApi.Models.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
