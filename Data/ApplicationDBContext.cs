using CloudPart3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace CloudPart3.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderRequest> OrderRequests { get; set; }



    }
}
