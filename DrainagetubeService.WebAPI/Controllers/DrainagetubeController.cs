using CommonInitializer;
using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DrainagetubeService.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "User,Admin")]
    public class DrainagetubeController : ControllerBase
    {
        IDrainagetubeDomainService _drainagetubeDomainService;

        public DrainagetubeController(IDrainagetubeDomainService drainagetubeDomainService)
        {
            _drainagetubeDomainService = drainagetubeDomainService;
        }
        [HttpGet]
        public async Task<string> FindAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainagetubeDomainService.FindAllByPageAsync(pageIndex, pageSize, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }
        [HttpGet]
        public async Task<string> FindByUserAsync(long uid, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainagetubeDomainService.FindByuserAsync(uid, pageIndex, pageSize, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }

        //[HttpPost]
        //public async Task<ActionResult<string>> Add([FromBody] TubeBulkAddRequest tubeBulkAddRequest, CancellationToken cancellationToken)
        //{
        //    var result = await _drainagetubeDomainService.AddDrainagetubeAsync(tubeBulkAddRequest.tubeType, tubeBulkAddRequest.tubePosition, tubeBulkAddRequest.tubeExtention, tubeBulkAddRequest.Uid, tubeBulkAddRequest.TranID, cancellationToken);
        //    if (result == null)
        //    {
        //        return "";
        //    }
        //    return result.ToJsonString();

        //}
        [HttpPost]
        public async Task<ActionResult<string>> BulkAdd([FromBody] IEnumerable<TubeBulkAddRequest> tubeBulkAddRequest, CancellationToken cancellationToken)
        {
            var list = new List<Drainagetube>();
            if (tubeBulkAddRequest == null || tubeBulkAddRequest.Count() == 0)
            {
                return "";
            }
            foreach (var tubeitems in tubeBulkAddRequest)
            {
                if (tubeitems.tubeBulkAddStructures == null || tubeitems.tubeBulkAddStructures.Count() == 0) { continue; }
                foreach (var item in tubeitems.tubeBulkAddStructures)
                {
                    list.Add(Drainagetube.Create(item.tubeType, item.tubePosition, item.tubeExtention, tubeitems.Uid, tubeitems.TranID));

                }
            }
            var result = await _drainagetubeDomainService.BulkAddDrainagetubeAsync(list, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();

        }
    }
}
