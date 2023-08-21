using CommonInitializer;
using DrainagetubeService.Domain.Entities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain
{
    public class DrainageLiquidReporterService : IDrainageLiquidReporterService
    {
        private readonly IDrainageLiquidReporterRepository _drainageLiquidReporterRepository;
        public DrainageLiquidReporterService(IDrainageLiquidReporterRepository drainageLiquidReporterRepository)
        {
            _drainageLiquidReporterRepository = drainageLiquidReporterRepository;
        }
        public async Task<(int, IEnumerable<DrainageLiquidReporter>)> FindRangeLiquidReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            return await _drainageLiquidReporterRepository.FindRangeLiquidReporterAsync(pageindex, pageLen, conditions,cancellationToken);
        }
    }
}
