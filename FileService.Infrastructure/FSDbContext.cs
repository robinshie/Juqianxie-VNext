using Juqianxie.DomainCommons.Models;
using Juqianxie.Infrastructure.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FileService.Infrastructure
{
    public class FSDbContext : BaseDbContext
    {
        private IMediator mediator;
        public FSDbContext(DbContextOptions options, IMediator? mediator) : base(options, mediator)
        {
            this.mediator = mediator;
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            if (mediator != null) 
            {
                await mediator.DispatchDomainEventsAsync(this);
            }
            var softDeletedEntities = this.ChangeTracker.Entries<ISoftDelete>().Where(e => e.State == EntityState.Modified && e.Entity.IsDeleted)
                .Select(e => e.Entity).ToList();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            softDeletedEntities.ForEach(e => this.Entry(e).State = EntityState.Detached);
            return result;

        }
    }
}