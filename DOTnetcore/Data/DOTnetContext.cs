using DOTnetcore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.Data
{
    public class DOTnetContext:DbContext
    {
        public DbSet<Product> Products { set; get; }
        public DbSet<Order> Orders { get; set; }

    }
}
