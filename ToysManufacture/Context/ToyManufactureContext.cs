using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ToysManufacture.Models;

namespace ToysManufacture.Context
{
    class ToyManufactureContext:DbContext
    {
        private const string connctionString = "server=DESKTOP-HQIELD6\\SQLEXPRESS;Database=ToyManufactureDb;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connctionString);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Toy> Toys { get; set; }

        public DbSet<vOrderDetail> vOrderDetails { get; set; }




    }
}
