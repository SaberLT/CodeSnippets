﻿// <auto-generated />
using System;
using CodeSnippets.Database.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeSnippets.Database.Migrations
{
    [DbContext(typeof(CodeSnippetsDbContext))]
    [Migration("20191001130830_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CodeSnippets.Entities.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthData");

                    b.Property<byte>("AuthType");

                    b.Property<DateTime>("LastActionDate");

                    b.Property<string>("Login");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<byte>("Role");

                    b.Property<string>("UserInfo");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}