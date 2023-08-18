using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityService.Infrastructure
{
    public class IdDbContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public IdDbContext(DbContextOptions<IdDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.EnableSoftDeletionGlobalFilter();

        }
    }
}
