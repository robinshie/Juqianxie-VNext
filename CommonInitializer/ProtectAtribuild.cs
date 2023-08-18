using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInitializer
{
    public class ProtectAtribuild : ActionFilterAttribute
    {
        protected readonly ILogger<ProtectAtribuild> Logger;
        private readonly IProtectService protectService;
        private readonly string mykey = "MIIBCgKCAQEAo0kAT/ze4Pk7HmIMUXIX8vUo3HCA61H+szeaCr2jMfsVZvprJ21l1I1Ph/0PFiPGmIw2YAkoaVgmtq7/hHYLZB1Hnf2S78oN18toeeqQaS8Nd+4nSxfPSOOnr41jv4hxcUSry3E+/qBeA+k2ZTn86ASY/ha8pBP8iZKanfOWoPlHe51yaw2SpOi2UBs9q99HnykBs8d1ZTfXp8KOfYVFNcEMQ9u4GMmpA22dtf6+6CkGYltn7LvDula0PZ/vtfrNrrDx2Mq0IiAsdRlxa6NE2VdzNKSxco5jlwAFdBfQpxIMuXe8qxmDgeYRkla0KKbi2T490Axb0VvGQQ+o2C2hiQIDAQAB";
        public ProtectAtribuild(ILogger<ProtectAtribuild> logger, IProtectService protectService)
        {
            Logger = logger;
            this.protectService = protectService;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var data = objectResult.Value.ToJsonString();

                objectResult.Value = protectService.Encrypt(data, mykey);

            }
        }

    }
}
