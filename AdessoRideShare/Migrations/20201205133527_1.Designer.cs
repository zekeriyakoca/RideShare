﻿// <auto-generated />
using System;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdessoRideShare.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201205133527_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdventurerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("JourneyId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdventurerId");

                    b.HasIndex("JourneyId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JourneyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SeatsAllocated")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdventurerJourney", b =>
                {
                    b.Property<int>("AdventurersId")
                        .HasColumnType("int");

                    b.Property<int>("JourneysId")
                        .HasColumnType("int");

                    b.HasKey("AdventurersId", "JourneysId");

                    b.HasIndex("JourneysId");

                    b.ToTable("AdventurerJourney");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Adventurer", b =>
                {
                    b.HasBaseType("AdessoRideShare.Domain.Entities.User");

                    b.Property<string>("MSISDN")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Adventurers");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Boss", b =>
                {
                    b.HasBaseType("AdessoRideShare.Domain.Entities.User");

                    b.Property<string>("MSISDN")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Bosses");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Amigo", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.Booking", "Booking")
                        .WithMany("Amigos")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Booking", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.Adventurer", "Adventurer")
                        .WithMany()
                        .HasForeignKey("AdventurerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdessoRideShare.Domain.Entities.Journey", "Journey")
                        .WithMany()
                        .HasForeignKey("JourneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adventurer");

                    b.Navigation("Journey");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Journey", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");

                    b.HasOne("AdessoRideShare.Domain.Entities.Location", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId");

                    b.HasOne("AdessoRideShare.Domain.Entities.Boss", "Boss")
                        .WithMany("Journeys")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Boss");

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("AdventurerJourney", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.Adventurer", null)
                        .WithMany()
                        .HasForeignKey("AdventurersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdessoRideShare.Domain.Entities.Journey", null)
                        .WithMany()
                        .HasForeignKey("JourneysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Adventurer", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("AdessoRideShare.Domain.Entities.Adventurer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Boss", b =>
                {
                    b.HasOne("AdessoRideShare.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("AdessoRideShare.Domain.Entities.Boss", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Booking", b =>
                {
                    b.Navigation("Amigos");
                });

            modelBuilder.Entity("AdessoRideShare.Domain.Entities.Boss", b =>
                {
                    b.Navigation("Journeys");
                });
#pragma warning restore 612, 618
        }
    }
}
