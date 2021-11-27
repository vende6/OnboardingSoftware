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
    public class AplikantVjestinaConfiguration : IEntityTypeConfiguration<AplikantVjestina>
    {

        public void Configure(EntityTypeBuilder<AplikantVjestina> builder)
        {
            builder
               .HasKey(x => new { x.AplikantID, x.VjestinaID });

            builder
                 .HasOne(x => x.Aplikant)
                 .WithMany(x => x.AplikantVjestina)
                 .HasForeignKey(x => x.AplikantID);

            builder
                .HasOne(x => x.Vjestina)
                .WithMany(x => x.AplikantVjestina)
                .HasForeignKey(x => x.VjestinaID);

        }
    }
}
