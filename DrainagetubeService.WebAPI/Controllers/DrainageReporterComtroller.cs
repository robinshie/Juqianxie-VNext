using CommonInitializer;
using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using Juqianxie.ASPNETCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace DrainagetubeService.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class DrainageReporterComtroller : ControllerBase
    {
        private readonly IDrainageLiquidReporterService _rainageLiquidReporterService;
        private readonly IDrainageUserReporterDomainService _rainageUserReporterDomainService;
        public DrainageReporterComtroller(IDrainageUserReporterDomainService rainageUserReporterDomainService, IDrainageLiquidReporterService rainageLiquidReporterService)
        {
            _rainageLiquidReporterService = rainageLiquidReporterService;
            _rainageUserReporterDomainService = rainageUserReporterDomainService;

        }
        [HttpPost]
        public async Task<ActionResult<ResultResponse<DrainageLiquidReporter>>> FindLiquidRepoterAsync([FromBody] FindRequest findLiquidRepoterRequest,
        CancellationToken cancellationToken)
        {
            var result = await _rainageLiquidReporterService.FindRangeLiquidReporterAsync(findLiquidRepoterRequest.pageindex, findLiquidRepoterRequest.pageLen, findLiquidRepoterRequest.conditions, cancellationToken);

            return new ResultResponse<DrainageLiquidReporter>() { count = result.Item1, datas = result.Item2 };
        }
        [HttpPost]
        public async Task<ActionResult<ResultResponse<DrainageUserReporter>>> FindUserRepoterAsync([FromBody] FindRequest findLiquidRepoterRequest,
     CancellationToken cancellationToken)
        {
            var result = await _rainageUserReporterDomainService.FindRangeUserReporterAsync(findLiquidRepoterRequest.pageindex, findLiquidRepoterRequest.pageLen, findLiquidRepoterRequest.conditions, cancellationToken);

            return new ResultResponse<DrainageUserReporter>() { count = result.Item1, datas = result.Item2 };
        }

    }

}
