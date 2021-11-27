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
    public class IskustvoConfiguration : IEntityTypeConfiguration<Iskustvo>
    {
        public void Configure(EntityTypeBuilder<Iskustvo> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.JeTrenutnoZaposlen)
                .IsRequired();
        }
    }
}
