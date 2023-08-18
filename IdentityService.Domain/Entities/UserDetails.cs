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
        public long UserId { get; private set; }
        public UserDetails()
        {
                
        }
        public UserDetails(Sex sex, int age, string hospitalNumber, DateTime operationTime, DateTime dischargeTime, string surgicalMethod, long userid)
        {

            UserId = userid;
            CreationTime = DateTime.Now;
                Sex = sex;
            Age = age;
            HospitalNumber = hospitalNumber;
            OperationTime = operationTime;
            DischargeTime = dischargeTime;
            SurgicalMethod = surgicalMethod;


        }


    }
}
