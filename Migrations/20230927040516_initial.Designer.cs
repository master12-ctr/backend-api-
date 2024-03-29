﻿// <auto-generated />
using System;
using FirstProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FirstProject.Migrations
{
    [DbContext(typeof(UsersdbContext))]
    [Migration("20230927040516_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FirstProject.Models.Department", b =>
                {
                    b.Property<Guid>("Deptid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Deptname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("Parentid")
                        .HasColumnType("uuid");

                    b.HasKey("Deptid");

                    b.HasIndex("Parentid");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FirstProject.Models.Department", b =>
                {
                    b.HasOne("FirstProject.Models.Department", "ParentDepartment")
                        .WithMany("ChildrenDeprtment")
                        .HasForeignKey("Parentid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("FirstProject.Models.Department", b =>
                {
                    b.Navigation("ChildrenDeprtment");
                });
#pragma warning restore 612, 618
        }
    }
}
