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
    public class OdgovorConfiguration : IEntityTypeConfiguration<Odgovor>
    {
        public void Configure(EntityTypeBuilder<Odgovor> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.TacanOdgovor_1)
                .IsRequired();

            builder
                .Property(x => x.TacanOdgovor_2)
                .IsRequired();

            builder
                .Property(x => x.TacanOdgovor_3)
                .IsRequired();

            builder
                .Property(x => x.TacanOdgovor_4)
                .IsRequired();
        }
    }
}
