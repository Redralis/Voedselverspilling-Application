﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221022141236_migration6")]
    partial class migration6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Canteen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ServesWarmMeals")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Canteen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Lovensdijkstraat 61",
                            City = "Breda",
                            ServesWarmMeals = true
                        },
                        new
                        {
                            Id = 2,
                            Address = "Lovensdijkstraat 63",
                            City = "Breda",
                            ServesWarmMeals = true
                        },
                        new
                        {
                            Id = 3,
                            Address = "Professor Cobbenhagenlaan 13",
                            City = "Tilburg",
                            ServesWarmMeals = false
                        });
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CanteenId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanteenId = 1,
                            Email = "quinn@email.com",
                            EmployeeNr = "2187362",
                            Name = "Quinn"
                        },
                        new
                        {
                            Id = 2,
                            CanteenId = 3,
                            Email = "hansgerard@email.com",
                            EmployeeNr = "2193726",
                            Name = "Hans Gerard"
                        });
                });

            modelBuilder.Entity("Domain.MealBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CanteenId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEighteen")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWarmMeal")
                        .HasColumnType("bit");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickUpBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PickUpTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.HasIndex("StudentId");

                    b.ToTable("MealBox");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanteenId = 1,
                            City = "Breda",
                            IsEighteen = false,
                            IsWarmMeal = false,
                            MealType = "Brood box",
                            Name = "Brood assortiment",
                            PickUpBy = new DateTime(2022, 11, 12, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 11, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 22.50m
                        },
                        new
                        {
                            Id = 2,
                            CanteenId = 2,
                            City = "Breda",
                            IsEighteen = false,
                            IsWarmMeal = true,
                            MealType = "Warm eten",
                            Name = "Warme maaltijd",
                            PickUpBy = new DateTime(2022, 11, 7, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 5, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            Price = 5.25m
                        },
                        new
                        {
                            Id = 3,
                            CanteenId = 2,
                            City = "Breda",
                            IsEighteen = false,
                            IsWarmMeal = false,
                            MealType = "Drank box",
                            Name = "Drank arrangement",
                            PickUpBy = new DateTime(2022, 11, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 17, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 15.50m
                        },
                        new
                        {
                            Id = 4,
                            CanteenId = 1,
                            City = "Breda",
                            IsEighteen = true,
                            IsWarmMeal = false,
                            MealType = "Alcohol box",
                            Name = "Alcohol arrangement",
                            PickUpBy = new DateTime(2022, 11, 22, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 21, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Price = 30.00m
                        },
                        new
                        {
                            Id = 5,
                            CanteenId = 1,
                            City = "Breda",
                            IsEighteen = false,
                            IsWarmMeal = false,
                            MealType = "Dessert box",
                            Name = "Dessert mix",
                            PickUpBy = new DateTime(2022, 11, 23, 14, 20, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 22, 14, 20, 0, 0, DateTimeKind.Unspecified),
                            Price = 17.50m,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 6,
                            CanteenId = 3,
                            City = "Tilburg",
                            IsEighteen = false,
                            IsWarmMeal = true,
                            MealType = "Warm eten",
                            Name = "Snacks",
                            PickUpBy = new DateTime(2022, 11, 27, 16, 15, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 26, 16, 15, 0, 0, DateTimeKind.Unspecified),
                            Price = 7.50m
                        },
                        new
                        {
                            Id = 7,
                            CanteenId = 1,
                            City = "Breda",
                            IsEighteen = true,
                            IsWarmMeal = false,
                            MealType = "Snoep",
                            Name = "Jesse Pinkman Meth Deluxe Snoep",
                            PickUpBy = new DateTime(2022, 11, 22, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            PickUpTime = new DateTime(2022, 11, 17, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 100.00m
                        });
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAlcoholic = false,
                            Name = "Wit brood",
                            Photo = "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 2,
                            IsAlcoholic = false,
                            Name = "Bruin brood",
                            Photo = "https://images.pexels.com/photos/8599720/pexels-photo-8599720.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 3,
                            IsAlcoholic = false,
                            Name = "Kippenpoten",
                            Photo = "https://images.pexels.com/photos/3926125/pexels-photo-3926125.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 4,
                            IsAlcoholic = false,
                            Name = "Taart",
                            Photo = "https://images.pexels.com/photos/2144112/pexels-photo-2144112.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 5,
                            IsAlcoholic = false,
                            Name = "Cola",
                            Photo = "https://images.pexels.com/photos/50593/coca-cola-cold-drink-soft-drink-coke-50593.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 6,
                            IsAlcoholic = false,
                            Name = "Limonade",
                            Photo = "https://images.pexels.com/photos/96974/pexels-photo-96974.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 7,
                            IsAlcoholic = true,
                            Name = "Bier",
                            Photo = "https://images.pexels.com/photos/1552630/pexels-photo-1552630.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 8,
                            IsAlcoholic = true,
                            Name = "Vodka",
                            Photo = "https://images.pexels.com/photos/1170599/pexels-photo-1170599.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 9,
                            IsAlcoholic = false,
                            Name = "IJs",
                            Photo = "https://images.pexels.com/photos/1294943/pexels-photo-1294943.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 10,
                            IsAlcoholic = false,
                            Name = "Macarons",
                            Photo = "https://images.pexels.com/photos/3776947/pexels-photo-3776947.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 11,
                            IsAlcoholic = false,
                            Name = "Popcorn",
                            Photo = "https://images.pexels.com/photos/33129/popcorn-movie-party-entertainment.jpg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 12,
                            IsAlcoholic = false,
                            Name = "Chips",
                            Photo = "https://images.pexels.com/photos/568805/pexels-photo-568805.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                        },
                        new
                        {
                            Id = 13,
                            IsAlcoholic = false,
                            Name = "Blauw Kristalsnoep",
                            Photo = "https://video-images.vice.com/_uncategorized/1491919892314-Blue-Sky-Candy-1.jpeg?resize=500:*"
                        },
                        new
                        {
                            Id = 14,
                            IsAlcoholic = false,
                            Name = "Normaal Kristalsnoep",
                            Photo = "https://cdn11.bigcommerce.com/s-1b75a/images/stencil/500w/products/138/3144/DSCN1797__13248.1652210117.JPG?c=2"
                        });
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student", t =>
                        {
                            t.HasCheckConstraint("CK_DateOfBirth_NotInFuture", "DateOfBirth <= GetDate()");

                            t.HasCheckConstraint("CK_DateOfBirth_NotUnder16", "DateOfBirth <= DATEADD(yyyy,-16,getdate())");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Dordrecht",
                            DateOfBirth = "2003-01-27",
                            Email = "lucas@email.com",
                            Name = "Lucas",
                            PhoneNr = "0692837263",
                            StudentNr = "2191372"
                        },
                        new
                        {
                            Id = 2,
                            City = "Dordrecht",
                            DateOfBirth = "2005-01-19",
                            Email = "jaron@email.com",
                            Name = "Jaron",
                            PhoneNr = "0682731928",
                            StudentNr = "2194746"
                        });
                });

            modelBuilder.Entity("MealBoxProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("MealBoxId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "MealBoxId");

                    b.HasIndex("MealBoxId");

                    b.ToTable("MealBoxProduct");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            MealBoxId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            MealBoxId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            MealBoxId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            MealBoxId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            MealBoxId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            MealBoxId = 3
                        },
                        new
                        {
                            ProductId = 6,
                            MealBoxId = 3
                        },
                        new
                        {
                            ProductId = 7,
                            MealBoxId = 4
                        },
                        new
                        {
                            ProductId = 8,
                            MealBoxId = 4
                        },
                        new
                        {
                            ProductId = 9,
                            MealBoxId = 5
                        },
                        new
                        {
                            ProductId = 10,
                            MealBoxId = 5
                        },
                        new
                        {
                            ProductId = 11,
                            MealBoxId = 6
                        },
                        new
                        {
                            ProductId = 12,
                            MealBoxId = 6
                        },
                        new
                        {
                            ProductId = 6,
                            MealBoxId = 6
                        },
                        new
                        {
                            ProductId = 13,
                            MealBoxId = 7
                        },
                        new
                        {
                            ProductId = 14,
                            MealBoxId = 7
                        });
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.HasOne("Domain.Canteen", "Canteen")
                        .WithMany()
                        .HasForeignKey("CanteenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canteen");
                });

            modelBuilder.Entity("Domain.MealBox", b =>
                {
                    b.HasOne("Domain.Canteen", "Canteen")
                        .WithMany()
                        .HasForeignKey("CanteenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Student", "ReservedBy")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Canteen");

                    b.Navigation("ReservedBy");
                });

            modelBuilder.Entity("MealBoxProduct", b =>
                {
                    b.HasOne("Domain.MealBox", null)
                        .WithMany()
                        .HasForeignKey("MealBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}