﻿    using CarParts.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarParts.DataAccess
{
    public class EFDbContext : IdentityDbContext<DbUser, DbRole, int, IdentityUserClaim<int>,
  DbUserRole, IdentityUserLogin<int>,
  IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
            
        }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<FilterNameCategory> FilterNameCategories { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<AllCar> AllCars { get; set; }

        // <summary>
        /// Filter tables
        /// </summary>
        /// 
        public DbSet<FilterName> FilterNames { get; set; }

        public DbSet<FilterValue> FilterValues { get; set; }

        public DbSet<FilterNameGroup> FilterNameGroups { get; set; }

        public DbSet<Filter> Filters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            /////////
            ///Filter
            /////////
            builder.Entity<Filter>(filter =>
            {
                filter.HasKey(f => new { f.ProductId, f.FilterValueId, f.FilterNameId });

                filter.HasOne(ur => ur.FilterNameOf)
                    .WithMany(r => r.Filtres)
                    .HasForeignKey(ur => ur.FilterNameId)
                    .IsRequired();

                filter.HasOne(ur => ur.FilterValueOf)
                    .WithMany(r => r.Filtres)
                    .HasForeignKey(ur => ur.FilterValueId)
                    .IsRequired();

                filter.HasOne(ur => ur.ProductOf)
                    .WithMany(r => r.Filtres)
                    .HasForeignKey(ur => ur.ProductId)
                    .IsRequired();
            });

            builder.Entity<FilterNameGroup>(filterNG =>
            {
                filterNG.HasKey(f => new { f.FilterValueId, f.FilterNameId });

                filterNG.HasOne(ur => ur.FilterNameOf)
                    .WithMany(r => r.FilterNameGroups)
                    .HasForeignKey(ur => ur.FilterNameId)
                    .IsRequired();

                filterNG.HasOne(ur => ur.FilterValueOf)
                    .WithMany(r => r.FilterNameGroups)
                    .HasForeignKey(ur => ur.FilterValueId)
                    .IsRequired();
            });
          
            builder.Entity<FilterNameCategory>(filterNC=>
            {
                filterNC.HasKey(f => new { f.FilterNameId, f.CategoryId });

                filterNC.HasOne(ur => ur.FilterNameOf)
                    .WithMany(r => r.FilterNameCategories)
                    .HasForeignKey(ur => ur.FilterNameId)
                    .IsRequired();

                filterNC.HasOne(ur => ur.CategoryOf)
                    .WithMany(r => r.FilterNameCategories)
                    .HasForeignKey(ur => ur.CategoryId)
                    .IsRequired();
            });
        
    }

        //public virtual DbSet<UserProfile> UserProfiles { get; set; }

        //public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
