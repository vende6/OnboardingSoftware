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
        public DbSet<Interes> Interesi { get; set; }
        public DbSet<Iskustvo> Iskustvo { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Obrazovanje> Obrazovanje { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Posao> Poslovi { get; set; }
        public DbSet<Test> Testovi { get; set; }
        public DbSet<Vjestina> Vjestine { get; set; }
        public DbSet<AplikantVjestina> AplikantVjestina { get; set; }
        public DbSet<AplikantInteres> AplikantInteres { get; set; }
        public DbSet<AplikantIskustvo> AplikantIskustvo { get; set; }
        public DbSet<AplikantObrazovanje> AplikantObrazovanje { get; set; }
        public DbSet<AplikantPosao> AplikantPosao { get; set; }
        public DbSet<AplikantTest> AplikantTest { get; set; }

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
            builder
                .ApplyConfiguration(new InteresConfiguration());
            builder
                .ApplyConfiguration(new IskustvoConfiguration());
            builder
                .ApplyConfiguration(new ObrazovanjeConfiguration());
            builder
                .ApplyConfiguration(new PosaoConfiguration());
            builder
                .ApplyConfiguration(new TestConfiguration());
            builder
                .ApplyConfiguration(new AplikantVjestinaConfiguration());
            builder
                .ApplyConfiguration(new AplikantInteresConfiguration());
            builder
                .ApplyConfiguration(new AplikantIskustvoConfiguration());
            builder
                .ApplyConfiguration(new AplikantObrazovanjeConfiguration());
            builder
                .ApplyConfiguration(new AplikantPosaoConfiguration());
            builder
                .ApplyConfiguration(new AplikantTestConfiguration());
        }
    }
}
