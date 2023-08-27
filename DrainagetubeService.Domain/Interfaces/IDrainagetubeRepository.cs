using DrainagetubeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public interface IDrainagetubeRepository
    {   //* 导流管 *//
        Task<Drainagetube> AddDrainagetubeAsync(string TubeType, string TubePosition, string TubeExtention, long Uid, string TransID ,CancellationToken cancellationToken);
        Task<Drainagetube> FindByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IEnumerable<Drainagetube>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken);
       
        Task<IEnumerable<Drainagetube>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken);
        Task<IEnumerable<string>> BulkAddDrainagetubeAsync(IEnumerable<Drainagetube> tubeBulkAddRequest, CancellationToken cancellationToken);
    }
}
