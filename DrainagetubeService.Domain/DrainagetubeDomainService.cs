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
    public class DrainagetubeDomainService : IDrainagetubeDomainService
    {
        private readonly IDrainagetubeRepository repository;
        public DrainagetubeDomainService(IDrainagetubeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Drainagetube> AddDrainagetubeAsync(string TubeType, string TubePosition, string TubeExtention, long Uid, CancellationToken cancellationToken)
        {
            return await repository.AddDrainagetubeAsync(TubeType, TubePosition, TubeExtention,  Uid, cancellationToken);
        }

        public async Task<IEnumerable<Drainagetube>> FindAllByPageAsync(int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindAllByPageAsync(pageindex, pageLen, cancellationToken);
        }

        public async Task<IEnumerable<Drainagetube>> FindByKeyAsync(string key, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drainagetube>> FindByuserAsync(long uid, int pageindex, int pageLen, CancellationToken cancellationToken)
        {
            return await repository.FindByuserAsync(uid,pageindex, pageLen, cancellationToken);
        }
    }
}
