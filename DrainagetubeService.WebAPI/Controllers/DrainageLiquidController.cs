using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using DrainagetubeService.Domain.Events;
using DrainagetubeService.Infrastructure;
using Juqianxie.EventBus;
using MediatR;
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
        private readonly IDrainageUserReporterRepository _userReporterRepository;
        private readonly IDrainageLiquidRepository _drainageLiquidRepository;
        private readonly IDrainagetubeRepository _drainagetubeRepository;
        private IMediator? _mediator;
        public DrainageLiquidController(IDrainageLiquidDomainService drainageLiquidDomainService, IMediator? mediator, IDrainageLiquidRepository drainageLiquidRepository, IDrainagetubeRepository drainagetubeRepository)
        {
            _drainageLiquidDomainService = drainageLiquidDomainService;
            _mediator = mediator;
            _drainageLiquidRepository = drainageLiquidRepository;
            _drainagetubeRepository = drainagetubeRepository;
            //_eventBus= eventBus;
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
        public async Task<string> Test(int Uid)
        {
            var tubes = await _drainagetubeRepository.FindByuserAsync(Uid, -1, -1, CancellationToken.None);
            List<DrainageLiquidReporter> repo = new List<DrainageLiquidReporter>();
            foreach (var item in tubes)
            {
                var liques = await _drainageLiquidRepository.FindByTubeKeysAsync(item.Key.ToString(), CancellationToken.None);
                foreach (var lique in liques)
                {
                    //repo.Add(new DrainageLiquidReporter() { Volum = lique.Volume, TubType = item.TubeType });
                }
            }
            return repo.ToJsonString();
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
            await _mediator.Publish(new DraingeLiquidAddEvent(Uid));
            return result.ToJsonString();

        }

        [HttpPost]
        public async Task<ActionResult<string>> Addtest(long Uid, CancellationToken cancellationToken)
        {
            var result = new DrainageLiquid(); //await _drainageLiquidDomainService.AddDrainageLiquidAsync(RecordTime, LiquidColor, LiquidProperty, Liquidodour, TubeState, Volume, Uid, Tubekey, cancellationToken);
            if (result == null)
            {
                return "";
            }
            await _mediator.Publish(new DraingeLiquidAddEvent(Uid));
            return result.ToJsonString();

        }
    }
}
