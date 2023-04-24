using Juqianxie.DomainCommons.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juqianxie.Infrastructure.EFCore
{
    public abstract class BaseDbContext : DbContext
    {
        private IMediator? mediator;
        public BaseDbContext(DbContextOptions options, IMediator? mediator)
        {
            this.mediator = mediator;

        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            if (mediator != null)
            {
                await mediator.DispatchDomainEventsAsync(this);
            }
            var softDeletedEntities = this.ChangeTracker.Entries<ISoftDelete>()
                .Where(e => e.State == EntityState.Modified && e.Entity.IsDeleted)
                .Select(e => e.Entity).ToList();//在提交到数据库之前，记录那些被“软删除”实体对象。一定要ToList()，否则会延迟到ForEach的时候才执行

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            softDeletedEntities.ForEach(e => this.Entry(e).State = EntityState.Detached);//把被软删除的对象从Cache删除，否则FindAsync()还能根据Id获取到这条数据
            //因为FindAsync如果能从本地Cache找到，就不会去数据库上查询，而从本地Cache找的过程中不会管QueryFilter
            //就会造成已经软删除的数据仍然能够通过FindAsync查到的问题，因此这里把对应跟踪对象的state改为Detached，就会从缓存中删除了
            return result;

        }

    }
}
