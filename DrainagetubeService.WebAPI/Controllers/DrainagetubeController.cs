using DrainagetubeService.Domain;
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
            _drainagetubeDomainService= drainagetubeDomainService;
        }
        [HttpGet]
        public async Task<string> FindAllAsync(int pageIndex,int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainagetubeDomainService.FindAllByPageAsync(pageIndex, pageSize,cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }
        [HttpGet]
        public async Task<string> FindByUserAsync(long uid,int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _drainagetubeDomainService.FindByuserAsync(uid,pageIndex, pageSize, cancellationToken);
            if (result == null)
            {
                return "";
            }
            return result.ToJsonString();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(string tubeType, string tubePosition, string tubeExtention, long Uid, CancellationToken cancellationToken) 
        {
            var result = await _drainagetubeDomainService.AddDrainagetubeAsync(tubeType, tubePosition, tubeExtention, Uid, cancellationToken);
            if (result == null) 
            {
                return "";
            }
            return result.ToJsonString();

        }
    }
}
