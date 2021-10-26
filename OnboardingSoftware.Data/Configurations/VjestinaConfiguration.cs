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
    public class VjestinaConfiguration : IEntityTypeConfiguration<Vjestina>
    {
        public void Configure(EntityTypeBuilder<Vjestina> builder)
        {
            builder
                .HasKey(m => m.ID);

            builder
                .Property(m => m.Naziv)
                .IsRequired();

        }
    }
}
