using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain
{

    public interface IUserDetailsDomainRepository
    {
        Task<UserDetails?> FindUserDetailsByIdAsync(Guid userId);//根据Id获取用户
        Task<UserDetails?> FindUserDetailsByUIdAsync(long userId);//根据Id获取用户
        Task<UserDetails?> AddUserDetailsAsync(Sex sex, int age, string HospitalNumber, DateTime OperationTime, DateTime DischargeTime, string SurgicalMethod);

       
    }
}

