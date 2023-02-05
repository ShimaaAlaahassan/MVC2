﻿// <auto-generated />
using System;
using MVC2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC2.Migrations
{
    [DbContext(typeof(MVC_DemoDbContext))]
    [Migration("20230205145042_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.Property<int?>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Number"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("emp_m")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("emp_m")
                        .IsUnique()
                        .HasFilter("[emp_m] IS NOT NULL");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("MVC2.Models.Dependent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ESSN");

                    b.ToTable("dependents");
                });

            modelBuilder.Entity("MVC2.Models.employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperVisorSSN")
                        .HasColumnType("int");

                    b.Property<int?>("deptId_w")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("SuperVisorSSN");

                    b.HasIndex("deptId_w");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("MVC2.Models.location", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("MVC2.Models.project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("DepartmentsNumber")
                        .HasColumnType("int");

                    b.Property<int>("DeptNum")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("DepartmentsNumber");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("MVC2.Models.workOn", b =>
                {
                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<int>("projectNum")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectNumber")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "projectNum");

                    b.HasIndex("ProjectNumber");

                    b.ToTable("workOns");
                });

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.HasOne("MVC2.Models.employee", "EmpManage")
                        .WithOne("deptManage")
                        .HasForeignKey("MVC2.Models.Department", "emp_m");

                    b.Navigation("EmpManage");
                });

            modelBuilder.Entity("MVC2.Models.Dependent", b =>
                {
                    b.HasOne("MVC2.Models.employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("ESSN");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVC2.Models.employee", b =>
                {
                    b.HasOne("MVC2.Models.employee", "SuperVisor")
                        .WithMany("Employees")
                        .HasForeignKey("SuperVisorSSN");

                    b.HasOne("MVC2.Models.Department", "deptWork")
                        .WithMany("EmpWork")
                        .HasForeignKey("deptId_w");

                    b.Navigation("SuperVisor");

                    b.Navigation("deptWork");
                });

            modelBuilder.Entity("MVC2.Models.location", b =>
                {
                    b.HasOne("MVC2.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC2.Models.project", b =>
                {
                    b.HasOne("MVC2.Models.Department", "Departments")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentsNumber");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("MVC2.Models.workOn", b =>
                {
                    b.HasOne("MVC2.Models.employee", "employee")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC2.Models.project", "Project")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("ProjectNumber");

                    b.Navigation("Project");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MVC2.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("EmpWork");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MVC2.Models.employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");

                    b.Navigation("deptManage");
                });

            modelBuilder.Entity("MVC2.Models.project", b =>
                {
                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
