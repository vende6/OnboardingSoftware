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
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
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
                .Property(x => x.Pocetak)
                .IsRequired();

            builder
                .Property(x => x.Kraj)
                .IsRequired();

            builder
                .Property(x => x.BrojPitanja)
                .IsRequired();

            builder
                .Property(x => x.OsvojeniProcenat)
                .IsRequired();
        }
    }
}
