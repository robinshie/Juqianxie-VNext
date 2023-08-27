using Juqianxie.EventBus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Events
{
    public class DraingeLiquidAddEventHandler : INotificationHandler<DraingeLiquidAddEvent>
    {
        private readonly IEventBus eventBus;

        public DraingeLiquidAddEventHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }
        public Task Handle(DraingeLiquidAddEvent notification, CancellationToken cancellationToken)
        {
            var data = notification.Uid;
            var transid = notification.Transid;
            eventBus.Publish("DrainageLiquid.Liquid.Add", new { Uid = data, TransID = transid });//发布集成时间
            return Task.CompletedTask;
        }
    }
}
