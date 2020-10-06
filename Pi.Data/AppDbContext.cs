using Microsoft.EntityFrameworkCore;
using Pi.Core.Entity;
using Pi.Data.Configurations;
using Pi.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.Data
{
   public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Appuser> Appusers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new AppuserSeed(new int[] { 1,2 }));



            modelBuilder.Entity<Appuser>().HasKey(x => x.Id);
            modelBuilder.Entity<Appuser>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Appuser>().Property(x => x.Name).HasMaxLength(100);

            modelBuilder.Entity<Appuser>().Property(x => x.SurName).HasMaxLength(100);

        }


    }
    }
    