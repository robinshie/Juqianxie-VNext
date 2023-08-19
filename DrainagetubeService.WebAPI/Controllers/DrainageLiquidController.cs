using DrainagetubeService.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrainagetubeService.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class DrainageLiquidController : ControllerBase
    {
        IDrainageLiquidDomainService _drainageLiquidDomainService;

        public DrainageLiquidController(IDrainageLiquidDomainService drainageLiquidDomainService)
        {
            _drainageLiquidDomainService = drainageLiquidDomainService;
        }
        [HttpGet]
        public async Task<string> FindAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainageLiquidDomainService.FindAllByPageAsync(pageIndex, pageSize, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }
        [HttpGet]
        public async Task<string> FindByUserAsync(long uid, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainageLiquidDomainService.FindByuserAsync(uid, pageIndex, pageSize, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid, string Tubekey, CancellationToken cancellationToken)
        {
            var result = await _drainageLiquidDomainService.AddDrainageLiquidAsync(RecordTime, LiquidColor, LiquidProperty, Liquidodour, TubeState, Volume, Uid, Tubekey, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();

        }
    }
}
