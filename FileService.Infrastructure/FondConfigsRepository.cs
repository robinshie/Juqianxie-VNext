using CommonInitializer;
using DrainagetubeService.WebAPI.Controllers.requests;
using FileService.Domain.Entities;
using FileService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Infrastructure
{
    public class FondConfigsRepository : IFondConfigsRepository
    {
        private readonly FSDbContext dbContext;
        public FondConfigsRepository(FSDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<IEnumerable<FondConfigs>> FindAllConfigs(IEnumerable<JConfig> conditions)
        {
            var datas = from q in dbContext.FondConfigses
                        select q;

            return await datas.Where(conditions).ToListAsync();
        }

    }
}

namespace FileService.Infrastructure
{
    public interface IFondConfigsRepository
    {
        Task<IEnumerable<FondConfigs>> FindAllConfigs(IEnumerable<JConfig> conditions);
    }
}