using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Configurations
{
    public class AplikantObrazovanjeConfiguration : IEntityTypeConfiguration<AplikantObrazovanje>
    {
        public void Configure(EntityTypeBuilder<AplikantObrazovanje> builder)
        {
            builder
                .HasKey(x => new { x.AplikantID, x.ObrazovanjeID });
        }
    }
}
