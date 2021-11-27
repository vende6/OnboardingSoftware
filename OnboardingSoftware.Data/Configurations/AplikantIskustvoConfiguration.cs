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
    public class AplikantIskustvoConfiguration : IEntityTypeConfiguration<AplikantIskustvo>
    {
        public void Configure(EntityTypeBuilder<AplikantIskustvo> builder)
        {
            builder
                .HasKey(x => new { x.AplikantID, x.IskustvoID });

        }
    }
}
