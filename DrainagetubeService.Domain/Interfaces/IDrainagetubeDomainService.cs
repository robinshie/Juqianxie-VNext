using DrainagetubeService.Domain.Entities;

namespace DrainagetubeService.Domain
{
    public interface IDrainagetubeDomainService
    {
        Task<Drainagetube> AddDrainagetubeAsync(string TubeType, string TubePosition, string TubeExtention, long Uid ,CancellationToken cancellationToken);
        Task<IEnumerable<Drainagetube>> FindByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IEnumerable<Drainagetube>> FindByuserAsync(long uid, int pageindex, int pageLen , CancellationToken cancellationToken);
        Task<IEnumerable<Drainagetube>> FindAllByPageAsync(int pageindex,int pageLen, CancellationToken cancellationToken);
    }
}
