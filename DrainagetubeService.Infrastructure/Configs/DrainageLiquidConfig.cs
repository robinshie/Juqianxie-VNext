using DrainagetubeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Infrastructure.Configs
{
    internal class DrainageLiquidConfig : IEntityTypeConfiguration<DrainageLiquid>
    {
        public void Configure(EntityTypeBuilder<DrainageLiquid> builder)
        {
            builder.ToTable("T_DrainageLiquid");
        }
    }
}
