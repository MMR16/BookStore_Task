﻿// <auto-generated />
using System;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Rented")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Microsoft",
                            Available = false,
                            Code = "as123",
                            Rented = true,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Microsoft",
                            Available = false,
                            Code = "as456",
                            Rented = true,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Microsoft",
                            Available = false,
                            Code = "as789",
                            Rented = true,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Google",
                            Available = false,
                            Code = "we1111",
                            Rented = true,
                            Title = "Angular"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Google",
                            Available = false,
                            Code = "we9874",
                            Rented = true,
                            Title = "Angular"
                        },
                        new
                        {
                            Id = 6,
                            Author = "FaceBook",
                            Available = false,
                            Code = "tr2515",
                            Rented = true,
                            Title = "React"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Sun Microsystems",
                            Available = false,
                            Code = "bv4564",
                            Rented = true,
                            Title = "Java"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Microsoft",
                            Available = true,
                            Code = "gf444",
                            Rented = false,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Microsoft",
                            Available = true,
                            Code = "trt77",
                            Rented = false,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Microsoft",
                            Available = true,
                            Code = "gf5596",
                            Rented = false,
                            Title = "dotnet"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Google",
                            Available = true,
                            Code = "tr9963",
                            Rented = false,
                            Title = "Angular"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Google",
                            Available = true,
                            Code = "uy5512",
                            Rented = false,
                            Title = "Angular"
                        });
                });

            modelBuilder.Entity("BookStore.Models.BookBorrower", b =>
                {
                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("BorrowerId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "BorrowerId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("bookBorrowers");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BorrowerId = 1
                        },
                        new
                        {
                            BookId = 3,
                            BorrowerId = 1
                        },
                        new
                        {
                            BookId = 7,
                            BorrowerId = 1
                        },
                        new
                        {
                            BookId = 2,
                            BorrowerId = 2
                        },
                        new
                        {
                            BookId = 4,
                            BorrowerId = 2
                        },
                        new
                        {
                            BookId = 5,
                            BorrowerId = 3
                        },
                        new
                        {
                            BookId = 6,
                            BorrowerId = 4
                        });
                });

            modelBuilder.Entity("BookStore.Models.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NationalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("borrowers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mostafa",
                            NationalId = 120365
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ali",
                            NationalId = 787454
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ahmed",
                            NationalId = 477449
                        },
                        new
                        {
                            Id = 4,
                            Name = "Alaa",
                            NationalId = 8854471
                        });
                });

            modelBuilder.Entity("BookStore.Models.BookBorrower", b =>
                {
                    b.HasOne("BookStore.Models.Book", "Book")
                        .WithMany("BookBorrowers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Models.Borrower", "Borrower")
                        .WithMany("BookBorrowers")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Borrower");
                });

            modelBuilder.Entity("BookStore.Models.Book", b =>
                {
                    b.Navigation("BookBorrowers");
                });

            modelBuilder.Entity("BookStore.Models.Borrower", b =>
                {
                    b.Navigation("BookBorrowers");
                });
#pragma warning restore 612, 618
        }
    }
}