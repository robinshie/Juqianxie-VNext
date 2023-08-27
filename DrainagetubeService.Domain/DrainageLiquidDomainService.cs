using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public class DrainageLiquidDomainService : IDrainageLiquidDomainService
    {
        private readonly IDrainageLiquidRepository repository;
        public DrainageLiquidDomainService(IDrainageLiquidRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DrainageLiquid> AddDrainageLiquidAsync(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken)
        {
            return await repository.AddDrainagetubeAsync(RecordTime, LiquidColor, LiquidProperty, Liquidodour, TubeState, Volume, Uid, Tubekey,cancellationToken);
        }

        public Task<DrainageLiquid> AddDrainageLiquidAsync(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, float Volume, long Uid, string Tubekey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<int> BulkAddDrainageLiquidAsync(IEnumerable<DrainageLiquid> bulkAddRequest, CancellationToken cancellationToken)
        {
            return await repository.BulkAddDrainageLiquidAsync(bulkAddRequest, cancellationToken); 
        }

        public async Task<IEnumerable<DrainageLiquid>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindAllByPageAsync(pageindex, pageLen, cancellationToken);
        }

        public async Task<DrainageLiquid> FindByKeyAsync(string key, CancellationToken cancellationToken)
        {
            return await repository.FindByKeyAsync(key, cancellationToken);
        }

        public async Task<IEnumerable<DrainageLiquid>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindByuserAsync(uid, pageindex, pageLen, cancellationToken);
        }
    }
}
