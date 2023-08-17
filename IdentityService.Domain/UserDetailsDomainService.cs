using IdentityService.Domain.Entities;
using Juqianxie.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain
{
    public class UserDetailsDomainService
    {
        private readonly IUserDetailsDomainRepository repository;
        public UserDetailsDomainService(IUserDetailsDomainRepository repository
                  )
        {
            this.repository = repository;
        }
        public Task<UserDetails?> AddUserDetailsAsync(Sex sex, int age, string HospitalNumber, DateTime OperationTime, DateTime DischargeTime, string SurgicalMethod)
        {
            
            return repository.AddUserDetailsAsync(sex, age, HospitalNumber, OperationTime, DischargeTime, SurgicalMethod);

        }


    }
}
