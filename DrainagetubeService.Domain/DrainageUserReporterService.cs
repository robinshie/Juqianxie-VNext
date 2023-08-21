using CommonInitializer;
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
    public class DrainageUserReporterService : IDrainageUserReporterDomainService
    {
        private readonly IDrainageUserReporterRepository repository;
        public DrainageUserReporterService(IDrainageUserReporterRepository repository)
        {
            this.repository = repository;
        }
        public async  Task<DrainageUserReporter> AddDrainagetubeAsync(DrainageUserReporter drainageUserReporter, CancellationToken cancellationToken)
        {
           return await repository.AddDrainagetubeAsync(drainageUserReporter, cancellationToken);
        }

        public async Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindAllByPageAsync(pageindex, pageLen, cancellationToken);
        }

        public async Task<IEnumerable<DrainageUserReporter>> FindAllByPageAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            return await repository.FindAllByPageAsync(pageindex, pageLen,conditions ,cancellationToken);
        }

        public async Task<IEnumerable<DrainageUserReporter>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindByuserAsync(uid,pageindex, pageLen, cancellationToken);
        }

        public async Task<(int, IEnumerable<DrainageUserReporter>)> FindRangeUserReporterAsync(int pageindex, int pageLen, IEnumerable<JConfig> conditions, CancellationToken cancellationToken)
        {
            return await repository.FindRangeUserReporterAsync(pageindex, pageLen, conditions, cancellationToken);
        }
    }
}
