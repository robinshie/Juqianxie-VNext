using DrainagetubeService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Events
{
    public record DraingeLiquidAddEvent(long Uid) : INotification;
    public record DraingeLiquidDeletedEvent(long Id) : INotification;
}
