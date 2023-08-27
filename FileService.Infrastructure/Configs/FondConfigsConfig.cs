using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileService.Domain.Entities;

namespace FileService.Infrastructure.Configs
{
    class FondConfigsConfig : IEntityTypeConfiguration<FondConfigs>
    {
        public void Configure(EntityTypeBuilder<FondConfigs> builder)
        {
            builder.ToTable("T_FS_FondConfigs");
        }
    }
}
