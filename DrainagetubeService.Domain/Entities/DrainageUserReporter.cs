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
    public enum Sex
    {
        [Description("男")]
        Man=0,
        [Description("女")]
        Women=1
    }
    public record DrainageUserReporter : AggregateRootEntity, IAggregateRoot, IHasCreationTime
    {

        public string Key { get; private set; }
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

        public string TubType { get; private set; }


        public static DrainageUserReporter Create(long Uid, string username, DateTime creationTime, Sex sex, int age, string hospitalNumber, DateTime operationTime, DateTime dischargeTime, string surgicalMethod, string tubType)
        {
            DrainageUserReporter drainageUserReporter = new DrainageUserReporter()
            {
                Key = Guid.NewGuid().ToString(),
                Uid = Uid,
                Username = username,
                CreationTime = creationTime,
                Sex = sex,
                Age = age,
                HospitalNumber = hospitalNumber,
                OperationTime = operationTime,
                DischargeTime = dischargeTime,
                SurgicalMethod = surgicalMethod,
                TubType = tubType
            };
            return drainageUserReporter;
        }

    }
}

