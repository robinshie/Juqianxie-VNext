using DrainagetubeService.Domain.Entities;

namespace DrainagetubeService.Domain
{
    public interface IDrainageLiquidDomainService
    {
        Task<DrainageLiquid> AddDrainageLiquidAsync(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken);
        Task<DrainageLiquid> FindByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageLiquid>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageLiquid>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken);

    }
}
