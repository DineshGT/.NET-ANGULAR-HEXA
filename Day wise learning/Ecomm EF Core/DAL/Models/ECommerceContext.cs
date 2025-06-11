using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ECommerceContext:DbContext
    {
        //To declare prop. of type DbSet<Entity>

        public DbSet<AdminInfo> AdminInfos { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To configure a connection string
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //It can contain configuration of entities/model classes using fluent api

            //One-To-Many (CustomerInfo-Order) (This relationship can be created using DataAnnotation)
            modelBuilder.Entity<Order>().HasOne<CustomerInfo>().WithMany().HasForeignKey(cust=>cust.EmailId);

            //Add Seed data for default admin
            modelBuilder.Entity<AdminInfo>().HasData(
                new AdminInfo { EmailId="admin@gmail.com",Password="admin123",Role="Admin"}
                );

            //To declare a shadow property
            modelBuilder.Entity<Product>().Property<DateTime>("CreationDate").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
