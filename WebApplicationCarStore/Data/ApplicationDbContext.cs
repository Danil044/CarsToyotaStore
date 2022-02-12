using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyIdentityUser>
    {

        public DbSet<Entities.Color> Colors { get; set; }

        public DbSet<Entities.Model> Models { get; set; }

        public DbSet<Entities.Modification> Modifications { get; set; }

        public DbSet<Entities.ModificationColor> ModificationColors { get; set; }

        public DbSet<Entities.CallBack> CallBack { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CallBack>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
