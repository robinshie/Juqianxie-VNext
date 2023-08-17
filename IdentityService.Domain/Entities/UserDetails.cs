using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public enum Sex
    {
        [Description("男")]
        Man,
        [Description("女")]
        Women
    }
    public record UserDetails : BaseEntity, IHasCreationTime
    {
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


        public UserDetails Create(Sex sex, int age, string HospitalNumber, DateTime OperationTime, DateTime DischargeTime, string SurgicalMethod)
        {
            return new UserDetails
            {
                CreationTime = DateTime.Now,
                Sex = sex,
                Age = age,
                HospitalNumber = HospitalNumber,
                OperationTime = OperationTime,
                DischargeTime = DischargeTime,
                SurgicalMethod = SurgicalMethod
            };
        }


    }
}
