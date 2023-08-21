using CommonInitializer;
using DrainagetubeService.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public interface IDrainageUserReporterRepository
    {   //* 导流管 *//
        Task<DrainageUserReporter> AddDrainagetubeAsync(DrainageUserReporter drainageUserReporter , CancellationToken cancellationToken);
        Task<IEnumerable<DrainageUserReporter>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken);
        Task<IEnumerable<DrainageUserReporter>> FindByuserNopageAsync(long uid, CancellationToken cancellationToken);
    
        Task<IEnumerable<string>> FindTubeNameByuserNopageAsync(long uid);
        Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken);
        Task<(int, IEnumerable<DrainageUserReporter>)> FindRangeUserReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken);
    }
}
