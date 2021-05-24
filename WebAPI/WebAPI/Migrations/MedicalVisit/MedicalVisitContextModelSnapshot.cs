﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations.MedicalVisit
{
    [DbContext(typeof(MedicalVisitContext))]
    partial class MedicalVisitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.DoctorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MedicalSpecialization");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("DoctorModel");
                });

            modelBuilder.Entity("WebAPI.Models.MedicalVisitModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DoctorId");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<bool>("Private");

                    b.Property<string>("Reason");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("MedicalVisits");
                });

            modelBuilder.Entity("WebAPI.Models.MedicalVisitModel", b =>
                {
                    b.HasOne("WebAPI.Models.DoctorModel", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");
                });
#pragma warning restore 612, 618
        }
    }
}
