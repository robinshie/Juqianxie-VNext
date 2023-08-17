using IdentityService.Domain;
using IdentityService.Domain.Entities;
using Juqianxie.DomainCommons.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace IdentityService.Infrastructure.Configs
{
    class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(256);
            // builder.HasAlternateKey(x => x.ShowID);
            //builder.HasTableOption("AUTO_INCREMENT", "0");
        }
    }
}
