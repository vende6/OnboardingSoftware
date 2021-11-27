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
    public class ObrazovanjeConfiguration : IEntityTypeConfiguration<Obrazovanje>
    {
        public void Configure(EntityTypeBuilder<Obrazovanje> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.Fakultet)
                .IsRequired();
        }
    }
}
