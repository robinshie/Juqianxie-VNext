using Juqianxie.DomainCommons.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class User : IdentityUser<long>, IHasCreationTime, IHasDeletionTime, ISoftDelete
    {
        public DateTime CreationTime { get; init; }

        public DateTime? DeletionTime { get; private set; }
        //public string UserName { get; private set; }
        public bool IsDeleted { get; private set; }
        public string HospitalNumber { get; private set; }

        public string? UserName { get; private set; }
        public User(string userName) : base(userName)
        {
            CreationTime = DateTime.Now;
            UserName = userName;
        }
        public User(string userName,string HospiteNumber) : base(HospiteNumber)
        {
            CreationTime = DateTime.Now;
            UserName = userName;
            HospitalNumber = HospiteNumber;
        }
        public void SoftDelete()
        {
            this.IsDeleted = true;
            this.DeletionTime = DateTime.Now;
        }
    }

}
