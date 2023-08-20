using DrainagetubeService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public interface IDrainageLiquidReporterRepository
    {   //* 导流管 *//
        Task AddRangeLiquidReporter(IEnumerable<DrainageLiquidReporter> drainageLiquidReporters, CancellationToken cancellationToken);
        
    }
}
