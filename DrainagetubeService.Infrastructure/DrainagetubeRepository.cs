using System;
using System.Collections;
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
    public class DrainagetubeRepository : IDrainagetubeRepository
    {
        private readonly DrainageDbContext dbcontext;
        public DrainagetubeRepository(DrainageDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Drainagetube> AddDrainagetubeAsync(string TubeType, string TubePosition, string TubeExtention, long Uid,string TransID ,CancellationToken cancellationToken)
        {
            return await Add(TubeType, TubePosition, TubeExtention, Uid, TransID, cancellationToken);
        }

        public async Task<IEnumerable<string>> BulkAddDrainagetubeAsync(IEnumerable<Drainagetube> tubeBulkAddRequest, CancellationToken cancellationToken)
        {
            await dbcontext.Drainagetubes.AddRangeAsync(tubeBulkAddRequest,cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
            return tubeBulkAddRequest.Select(u=>u.Key.ToString());
        }
        public async Task<IEnumerable<Drainagetube>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await dbcontext.Drainagetubes.Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync();
        }

        public async Task<Drainagetube> FindByKeyAsync(string key, CancellationToken cancellationToken)
        {
            return await dbcontext.Drainagetubes.FirstOrDefaultAsync(u=>u.Key.ToString()==key);
        }

        public async Task<IEnumerable<Drainagetube>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            if (pageindex < 0 && pageLen < 0) 
            {
               return await dbcontext.Drainagetubes.Where(u => u.Uid == uid).ToListAsync(cancellationToken);
            }

            return await dbcontext.Drainagetubes.Where(u=>u.Uid==uid).Skip((pageindex - 1) * pageLen).Take(pageLen).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<string>> FindKeysByuserAsync(long uid, CancellationToken cancellationToken)
        {
           return await dbcontext.Drainagetubes.Where(u => u.Uid == uid).Select(u=>u.Key.ToString()).ToListAsync(cancellationToken);
        }

        private async Task<Drainagetube> Add(string TubeType, string TubePosition, string TubeExtention, long Uid,string TransID,CancellationToken cancellationToken)
        {
            //Drainagetube drainagetube = new Drainagetube();
            var drainagetube = Drainagetube.Create(TubeType, TubePosition, TubeExtention,Uid, TransID);
            await dbcontext.Drainagetubes.AddAsync(drainagetube,cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);

            return await dbcontext.Drainagetubes.FirstOrDefaultAsync(u => u.Key == drainagetube.Key, cancellationToken);
        }


    }
}
