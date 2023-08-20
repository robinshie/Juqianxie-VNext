using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Entities
{
    
    public record DrainageLiquidReporter : AggregateRootEntity, IAggregateRoot, IHasCreationTime
    {
        public DrainageLiquidReporter(long uid, string username, DateTime creationTime, Sex sex, int age, string hospitalNumber, DateTime operationTime, DateTime dischargeTime, string surgicalMethod, string tubType, DateTime recordTime, string liquidColor, string liquidProperty, string liquidodour, string tubeState, int volum)
        {
            Uid = uid;
            Username = username;
            CreationTime = creationTime;
            Sex = sex;
            Age = age;
            HospitalNumber = hospitalNumber;
            OperationTime = operationTime;
            DischargeTime = dischargeTime;
            SurgicalMethod = surgicalMethod;
            TubType = tubType;
            RecordTime = recordTime;
            LiquidColor = liquidColor;
            LiquidProperty = liquidProperty;
            Liquidodour = liquidodour;
            TubeState = tubeState;
            Volum = volum;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; private set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; private set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; private set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string HospitalNumber { get; private set; }
        /// <summary>
        /// 手术时间
        /// </summary>
        public DateTime OperationTime { get; private set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DischargeTime { get; private set; }
        /// <summary>
        /// 手术方式
        /// </summary>
        public string SurgicalMethod { get; private set; }
        /// <summary>
        /// 引流管名称
        /// </summary>
        public string TubType { get;  set; }

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
        public int Volum { get;  set; }


    }
}

