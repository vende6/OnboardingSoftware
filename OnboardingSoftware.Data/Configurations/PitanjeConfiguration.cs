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
    public class PitanjeConfiguration : IEntityTypeConfiguration<Pitanje>
    {
        public void Configure(EntityTypeBuilder<Pitanje> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.Tekst)
                .IsRequired();
        }
    }
}
