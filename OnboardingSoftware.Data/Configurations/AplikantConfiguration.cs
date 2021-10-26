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
    public class AplikantConfiguration : IEntityTypeConfiguration<Aplikant>
    {
        public void Configure(EntityTypeBuilder<Aplikant> builder)
        {
            builder
                .HasKey(m => m.ID);

            builder
                .Property(m => m.Adresa)
                .IsRequired();

        }
    }
}
