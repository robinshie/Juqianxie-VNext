using FileService.Domain.Entities;
using Juqianxie.DomainCommons.Models;
using Juqianxie.Infrastructure.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FileService.Infrastructure
{
    public class FSDbContext : BaseDbContext
    {
        public DbSet<UploadedItem> UploadItems { get; private set; }
        public DbSet<FondConfigs>  FondConfigses { get; private set; }

        private IMediator? mediator;
     
        public FSDbContext(DbContextOptions options, IMediator? mediator)
        : base(options, mediator)
        {
            this.mediator = mediator;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}