﻿// <auto-generated />
using System;
using CarParts.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarParts.DataAccess.Migrations
{
    [DbContext(typeof(EFDbContext))]
    partial class EFDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CarParts.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsArchive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ParentId");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("tblCategories");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.DbRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.DbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.DbUserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.Filter", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("FilterValueId");

                    b.Property<int>("FilterNameId");

                    b.HasKey("ProductId", "FilterValueId", "FilterNameId");

                    b.HasAlternateKey("FilterNameId", "FilterValueId", "ProductId");

                    b.HasIndex("FilterValueId");

                    b.ToTable("tblFilters");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("tblFilterNames");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterNameCategory", b =>
                {
                    b.Property<int>("FilterNameId");

                    b.Property<int>("CategoryId");

                    b.HasKey("FilterNameId", "CategoryId");

                    b.HasAlternateKey("CategoryId", "FilterNameId");

                    b.ToTable("tblFilterNameCategories");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterNameGroup", b =>
                {
                    b.Property<int>("FilterValueId");

                    b.Property<int>("FilterNameId");

                    b.HasKey("FilterValueId", "FilterNameId");

                    b.HasAlternateKey("FilterNameId", "FilterValueId");

                    b.ToTable("tblFilterNameGroups");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("tblFilterValues");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("ProductionStart");

                    b.Property<DateTime>("ProductionStop");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tblProducts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.Category", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.DbUserRole", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.DbRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarParts.DataAccess.Entities.DbUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.Filter", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.FilterName", "FilterNameOf")
                        .WithMany("Filtres")
                        .HasForeignKey("FilterNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarParts.DataAccess.Entities.FilterValue", "FilterValueOf")
                        .WithMany("Filtres")
                        .HasForeignKey("FilterValueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarParts.DataAccess.Entities.Product", "ProductOf")
                        .WithMany("Filtres")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterNameCategory", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.Category", "CategoryOf")
                        .WithMany("FilterNameCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarParts.DataAccess.Entities.FilterName", "FilterNameOf")
                        .WithMany("FilterNameCategories")
                        .HasForeignKey("FilterNameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.FilterNameGroup", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.FilterName", "FilterNameOf")
                        .WithMany("FilterNameGroups")
                        .HasForeignKey("FilterNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarParts.DataAccess.Entities.FilterValue", "FilterValueOf")
                        .WithMany("FilterNameGroups")
                        .HasForeignKey("FilterValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarParts.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.DbRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("CarParts.DataAccess.Entities.DbUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
