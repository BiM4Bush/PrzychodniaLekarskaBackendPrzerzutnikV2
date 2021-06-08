﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations.MedicalVisit
{
    [DbContext(typeof(MedicalVisitContext))]
    [Migration("20210608114542_UpdateMV")]
    partial class UpdateMV
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.MedicalVisitModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Confirmed");

                    b.Property<string>("Date");

                    b.Property<Guid>("DoctorId");

                    b.Property<string>("DoctorRecommendation");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Reason");

                    b.Property<string>("Surname");

                    b.Property<string>("Time");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("MedicalVisits");
                });
#pragma warning restore 612, 618
        }
    }
}