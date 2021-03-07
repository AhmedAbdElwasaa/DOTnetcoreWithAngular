using DOTnetcoreAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcoreAPI.Data
{
    public class DOTnetContext:DbContext
    {
        public DOTnetContext(DbContextOptions<DOTnetContext> option):base(option)
        {

        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Order>()
            //    .HasData(new Order() { });
        }
    }
}
