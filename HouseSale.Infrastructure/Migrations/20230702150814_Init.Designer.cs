﻿// <auto-generated />
using System;
using HouseSale.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HouseSale.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230702150814_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HouseSale.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.BoolTypeEntities.LocatedNearby", b =>
                {
                    b.Property<Guid>("LocatedNearbyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("EntertainmentInstitutions")
                        .HasColumnType("boolean");

                    b.Property<bool>("Hospital")
                        .HasColumnType("boolean");

                    b.Property<bool>("Kindergarten")
                        .HasColumnType("boolean");

                    b.Property<bool>("Park")
                        .HasColumnType("boolean");

                    b.Property<bool>("Playground")
                        .HasColumnType("boolean");

                    b.Property<bool>("Residence")
                        .HasColumnType("boolean");

                    b.Property<bool>("Restaurants")
                        .HasColumnType("boolean");

                    b.Property<bool>("School")
                        .HasColumnType("boolean");

                    b.Property<bool>("Stations")
                        .HasColumnType("boolean");

                    b.Property<bool>("Supermarkets")
                        .HasColumnType("boolean");

                    b.HasKey("LocatedNearbyId");

                    b.ToTable("LocatedNearbies");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.BoolTypeEntities.ThereIsInHouse", b =>
                {
                    b.Property<Guid>("ThereIsInHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Canalization")
                        .HasColumnType("boolean");

                    b.Property<bool>("Cellar")
                        .HasColumnType("boolean");

                    b.Property<bool>("Ethernet")
                        .HasColumnType("boolean");

                    b.Property<bool>("Garage")
                        .HasColumnType("boolean");

                    b.Property<bool>("GreenZone")
                        .HasColumnType("boolean");

                    b.Property<bool>("Gym")
                        .HasColumnType("boolean");

                    b.Property<bool>("Phone")
                        .HasColumnType("boolean");

                    b.Property<bool>("Pool")
                        .HasColumnType("boolean");

                    b.Property<bool>("Security")
                        .HasColumnType("boolean");

                    b.HasKey("ThereIsInHouseId");

                    b.ToTable("ThereIsInHouses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.CategoryHomeSituation", b =>
                {
                    b.Property<Guid>("CategoryHomeSituationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HomeSituationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryHomeSituationId");

                    b.ToTable("HomeSituations");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.CategoryRentSale", b =>
                {
                    b.Property<Guid>("CategoryRentSaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryRentSaleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryRentSaleId");

                    b.ToTable("CategoryRentSales");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.House", b =>
                {
                    b.Property<Guid>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<Guid>("CategoryHomeSituationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryRentSaleId")
                        .HasColumnType("uuid");

                    b.Property<int>("CountOfRoom")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("LocatedNearbyId")
                        .HasColumnType("uuid");

                    b.Property<string>("MainImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ThereIsInHouseId")
                        .HasColumnType("uuid");

                    b.HasKey("HouseId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CategoryHomeSituationId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryRentSaleId");

                    b.HasIndex("LocatedNearbyId")
                        .IsUnique();

                    b.HasIndex("ThereIsInHouseId")
                        .IsUnique();

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.HouseImage", b =>
                {
                    b.Property<Guid>("HouseImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HouseImageId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseImages");
                });

            modelBuilder.Entity("HouseSale.Domain.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HouseSale.Domain.PageEntities.PageEntity", b =>
                {
                    b.Property<Guid>("PageEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string[]>("ImagesPath")
                        .HasColumnType("text[]");

                    b.Property<string>("OtherText")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PageEntityId");

                    b.ToTable("PageEntities");
                });

            modelBuilder.Entity("HouseSale.Domain.PageEntities.SocialContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SocialContacts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.House", b =>
                {
                    b.HasOne("HouseSale.Domain.Entities.Address", "Address")
                        .WithMany("Houses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Entities.CategoryHomeSituation", "CategoryHomeSituation")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryHomeSituationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Entities.Category", "Category")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Entities.CategoryRentSale", "CategoryRentSale")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryRentSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Entities.BoolTypeEntities.LocatedNearby", "LocatedNearby")
                        .WithOne("House")
                        .HasForeignKey("HouseSale.Domain.Entities.House", "LocatedNearbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Entities.BoolTypeEntities.ThereIsInHouse", "Comfort")
                        .WithOne("House")
                        .HasForeignKey("HouseSale.Domain.Entities.House", "ThereIsInHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Category");

                    b.Navigation("CategoryHomeSituation");

                    b.Navigation("CategoryRentSale");

                    b.Navigation("Comfort");

                    b.Navigation("LocatedNearby");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.HouseImage", b =>
                {
                    b.HasOne("HouseSale.Domain.Entities.House", "House")
                        .WithMany("HouseImages")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HouseSale.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HouseSale.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseSale.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HouseSale.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.Address", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.BoolTypeEntities.LocatedNearby", b =>
                {
                    b.Navigation("House")
                        .IsRequired();
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.BoolTypeEntities.ThereIsInHouse", b =>
                {
                    b.Navigation("House")
                        .IsRequired();
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.Category", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.CategoryHomeSituation", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.CategoryRentSale", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("HouseSale.Domain.Entities.House", b =>
                {
                    b.Navigation("HouseImages");
                });
#pragma warning restore 612, 618
        }
    }
}
