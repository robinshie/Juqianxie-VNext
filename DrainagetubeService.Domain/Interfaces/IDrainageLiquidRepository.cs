using DrainagetubeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public interface IDrainageLiquidRepository
    {   //* 导流管 *//
        Task<DrainageLiquid> AddDrainagetubeAsync(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken);
        Task<DrainageLiquid> FindByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageLiquid>> FindByTubeKeysAsync(string tubeke, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageLiquid>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageLiquid>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken);

    }
}
