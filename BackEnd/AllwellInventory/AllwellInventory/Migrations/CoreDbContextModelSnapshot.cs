﻿// <auto-generated />
using System;
using AllwellInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllwellInventory.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllwellInventory.Models.AssignLog", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("assignedDate");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employeeId");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("productId");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("returnedDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.ToTable("assign_log");
                });

            modelBuilder.Entity("AllwellInventory.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("isAdmin");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(14)
                        .HasColumnType("nchar(14)")
                        .HasColumnName("password")
                        .IsFixedLength(true);

                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("username")
                        .IsFixedLength(true);

                    b.Property<string>("fName")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("fName")
                        .IsFixedLength(true);

                    b.Property<bool>("inactive")
                        .HasColumnType("bit")
                        .HasColumnName("inactive");

                    b.Property<string>("lName")
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("lName")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("AllwellInventory.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("city")
                        .IsFixedLength(true);

                    b.Property<string>("County")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("county")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.HasKey("LocationId");

                    b.ToTable("location");
                });

            modelBuilder.Entity("AllwellInventory.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("condition")
                        .IsFixedLength(true);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("cost");

                    b.Property<bool>("Damaged")
                        .HasColumnType("bit")
                        .HasColumnName("damaged");

                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("locationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.Property<string>("SerialNo")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("serialNo")
                        .IsFixedLength(true);

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("typeId");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int")
                        .HasColumnName("workerId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TypeId");

                    b.HasIndex("WorkerId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("AllwellInventory.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .HasColumnName("name")
                        .IsFixedLength(true);

                    b.HasKey("TypeId");

                    b.ToTable("type");
                });

            modelBuilder.Entity("AllwellInventory.Models.AssignLog", b =>
                {
                    b.HasOne("AllwellInventory.Models.Employee", "Employee")
                        .WithMany("AssignLogs")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_assign_log_Employee")
                        .IsRequired();

                    b.HasOne("AllwellInventory.Models.Product", "Product")
                        .WithMany("AssignLogs")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_assign_log_Products")
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AllwellInventory.Models.Employee", b =>
                {
                    b.HasOne("AllwellInventory.Models.Location", null)
                        .WithMany("Employees")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("AllwellInventory.Models.Product", b =>
                {
                    b.HasOne("AllwellInventory.Models.Location", "Location")
                        .WithMany("Products")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Products_Location")
                        .IsRequired();

                    b.HasOne("AllwellInventory.Models.Type", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Products_Type")
                        .IsRequired();

                    b.HasOne("AllwellInventory.Models.Employee", "Worker")
                        .WithMany("Products")
                        .HasForeignKey("WorkerId")
                        .HasConstraintName("FK_Products_Employee");

                    b.Navigation("Location");

                    b.Navigation("Type");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("AllwellInventory.Models.Employee", b =>
                {
                    b.Navigation("AssignLogs");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("AllwellInventory.Models.Location", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("AllwellInventory.Models.Product", b =>
                {
                    b.Navigation("AssignLogs");
                });

            modelBuilder.Entity("AllwellInventory.Models.Type", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}