﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR.Models;

namespace SignalR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}