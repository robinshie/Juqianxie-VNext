using CommonInitializer;
using DrainagetubeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public interface IDrainageLiquidReporterService
    {   //* 导流液报表 *//
        Task<(int, IEnumerable<DrainageLiquidReporter>)> FindRangeLiquidReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken);
        
    }
}
