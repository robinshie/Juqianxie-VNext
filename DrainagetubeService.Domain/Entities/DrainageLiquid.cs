using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Entities
{
    public record DrainageLiquid : BaseEntity, IHasCreationTime
    {
        public DateTime CreationTime { get; private set; }
        public DateTime RecordTime { get; private set; }
        public string LiquidColor { get; private set; }
        public string LiquidProperty { get; private set; }
        public string Liquidodour { get; private set; }
        public string TubeState { get; private set; }
        public int Volume { get; private set; }
        public string TubeKey { get; private set; }
        public Guid Key { get; private set; }
        public long Uid { get; private set; }

        public void Create(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, int Volume, long Uid,string Tubekey)
        {
            this.CreationTime = DateTime.Now;
            this.RecordTime = RecordTime;
            this.LiquidColor = LiquidColor;
            this.LiquidProperty = LiquidProperty;
            this.Liquidodour = Liquidodour;
            this.TubeState = TubeState;
            this.Volume = Volume;
            this.Uid = Uid;
            this.TubeKey = Tubekey;
            this.Key = Guid.NewGuid();
        }

    }
}
