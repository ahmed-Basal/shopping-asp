using core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace inftastructer.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<category> Categories { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<photo> Photos { get; set; }
        public virtual DbSet<Address> address { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<orderitem> orderItems { get; set; }
        public virtual DbSet<DeliveryMethod> deliveryMethods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
