using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonInitializer;
using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;

using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;

namespace DrainagetubeService.Infrastructure
{
    public class DrainageLiquidReporterRepository : IDrainageLiquidReporterRepository
    {
        private readonly DrainageDbContext dbcontext;

        public DrainageLiquidReporterRepository(DrainageDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task AddRangeLiquidReporter(IEnumerable<DrainageLiquidReporter> drainageLiquidReporters, CancellationToken cancellationToken)
        {
            await dbcontext.DrainageLiquidReporters.AddRangeAsync(drainageLiquidReporters, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<(int,IEnumerable<DrainageLiquidReporter>)> FindRangeLiquidReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            var datas = dbcontext.DrainageLiquidReporters.Select(q=>q);
            if (conditions != null && conditions.Count()>0)
            {
                foreach (var condition in conditions)
                {
                    datas = datas.Where(conditions);
                }
            }
            datas = datas.Order(conditions);
            int len = 0;
           
            if (pageindex > 0 && pageLen > 0) 
            {
                datas = datas.Pager(pageindex, pageLen, out len);
            }
            var list = await datas.ToListAsync(cancellationToken);
            return (len, list);
        }
    }
}
