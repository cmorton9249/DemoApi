﻿// <auto-generated />
using System;
using DemoApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoApi.Migrations
{
    [DbContext(typeof(BooksDataContext))]
    [Migration("20210419143802_FixedReviewOnBook")]
    partial class FixedReviewOnBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoApi.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .IsClustered(false);

                    b.HasIndex("LastName", "FirstName")
                        .IsUnique()
                        .IsClustered();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DemoApi.Domain.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN")
                        .IsClustered();

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DemoApi.Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookISBN");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("DemoApi.Domain.Book", b =>
                {
                    b.HasOne("DemoApi.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DemoApi.Domain.Review", b =>
                {
                    b.HasOne("DemoApi.Domain.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookISBN");
                });

            modelBuilder.Entity("DemoApi.Domain.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DemoApi.Domain.Book", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}