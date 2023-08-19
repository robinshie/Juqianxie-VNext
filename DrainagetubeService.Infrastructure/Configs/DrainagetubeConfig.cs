using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrainagetubeService.Domain;
using DrainagetubeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrainagetubeService.Infrastructure.Configs
{
    internal class DrainagetubeConfig : IEntityTypeConfiguration<Drainagetube>
    {
        public void Configure(EntityTypeBuilder<Drainagetube> builder)
        {
            builder.ToTable("T_Drainagetube");
        }
    }
}
