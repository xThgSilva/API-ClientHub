﻿using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infraestructure
{
    public class ProductClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Thiago\\Downloads\\1737062251373-attachment.octet-stream");
        }
    }
}
