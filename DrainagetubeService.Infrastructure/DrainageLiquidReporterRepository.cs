using System;
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
    public class DrainageLiquidReporterRepository : IDrainageLiquidReporterRepository
    {
        private readonly DrainageDbContext dbcontext;
        public DrainageLiquidReporterRepository(DrainageDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task AddRangeLiquidReporter(IEnumerable<DrainageLiquidReporter> drainageLiquidReporters, CancellationToken cancellationToken)
        {
            await dbcontext.DrainageLiquidReporters.AddRangeAsync(drainageLiquidReporters, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }
    }
}
