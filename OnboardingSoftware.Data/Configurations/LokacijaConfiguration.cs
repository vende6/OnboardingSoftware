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
    public class LokacijaConfiguration : IEntityTypeConfiguration<Lokacija>
    {
        public void Configure(EntityTypeBuilder<Lokacija> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.Naziv)
                .IsRequired();

            builder
                .Property(x => x.Adresa)
                .IsRequired();

            builder
                .Property(x => x.Opis)
                .IsRequired();
        }
    }
}
