using DrainagetubeService.Domain.Events;
using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Entities
{
    public record DrainageLiquid : AggregateRootEntity, IAggregateRoot, IHasCreationTime
    {
        public DateTime CreationTime { get; private set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; private set; }
        /// <summary>
        /// 引流管颜色
        /// </summary>
        public string LiquidColor { get; private set; }
        /// <summary>
        /// 引流管性状
        /// </summary>
        public string LiquidProperty { get; private set; }
        /// <summary>
        /// 溢流管气体
        /// </summary>
        public string Liquidodour { get; private set; }
        /// <summary>
        /// 导管状态
        /// </summary>
        public string TubeState { get; private set; }
        /// <summary>
        /// 24小时引流量
        /// </summary>
        public float Volume { get; private set; }
        public string TubeKey { get; private set; }
        public Guid Key { get; private set; }
        public long Uid { get; private set; }
        
       
        public static DrainageLiquid Create(DateTime RecordTime, string LiquidColor, string LiquidProperty, string Liquidodour, string TubeState, float Volume, long Uid,string Tubekey)
        {
            DrainageLiquid drainageLiquid = new DrainageLiquid();
            drainageLiquid.CreationTime = DateTime.Now;
            drainageLiquid.RecordTime = RecordTime;
            drainageLiquid.LiquidColor = LiquidColor;
            drainageLiquid.LiquidProperty = LiquidProperty;
            drainageLiquid.Liquidodour = Liquidodour;
            drainageLiquid.TubeState = TubeState;
            drainageLiquid.Volume = Volume;
            drainageLiquid.Uid = Uid;
            drainageLiquid.TubeKey = Tubekey;
            drainageLiquid.Key = Guid.NewGuid();
           
            return drainageLiquid;
        }

    }
}
