using DrainagetubeService.Domain.Entities;
using Juqianxie.Infrastructure.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Infrastructure
{
    public class DrainageDbContext : BaseDbContext
    {
        public DbSet<DrainageLiquid> DrainageLiquids { get; private set; }
        public DbSet<Drainagetube> Drainagetubes { get; private set; }
        public DrainageDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
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
