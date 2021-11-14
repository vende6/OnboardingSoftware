using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data
{
    public class OnboardingSoftwareDbContext : DbContext
    {
        public DbSet<Aplikant> Aplikanti { get; set; }
        public DbSet<Vjestina> Vjestine { get; set; }
        public DbSet<Interes> Interesi { get; set; }

        public OnboardingSoftwareDbContext(DbContextOptions<OnboardingSoftwareDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new AplikantConfiguration());
            builder
                .ApplyConfiguration(new VjestinaConfiguration());
        }
    }
}
