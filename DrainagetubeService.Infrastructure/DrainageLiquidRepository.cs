using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DrainagetubeService.Infrastructure
{
    public class DrainageLiquidRepository : IDrainageLiquidRepository
    {
        private readonly DrainageDbContext dbcontext;
        public DrainageLiquidRepository(DrainageDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<DrainageLiquid> AddDrainagetubeAsync(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken)
        {
            return await Add(RecordTime, LiquidColor, LiquidProperty, Liquidodour, TubeState, Volume, Uid,  Tubekey, cancellationToken);
        }

        public async Task<IEnumerable<DrainageLiquid>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageLiquids.Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync();
        }

        public async Task<DrainageLiquid> FindByKeyAsync(string key, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageLiquids.FirstOrDefaultAsync(u => u.Key.ToString() == key);
        }

        public async Task<IEnumerable<DrainageLiquid>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await dbcontext.DrainageLiquids.Where(u => u.Uid == uid).Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync();
        }
        private async Task<DrainageLiquid> Add(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken)
        {
            DrainageLiquid drainagetube = new DrainageLiquid();
            drainagetube.Create(RecordTime, LiquidColor, LiquidProperty, Liquidodour, TubeState, Volume, Uid,Tubekey);
            await dbcontext.DrainageLiquids.AddAsync(drainagetube, cancellationToken);
            await dbcontext.SaveChangesAsync();

            return await dbcontext.DrainageLiquids.FirstOrDefaultAsync(u => u.Key == drainagetube.Key, cancellationToken);
        }
    }
}
