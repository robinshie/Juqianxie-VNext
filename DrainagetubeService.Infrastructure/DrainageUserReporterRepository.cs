using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DrainagetubeService.Infrastructure
{
    public class DrainageUserReporterRepository : IDrainageUserReporterRepository
    {
        private readonly DrainageDbContext dbcontext;
        public DrainageUserReporterRepository(DrainageDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<DrainageUserReporter> AddDrainagetubeAsync(DrainageUserReporter drainageUserReporter, CancellationToken cancellationToken)
        {
            return await Add(drainageUserReporter,cancellationToken);
        }
        private async Task<DrainageUserReporter> Add(DrainageUserReporter drainageUserReporter, CancellationToken cancellationToken)
        {
            await dbcontext.DrainageUserReporters.AddAsync(drainageUserReporter, cancellationToken);
            await dbcontext.SaveChangesAsync();

            return await dbcontext.DrainageUserReporters.FirstOrDefaultAsync(u => u.Key == drainageUserReporter.Key, cancellationToken);
        }
        public async Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageUserReporters.Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<DrainageUserReporter>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageUserReporters.Where(u=>u.Uid==uid).Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<DrainageUserReporter>> FindByuserNopageAsync(long uid, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageUserReporters.ToListAsync();
        }

        public async Task<IEnumerable<string>> FindTubeNameByuserNopageAsync(long uid)
        {
           return await dbcontext.Drainagetubes.Where(u => u.Uid == uid).Select(u=>u.TubeType).ToListAsync(CancellationToken.None);
        }

        public Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<(int, IEnumerable<DrainageUserReporter>)> FindRangeUserReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            var datas = dbcontext.DrainageUserReporters.Select(q => q);
            if (conditions != null && conditions.Count() > 0)
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

        public async Task AddRangeDrainagetubeAsync(IEnumerable<DrainageUserReporter> drainageUserReporter, CancellationToken cancellationToken)
        {
            await dbcontext.DrainageUserReporters.AddRangeAsync(drainageUserReporter, cancellationToken);
            await dbcontext.SaveChangesAsync();
        }
    }
}
