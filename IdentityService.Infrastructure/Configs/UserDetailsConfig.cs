using IdentityService.Domain;
using IdentityService.Domain.Entities;
using Juqianxie.DomainCommons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace IdentityService.Infrastructure.Configs
{
    class UserDetailsConfig : IEntityTypeConfiguration<UserDetails>
    {

        public void Configure(EntityTypeBuilder<UserDetails> builder)
        {
            builder.ToTable("T_UserDetails");
            // builder.HasAlternateKey(x => x.ShowID);
            //builder.HasTableOption("AUTO_INCREMENT", "0");

        }
    }
}
