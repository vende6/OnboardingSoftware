﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Configurations
{
    public class PosaoConfiguration : IEntityTypeConfiguration<Posao>
    {
        public void Configure(EntityTypeBuilder<Posao> builder)
        {
            builder
                .HasKey(x => x.ID);

            builder
                .Property(x => x.Naziv)
                .IsRequired();

            builder
                .Property(x => x.Tip)
                .IsRequired();

            builder
                .Property(x => x.Kategorija)
                .IsRequired();

            builder
                .Property(x => x.Opis)
                .IsRequired();
        }
    }
}
